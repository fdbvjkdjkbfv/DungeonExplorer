using System;
namespace DungeonExplorer
{
    public class Monster : Creature
    {
        public int AttackBonus;
        public string DeathMessage;

        public Monster(string name, int health, int damage, int armourClass, int attackBonus, string deathMessage) : base(name, health, damage, armourClass) 
        {
            AttackBonus = attackBonus;
            DeathMessage = deathMessage;
        }
        public int GetAttackBonus()
        {
            return AttackBonus;
        }
        public override string SayDeathMessage()
        {
            return DeathMessage;
        }
    }
}