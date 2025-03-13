using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// The main game class that controls the flow of the game. It manages the player, room, and game loop.
    /// </summary>
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private bool playing;

        /// <summary>
        /// Initializes a new game with a player and a room.
        /// </summary>
        public Game()
        {
            player = new Player("Hero");

            // Create some monsters for the room
            List<Monster> monsters = new List<Monster>
            {
                new Monster("Goblin"),
                new Monster("Troll")
            };

            // Create a room with description, items, and monsters
            currentRoom = new Room("A room with stone brick walls, a puddle of water, and a table at the far end",
                new List<string> { "Key", "Potion" },
                monsters);

            playing = true;
        }

        /// <summary>
        /// Starts the game loop. Displays the menu and handles user input until the game ends.
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Welcome to Dungeon Explorer!");
            Console.WriteLine($"You are {player.GetName()}.");

            while (playing)
            {
                DisplayMenu();
                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter a valid command.");
                    continue;
                }

                HandleUserInput(input);
            }
        }

        /// <summary>
        /// Displays the menu of options for the player to choose from.
        /// </summary>
        private void DisplayMenu()
        {
            Console.WriteLine(@"
What would you like to do?
1. View Room Description
2. Pick up an item
3. Check Inventory
4. Exit Game
Enter your choice: ");
        }

        /// <summary>
        /// Handles the user input by executing the corresponding game action.
        /// </summary>
        private void HandleUserInput(string input)
        {
            switch (input)
            {
                case "1":
                    Console.WriteLine($"Room: {currentRoom.GetDescription()}");
                    break;
                case "2":
                    AttemptToPickUpItem();
                    break;
                case "3":
                    Console.WriteLine($"Inventory: {player.GetInventory()}");
                    break;
                case "4":
                    Console.WriteLine("Exiting game...");
                    playing = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        /// <summary>
        /// Attempts to pick up an item from the current room if available.
        /// </summary>
        private void AttemptToPickUpItem()
        {
            if (currentRoom.HasItem())
            {
                List<string> items = currentRoom.TakeItems();

                foreach (string item in items)
                {
                    player.PickUpItem(item);
                    Console.WriteLine($"You picked up the {item}!");
                }
            }
            else
            {
                Console.WriteLine("There's no item to pick up.");
            }

            if (currentRoom.HasMonsters())
            {
                Console.WriteLine("Monsters are watching you closely!");
            }
        }
    }
}
