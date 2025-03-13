using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents a room in the dungeon, containing a description, items, and potentially a monster.
    /// </summary>
    public class Room
    {
        private string description;
        private List<string> items;
        private string monster;

        /// <summary>
        /// Initializes a new room with a description, optional items, and an optional monster.
        /// </summary>
        
        public Room(string description, List<string> items = null, string monster = null)
        {
            // Set the description of the room
            this.description = description;

            // Initialize items (if none provided, default to an empty list)
            this.items = items ?? new List<string>();

            // Set the monster (if provided, otherwise it's null)
            this.monster = monster;
        }

        /// <summary>
        /// Gets the full description of the room, including any items and monsters present.
        /// </summary>
        /// <returns>
        /// A string describing the room, its items, and any monsters.
        /// </returns>
        public string GetDescription()
        {
            // Generate a description of items in the room (if any)
            string itemText = items.Count > 0 ? $"Items in the room: {string.Join(", ", items)}" : "No items here.";

            // Generate a description of the monster in the room (if any)
            string monsterText = monster != null ? $"A {monster} is here!" : "No monsters are here.";

            // Return the full room description
            return $"{description}\n{itemText}\n{monsterText}";
        }

        /// <summary>
        /// Checks if the room contains any items.
        /// </summary>
        /// <returns>
        /// True if the room contains items, false otherwise.
        /// </returns>
        public bool HasItem()
        {
            return items.Count > 0;
        }

        /// <summary>
        /// Takes the first item from the room and removes it from the room's inventory.
        /// </summary>
        /// <returns>
        /// The name of the item taken, or null if no item is available.
        /// </returns>
        public List<string> TakeItems()
        {
            List<string> takenItems = new List<string>();

            // If the room contains any items, take them one by one
            while (items.Count > 0)
            {
                takenItems.Add(items[0]);
                items.RemoveAt(0);
            }

            return takenItems;
        }

        /// <summary>
        /// Checks if there is a monster in the room.
        /// </summary>
        /// <returns>
        /// True if there is a monster in the room, false otherwise.
        /// </returns>
        public bool HasMonster()
        {
            return monster != null;
        }

        /// <summary>
        /// Gets the name of the monster in the room.
        /// </summary>
        /// <returns>
        /// The name of the monster, or null if there is no monster.
        /// </returns>
        public string GetMonster()
        {
            return monster;
        }
    }
}
