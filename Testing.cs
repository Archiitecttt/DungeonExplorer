using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DungeonExplorer
{
    /// <summary>
    /// Contains the test cases for validating the functionality of the game elements.
    /// </summary>
    public class Testing
    {
        /// <summary>
        /// Runs all the tests to validate the correct functionality of the game components.
        /// </summary>
        public static void RunTests()
        {
            // Start the testing process
            Console.WriteLine("Running tests...");

            // Create a test room with items and multiple monsters
            Monster orc = new Monster("Orc");
            Monster goblin = new Monster("Goblin");
            Room testRoom = new Room("Test Room", new List<string> { "Sword", "Shield" }, new List<Monster> { orc, goblin });

            // Test that the room description includes the expected items
            Debug.Assert(testRoom.GetDescription().Contains("Sword"), "Test Failed: Room should contain 'Sword'");
            Debug.Assert(testRoom.GetDescription().Contains("Shield"), "Test Failed: Room should contain 'Shield'");

            // Test that the room contains monsters
            Debug.Assert(testRoom.HasMonster(), "Test Failed: Room should have monsters");
            Debug.Assert(testRoom.GetMonsters().Count == 2, "Test Failed: Room should have two monsters");
            Debug.Assert(testRoom.GetMonsters()[0].Name == "Orc", "Test Failed: First monster should be 'Orc'");
            Debug.Assert(testRoom.GetMonsters()[1].Name == "Goblin", "Test Failed: Second monster should be 'Goblin'");

            // Create a test player
            Player testPlayer = new Player("Test Player");

            // Take the first item from the room (should be "Sword")
            string itemPicked = testRoom.TakeItems()[0]; // Take the first item from the list
            testPlayer.PickUpItem(itemPicked);

            // Test that the player has the correct item in their inventory
            Debug.Assert(testPlayer.GetInventory().Contains("Sword"), "Test Failed: Player should have picked up 'Sword'");

            // Test that the item is no longer in the room after being picked up
            Debug.Assert(!testRoom.GetDescription().Contains("Sword"), "Test Failed: Sword should no longer be in the room");

            // Take the second item from the room (should be "Shield")
            string secondItem = testRoom.TakeItems()[0]; // Take the next item
            testPlayer.PickUpItem(secondItem);

            // Test that the player still only has the "Sword" (player's inventory can only hold one item)
            Debug.Assert(testPlayer.GetInventory() == "Sword", "Test Failed: Player should still only have 'Sword'");

            // Test that the room no longer contains the "Shield"
            Debug.Assert(!testRoom.GetDescription().Contains("Shield"), "Test Failed: Shield should no longer be in the room");

            // Indicate that all tests have passed
            Console.WriteLine("All tests passed!");
        }
    }
}
