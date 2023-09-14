using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Semana2
{
    internal class MeleeEnemy : Enemy
    {
        private int armor;

        public MeleeEnemy(int health, int damage, int armor)
            : base(health, damage)
        {
            this.armor = armor;
        }

        public override void Attack()
        {
            Console.WriteLine("Ataque del enemigo melee");
        }

        public int GetArmor()
        {
            return armor;
        }

        public int ReceiveDamageFromPlayer(int playerDamage)
        {
            int actualDamage = (playerDamage - armor);
            Health -= actualDamage;
            return Health;
        }
    }
}
