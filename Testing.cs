using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DungeonExplorer
{
    public class Testing
    {
        public static void RunTests()
        {
            Console.WriteLine("Running tests...");

            Room testRoom = new Room("Test Room", new List<string> { "Sword", "Shield" }, "Orc");

            Debug.Assert(testRoom.GetDescription().Contains("Sword"), "Test Failed: Room should contain 'Sword'");
            Debug.Assert(testRoom.GetDescription().Contains("Shield"), "Test Failed: Room should contain 'Shield'");
            Debug.Assert(testRoom.HasMonster(), "Test Failed: Room should have a monster");
            Debug.Assert(testRoom.GetMonster() == "Orc", "Test Failed: Room's monster should be 'Orc'");

            Player testPlayer = new Player("Test Player");

            string itemPicked = testRoom.TakeItem();
            testPlayer.PickUpItem(itemPicked);

            Debug.Assert(testPlayer.GetInventory().Contains("Sword"), "Test Failed: Player should have picked up 'Sword'");
            Debug.Assert(!testRoom.GetDescription().Contains("Sword"), "Test Failed: Sword should no longer be in the room");

            string secondItem = testRoom.TakeItem();
            testPlayer.PickUpItem(secondItem);

            Debug.Assert(testPlayer.GetInventory() == "Sword", "Test Failed: Player should still only have 'Sword'");

            Console.WriteLine("All tests passed!");
        }
    }
}
