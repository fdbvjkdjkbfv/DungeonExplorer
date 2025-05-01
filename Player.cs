using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player : Creature
    {
        private List<string> inventory = new List<string>();
        public string DeathMessage;

        public Player(string name, int health, int damage, int armourClass, string deathMessage) : base(name, health, damage, armourClass)
        {
            DeathMessage = deathMessage;
        }
        public void PickUpItem(string item)
        {
            inventory.Add(item);
        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
        public override string SayDeathMessage()
        {
            return DeathMessage;
        }
    }
}   