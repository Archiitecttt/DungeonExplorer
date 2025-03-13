using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        private string name;
        private List<string> inventory;

        public Player(string name)
        {
            this.name = name;
            this.inventory = new List<string>();  // List for inventory (rather than like holding 1 item at a time)
        }

        public string GetName()
        {
            return name;
        }

        // Adding an item to inventory
        public void PickUpItem(string item)
        {
            inventory.Add(item);
            Console.WriteLine($"You have added {item} to your inventory.");
        }

        // Display the player's inventory
        public string GetInventory()
        {
            if (inventory.Count == 0)
                return "Empty";
            return string.Join(", ", inventory); // Join all items so it can still be returned as a string
        }
    }
}
