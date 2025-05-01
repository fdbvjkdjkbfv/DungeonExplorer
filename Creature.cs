using System;
namespace DungeonExplorer
{
    public abstract class Creature
    {
        public string Name;
        public int Health;
        public int Damage;
        public int ArmourClass;

        public Creature(string name, int health, int damage, int armourClass)
        {
            Name = name;
            Health = health;
            Damage = damage;
            ArmourClass = armourClass;
        }
        public string GetName()
        {
            return Name;
        }
        public int GetHealth()
        {
            return Health;
        }
        public int GetDamage()
        {
            return Damage;
        }
        public int GetAC()
        {
            return ArmourClass;
        }
        public void SetHealth(int value)
        {
            Health = value;
        }
        public abstract string SayDeathMessage();
    }
}
