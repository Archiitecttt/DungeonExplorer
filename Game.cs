using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private bool playing;

        public Game()
        {
            player = new Player("Hero");
            currentRoom = new Room("A room with stone brick walls, a puddle of water, and a table at the far end",
                new List<string> { "Key", "Potion" },
                "Goblin");
            playing = true;
        }

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

        private void DisplayMenu()
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. View Room Description");
            Console.WriteLine("2. Pick up an item");
            Console.WriteLine("3. Check Inventory");
            Console.WriteLine("4. Exit Game");
            Console.Write("Enter your choice: ");
        }

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

        private void AttemptToPickUpItem()
        {
            if (currentRoom.HasItem())
            {
                string itemName = currentRoom.TakeItem();
                player.PickUpItem(itemName);
                Console.WriteLine($"You picked up the {itemName}!");
            }
            else
            {
                Console.WriteLine("There's no item to pick up.");
            }
        }
    }
}