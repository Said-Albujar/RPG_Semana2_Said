using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Semana2
{
    internal class RangeEnemy : Enemy
    {
        private int bullets;

        public RangeEnemy(int health, int damage, int bullets)
            : base(health, damage)
        {
            this.bullets = bullets;
        }

        public bool HasBullets()
        {
            return bullets > 0;
        }

       

        public int GetBullets()
        {
            return bullets;
        }

        public void ConsumeBullet()
        {
            if (bullets > 0)
            {
                bullets--;
            }
        }
    }
}
