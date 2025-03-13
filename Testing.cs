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

            // Test 1
            Room testRoom = new Room("Test Room", new List<string> { "Sword", "Shield" }, "Orc");
            Debug.Assert(testRoom.GetDescription().Contains("Sword"), "Test Failed: Room should contain 'Sword'");
            Debug.Assert(testRoom.GetDescription().Contains("Shield"), "Test Failed: Room should contain 'Shield'");
            Debug.Assert(testRoom.HasMonster(), "Test Failed: Room should have a monster");
            Debug.Assert(testRoom.GetMonster() == "Orc", "Test Failed: Room's monster should be 'Orc'");

            // Test 2
            Player testPlayer = new Player("Test Player");
            string itemPicked = testRoom.TakeItem();
            testPlayer.PickUpItem(itemPicked);
            Debug.Assert(testPlayer.GetInventory().Contains("Sword"), "Test Failed: Player should have picked up 'Sword'");
            Debug.Assert(!testRoom.GetDescription().Contains("Sword"), "Test Failed: Sword should no longer be in the room");

            // Test 3
            string secondItem = testRoom.TakeItem();
            testPlayer.PickUpItem(secondItem);
            Debug.Assert(testPlayer.GetInventory() == "Sword", "Test Failed: Player should still only have 'Sword'");

            // Test 
            Room emptyRoom = new Room("Empty Room");
            Debug.Assert(!emptyRoom.HasItem(), "Test Failed: Room should have no items.");
            string emptyPickup = emptyRoom.TakeItem();
            Debug.Assert(emptyPickup == null, "Test Failed: Should not be able to take an item from an empty room.");

            // Test 5
            Player emptyInventoryPlayer = new Player("No-Item Player");
            Debug.Assert(emptyInventoryPlayer.GetInventory() == "Empty", "Test Failed: Player's inventory should be empty.");

            // Test 6
            Player singleItemPlayer = new Player("Single-Item Player");
            singleItemPlayer.PickUpItem("Potion");
            singleItemPlayer.PickUpItem("Key");
            Debug.Assert(singleItemPlayer.GetInventory() == "Potion", "Test Failed: Player should still only have 'Potion'.");

            // Test 7
            string invalidInput = "";
            Debug.Assert(string.IsNullOrEmpty(invalidInput), "Test Failed: Input should be empty for invalid case.");
            invalidInput = "5";
            Debug.Assert(invalidInput != "1" && invalidInput != "2" && invalidInput != "3" && invalidInput != "4", "Test Failed: Input should be invalid for '5'.");

            // Test passed message
            Console.WriteLine("All tests passed!");
        }
    }
}
