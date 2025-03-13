using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private List<string> items;
        private List<Monster> monsters;

        public Room(string description, List<string> items = null, List<Monster> monsters = null)
        {
            this.description = description;
            this.items = items ?? new List<string>();
            this.monsters = monsters ?? new List<Monster>();
        }

        public string GetDescription()
        {
            string itemText = items.Count > 0 ? $"Items in the room: {string.Join(", ", items)}" : "No items here.";
            string monsterText = monsters.Count > 0 ? $"Monsters here: {string.Join(", ", monsters.ConvertAll(m => m.Name))}" : "No monsters here.";
            return $"{description}\n{itemText}\n{monsterText}";
        }

        public bool HasMonsters()
        {
            return monsters.Count > 0;
        }

        public List<Monster> GetMonsters()
        {
            return monsters;
        }

        public void AddMonster(Monster monster)
        {
            monsters.Add(monster);
        }

        public List<string> TakeItems()
        {
            List<string> takenItems = new List<string>();
            while (items.Count > 0)
            {
                takenItems.Add(items[0]);
                items.RemoveAt(0);
            }
            return takenItems;
        }
    }
}
