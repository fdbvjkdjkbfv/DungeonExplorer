using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public static string Name { get; private set; }
        public  static int Health { get; private set; }
        public static int Damage { get; private set; }

        private List<string> inventory = new List<string>();

        public Player(string name, int health, int damage) 
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        public void PickUpItem(string item)
        {
            inventory.Add(item);
        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}   