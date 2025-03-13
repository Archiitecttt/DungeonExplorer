using System;

namespace DungeonExplorer
{
    public class Player
    {
        private string name;
        private string inventoryItem;

        public Player(string name)
        {
            this.name = name;
            this.inventoryItem = null;
        }

        public string GetName()
        {
            return name;
        }

        public void PickUpItem(string item)
        {
            if (inventoryItem == null)
            {
                inventoryItem = item;
            }
            else
            {
                Console.WriteLine("You are already holding an item.");
            }
        }

        public string GetInventory()
        {
            return inventoryItem ?? "Empty";
        }
    }
}
