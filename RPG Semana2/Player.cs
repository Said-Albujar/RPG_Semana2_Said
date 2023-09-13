using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Semana2
{
     class Player
    {
        private int life;
        private int damage;

        public Player(int life, int damage)
        {
            if (life <= 0 || damage <= 0 || life > 100 || damage > 100)
            {
                throw new ArgumentException("Los valores de vida y daño del jugador deben estar entre 1 y 100.");
            }

            this.life = life;
            this.damage = damage;
        }

        public int ReceiveDamage(int damage)
        {
            life -= damage;
            return life;
        }

        public int GetDamage()
        {
            return damage;
        }
        public int GetLife()
        {
            return life;
        }

        public bool IsAlive()
        {
            return life > 0;
        }
    }
}
