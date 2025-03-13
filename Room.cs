namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private string item;

        public Room(string description, string item = null)
        {
            this.description = description;
            this.item = item;
        }

        public string GetDescription()
        {
            return description;
        }

        public bool HasItem()
        {
            return item != null;
        }

        public string TakeItem()
        {
            string temp = item;
            item = null;
            return temp;
        }
    }
}
