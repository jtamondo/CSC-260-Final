using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC_260FInal
{
    class You : Character
    {
        public You(string val)
        {
            this.name = val;
            this.level = 1;
            this.hp = 40 * level;
            this.xp = 0;
            this.attck = 10;
            this.spd = 5;
        }
        public List<int> levels = new List<int>
        {
            10,80,120,200,50000000
        };
       
        public int get_xp()
        {
            return this.xp;
        }
        public void Level_up()
        {
            if (this.xp >= this.levels[this.level - 1] && this.level != 5)
            {
                this.xp = this.xp - this.levels[this.level - 1];
                this.hp += 50;
                this.attck += 10;
                this.level++;
            }
            
        }


    }
}
