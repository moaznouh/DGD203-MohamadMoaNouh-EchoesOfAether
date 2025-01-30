using System.Collections.Generic;

namespace TextAdventureGame
{
    class Player
    {
        private List<Item> inventory;

        public Player()
        {
            inventory = new List<Item>();
        }

        public void AddItem(Item item)
        {
            inventory.Add(item);
        }

        public bool HasItem(string itemName)
        {
            return inventory.Exists(item => item.Name == itemName);
        }
    }
}