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
            // Initialize player with a name "Hero"
            player = new Player("Hero");

            // Create a room with description, items, and a monster
            currentRoom = new Room("A room with stone brick walls, a puddle of water, and a table at the far end",
                new List<string> { "Key", "Potion" },
                "Goblin");

            // Set the game to be in the playing state
            playing = true;
        }

        /// <summary>
        /// Starts the game loop. Displays the menu and handles user input until the game ends.
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Welcome to Dungeon Explorer!");
            Console.WriteLine($"You are {player.GetName()}.");

            // Loop continues until the game ends
            while (playing)
            {
                DisplayMenu();
                string input = Console.ReadLine()?.Trim();

                // Handle invalid or empty input
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
            }

        /// <summary>
        /// Handles the user input by executing the corresponding game action.
        /// </summary>
        private void HandleUserInput(string input)
        {
            switch (input)
            {
                case "1":
                    // Display room description
                    Console.WriteLine($"Room: {currentRoom.GetDescription()}");
                    break;
                case "2":
                    // Attempt to pick up an item from the room
                    AttemptToPickUpItem();
                    break;
                case "3":
                    // Display the player's inventory
                    Console.WriteLine($"Inventory: {player.GetInventory()}");
                    break;
                case "4":
                    // Exit the game
                    Console.WriteLine("Exiting game...");
                    playing = false;
                    break;
                default:
                    // Invalid input case
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        /// <summary>
        /// Attempts to pick up an item from the current room if available.
        /// </summary>
        private void AttemptToPickUpItem()
        {
            // Check if the room has any items
            if (currentRoom.HasItem())
            {
                // Take all the items from the room
                List<string> items = currentRoom.TakeItems();

                // Loop through all items and add them to the player's inventory
                foreach (string item in items)
                {
                    player.PickUpItem(item);
                    Console.WriteLine($"You picked up the {item}!");
                }
            }
            else
            {
                // If there are no items in the room
                Console.WriteLine("There's no item to pick up.");
            }
        }
    }
}
