namespace DungeonExplorer
{
    /// <summary>
    /// Represents a monster in the game.
    /// </summary>
    public class Monster
    {
        public string Name { get; set; }
        public int Health { get; set; }

        /// <summary>
        /// Initializes a new instance of the Monster class.
        /// </summary>
        public Monster(string name, int health = 100)
        {
            Name = name;
            Health = health;
        }
    }
}
