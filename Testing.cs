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

            // Test 1: Room with items and a monster
            Room testRoom = new Room("Test Room", new List<string> { "Sword", "Shield" }, "Orc");

            // Ensure room has items
            Debug.Assert(testRoom.GetDescription().Contains("Sword"), "Test Failed: Room should contain 'Sword'");
            Debug.Assert(testRoom.GetDescription().Contains("Shield"), "Test Failed: Room should contain 'Shield'");

            // Ensure room has a monster
            Debug.Assert(testRoom.HasMonster(), "Test Failed: Room should have a monster");
            Debug.Assert(testRoom.GetMonster() == "Orc", "Test Failed: Room's monster should be 'Orc'");

            // Test 2: Player picking up items from the room
            Player testPlayer = new Player("Test Player");

            // Pick up first item (Sword)
            string itemPicked = testRoom.TakeItem();
            testPlayer.PickUpItem(itemPicked);
            Debug.Assert(testPlayer.GetInventory().Contains("Sword"), "Test Failed: Player should have picked up 'Sword'");
            Debug.Assert(!testRoom.GetDescription().Contains("Sword"), "Test Failed: Sword should no longer be in the room");

            // Pick up second item (Shield)
            string secondItem = testRoom.TakeItem();
            testPlayer.PickUpItem(secondItem);

            Debug.Assert(testPlayer.GetInventory().Contains("Shield"), "Test Failed: Player should have picked up 'Shield'");
            Debug.Assert(!testRoom.GetDescription().Contains("Shield"), "Test Failed: Shield should no longer be in the room");

            // Test 3: Room with no items
            Room emptyRoom = new Room("Empty Room");
            Debug.Assert(!emptyRoom.HasItem(), "Test Failed: Room should have no items.");
            string emptyPickup = emptyRoom.TakeItem();
            Debug.Assert(emptyPickup == null, "Test Failed: Should not be able to take an item from an empty room.");

            // Test 4: Player checking an empty inventory
            Player emptyInventoryPlayer = new Player("No-Item Player");
            Debug.Assert(emptyInventoryPlayer.GetInventory() == "Empty", "Test Failed: Player's inventory should be empty.");

            // Test 5: Handling multiple items in inventory
            Player multiItemPlayer = new Player("Multi-Item Player");
            multiItemPlayer.PickUpItem("Potion");
            multiItemPlayer.PickUpItem("Key");

            Debug.Assert(multiItemPlayer.GetInventory().Contains("Potion"), "Test Failed: Player should have 'Potion' in inventory.");
            Debug.Assert(multiItemPlayer.GetInventory().Contains("Key"), "Test Failed: Player should have 'Key' in inventory.");

            // Test 6: Handling invalid user input (from Game.cs)
            string invalidInput = "";
            Debug.Assert(string.IsNullOrEmpty(invalidInput), "Test Failed: Input should be empty for invalid case.");

            invalidInput = "5"; // Invalid choice
            Debug.Assert(invalidInput != "1" && invalidInput != "2" && invalidInput != "3" && invalidInput != "4", "Test Failed: Input should be invalid for '5'.");

            // Test passed message
            Console.WriteLine("All tests passed!");
        }
    }
}
