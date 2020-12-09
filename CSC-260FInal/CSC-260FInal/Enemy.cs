using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC_260FInal
{
    class Enemy : Character
    {
        public Enemy(int level, int EnemyNum)
        {
            switch (EnemyNum)
            {
                case 1:
                    this.name = "Drone";
                    this.hp = 20 * level;
                    this.attck = 5 * level;
                    this.xp = 5 * level;
                    this.spd = 1;
                    break;
                case 2:
                    this.name = "Tiger";
                    this.xp = 20 * level;
                    this.hp = 50 * (level-1);
                    this.spd = 4;
                    this.attck = 10 * level;
                    break;
                case 3:
                    this.name = "Big tiger";
                    this.xp = 500;
                    this.hp = 300;
                    this.attck = 20;

                    break;
            }
            
        }
        public Enemy()
        {
            this.name = "Rubber Duck";
            this.hp = 10000000;
        }
    }
}
