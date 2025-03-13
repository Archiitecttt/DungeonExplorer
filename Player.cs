using System;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents a player in the game with a name and an inventory.
    /// </summary>
    public class Player
    {
        private string name;              // The player's name
        private string inventoryItem;     // The item currently held by the player

        /// <summary>
        /// Initializes a new instance of the Player class with the specified name.
        /// </summary>
        public Player(string name)
        {
            this.name = name;             // Set the player's name
            this.inventoryItem = null;    // Initialize the inventory with no items
        }

        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        /// <returns>
        /// The name of the player.
        /// </returns>
        public string GetName()
        {
            return name;  // Return the player's name
        }

        /// <summary>
        /// Attempts to pick up an item and add it to the player's inventory.
        /// The player can only hold one item at a time.
        /// </summary>
        public void PickUpItem(string item)
        {
            if (inventoryItem == null)  // If the player is not holding an item
            {
                inventoryItem = item;   // Add the item to the player's inventory
            }
            else
            {
                // If the player is already holding an item, display a message
                Console.WriteLine("You are already holding an item.");
            }
        }

        /// <summary>
        /// Gets the current inventory of the player.
        /// </summary>
        /// <returns>
        /// The name of the item the player is holding, or 'Empty' if the player has no item.
        /// </returns>
        public string GetInventory()
        {
            return inventoryItem ?? "Empty";  // Return the inventory item or "Empty" if there's none
        }
    }
}
