using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private List<string> items;
        private string monster;

        public Room(string description, List<string> items = null, string monster = null)
        {
            this.description = description;
            this.items = items ?? new List<string>();  // Default to empty list if null
            this.monster = monster;
        }

        public string GetDescription()
        {
            string itemText = items.Count > 0 ? $"Items in the room: {string.Join(", ", items)}" : "No items here.";
            string monsterText = monster != null ? $"A {monster} is here!" : "No monsters are here.";
            return $"{description}\n{itemText}\n{monsterText}";
        }

        public bool HasItem()
        {
            return items.Count > 0;
        }

        public string TakeItem()
        {
            if (items.Count > 0)
            {
                string takenItem = items[0];
                items.RemoveAt(0);  // Remove the item from the room
                return takenItem;
            }
            return null;
        }

        public bool HasMonster()
        {
            return monster != null;
        }

        public string GetMonster()
        {
            return monster;
        }
    }
}
