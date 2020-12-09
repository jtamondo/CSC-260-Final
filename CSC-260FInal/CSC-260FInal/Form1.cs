using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC_260FInal
{
    public partial class Form1 : Form
    {
        You Your_character = new You("Billy");
        int init = 0;
        double insatnceHP;
        double enemyHP;
        int enemyChoose;
        double enemyAttck;
        int Qcheck = 0;
        bool Qcheck2 = true;
        double multiplier = 0;
        bool Qcheck3 = false;
        bool Qcheck4= false;
        List<string> tuturial = new List<string>()
            {
                 "Welcome to this horrible mini rpg click next to continue",
                 "Over here you have your hp if that goes to 0 you die",
                "This bar has your current objective","This is where you can face of against enemies beat the drone"

            };

        List<Quest> The_first_one = new List<Quest>();
        int enemyXP;
        public Form1()
        {

           
            InitializeComponent();
            LvlText.Visible = false;
            BattleText.Visible = false;
            EnemyHP.Visible = false;
            Attack.Visible = false;
            Tiger.Visible = false;
            Return.Visible = false;
            XpText.Visible = false;
            HP.Visible = false;
            Battle.Visible = false;
            BigTiger.Visible = false;
            drone.Visible = false;
            Amp.Visible = false;
            Defend.Visible = false;
            HP.Text = "HP:";
            Quest.Visible = false;
            RubberDuck.Visible = false;
            //Quests
            The_first_one.Add(new Quest() { Step = "Up top is your xp. Reach Level 2", XP = 20 });
            The_first_one.Add(new Quest() { Step = "Defeate a tiger", XP = 90 });
            The_first_one.Add(new Quest() { Step = "Reach level 5 a defeat the final boss of a big tiger" });
            The_first_one.Add(new Quest() { Step = "Defeat ???" });
            The_first_one.Add(new Quest() { Step = "Congradulations you beat the game" });
            //items


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            switch (init)
            {
                case 0:
                    Quest.Visible = true;
                    LvlText.Visible = true;
                    LvlText.Text = "Lvl:" + Your_character.level;
                    start.Text = "Next";
                    Quest.Text = tuturial[init];
                    init++;
                    break;
                case 1:
                    HP.Visible = true;
                    Quest.Text = tuturial[init];
                    HP.Text = "HP:" + Your_character.hp;
                    init++;
                    break;
                case 2:
                    Quest.Text = tuturial[init];
                    init++;
                    break;
                case 3:
                    Quest.Text = tuturial[init];
                    Battle.Visible = true;
                    start.Visible = false;
                    init++;
                    break;
                    
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (Your_character.level)
            {
                case 1:
                    Battle.Visible = false;
                    Return.Visible = true;
                    drone.Visible = true;
                    break;
                case 2:
                    Battle.Visible = false;
                    drone.Visible = true;
                    break;
            }
           
            
        }
      
        //drone battle
        private void button1_Click_1(object sender, EventArgs e)
        {
            Enemy Drone = new Enemy(Your_character.level, 1);
            insatnceHP = Your_character.hp;
            Attack.Visible = true;
            BigTiger.Visible = false;
            Amp.Visible = true;
            Defend.Visible = true;
            Tiger.Visible = false;
            start.Visible = false;
            Return.Visible = false;
                drone.Visible = false;
                BattleText.Visible = true;
                EnemyHP.Visible = true;
            enemyHP = Drone.hp;
            enemyAttck = Drone.attck;
            enemyXP = Drone.xp;
            EnemyHP.Text = "EnemyHP:" + Drone.hp;
        }

        private void Return_Click(object sender, EventArgs e)
        {
            Return.Visible = false;
            Battle.Visible = true;
            Tiger.Visible = false;
            drone.Visible = false;
        }

        private void EnemyHP_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void Attack_Click(object sender, EventArgs e)
        {
            enemyHP = enemyHP - (Your_character.attck + Your_character.attck *multiplier);
            EnemyHP.Text = "EnemyHP:" + enemyHP;
            if (enemyHP <= 0)
            {
                //Resets to original screen
                Attack.Visible = false;
                BattleText.Visible = false;
                EnemyHP.Visible = false;
                Return.Visible = true;
                Battle.Visible = true;
                Battle.Visible = false;
                Amp.Visible = false;
                drone.Visible = true;
                XpText.Visible = true;
                Your_character.xp = Your_character.xp + enemyXP;
                Your_character.Level_up();
            
                switch (Your_character.level)
                {
                    case 1:
                        Quest.Text = The_first_one[0].Step;
                        break;
                    case 2:
                        Your_character.xp = Your_character.xp + The_first_one[0].XP;
                        Quest.Text = The_first_one[1].Step;
                       
                        break;
                    case 5:
                        BigTiger.Visible = true;

                        break;
                }
                if(Your_character.level >= 2)
                {
                    Tiger.Visible = true;
                    if(Your_character.level >= 5)
                    {

                    }
                }
                if (Qcheck == 1 && Qcheck2 == true)
                {
                    Qcheck2 = false;
                    Your_character.xp = Your_character.xp + The_first_one[1].XP;
                    Quest.Text = The_first_one[2].Step;
                    Your_character.Level_up();
                }
                if(Qcheck3 == true )
                {
                    Quest.Text = The_first_one[3].Step;
                    RubberDuck.Visible = true;

                }

                LvlText.Text = "Lvl:" + Your_character.level;
                BattleText.Text = "";
                XpText.Text = "XP:" + Your_character.xp + "/" + Your_character.levels[Your_character.level - 1];
                HP.Text = "HP:" + Your_character.hp;
            }
            else if (insatnceHP <= 0)
            {
                Attack.Visible = false;
                BattleText.Visible = false;
                EnemyHP.Visible = false;
                Return.Visible = true;
                Battle.Visible = true;
                Battle.Visible = false;
                drone.Visible = true;
                XpText.Visible = true;
                insatnceHP = Your_character.hp;
                HP.Text = "HP:" + Your_character.hp;
            }
            else
            {
                insatnceHP = insatnceHP - enemyAttck;
                BattleText.Text = "The enemy attacked you with" + enemyAttck + " you have a remaining of" + Your_character.hp;
                HP.Text = "HP:" + insatnceHP;
            }
           
        }

        private void LvlText_TextChanged(object sender, EventArgs e)
        {

        }
        //tiger button
        private void button1_Click_2(object sender, EventArgs e)
        {
            Enemy Drone = new Enemy(Your_character.level, 2);
            Attack.Visible = true;
            Amp.Visible = true;
            BigTiger.Visible = false;
            RubberDuck.Visible = false;
            Defend.Visible = true;
            insatnceHP = Your_character.hp;
            start.Visible = false;
            Return.Visible = false;
            drone.Visible = false;
            Tiger.Visible = false;
            BattleText.Visible = true;
            EnemyHP.Visible = true;
            enemyHP = Drone.hp;
            enemyAttck = Drone.attck;
            enemyXP = Drone.xp;
            Qcheck = 1;
            EnemyHP.Text = "EnemyHP:" + Drone.hp;
        }
        //defend
        private void button1_Click_3(object sender, EventArgs e)
        {
            insatnceHP = insatnceHP - (enemyAttck * .5);
            HP.Text = "HP:" + insatnceHP;
            BattleText.Text = "The enemy attacked you with" + enemyAttck + " you have a remaining of" + insatnceHP;
        }
        //amp
        private void Amp_Click(object sender, EventArgs e)
        {
            multiplier += 0.05;
            insatnceHP = insatnceHP - enemyAttck;
            HP.Text = "HP:" + insatnceHP;
             BattleText.Text = "The enemy attacked you with" + enemyAttck + " you have a remaining of" + insatnceHP;
        }
        //big tiger
        private void button1_Click_4(object sender, EventArgs e)
        {
            Enemy Drone = new Enemy(Your_character.level, 3);
            insatnceHP = Your_character.hp;
            Attack.Visible = true;
            BigTiger.Visible = false;

            RubberDuck.Visible = false;
            Amp.Visible = true;
            Defend.Visible = true;
            Tiger.Visible = false;
            start.Visible = false;
            Return.Visible = false;
            drone.Visible = false;
            BattleText.Visible = true;
            EnemyHP.Visible = true;
            enemyHP = Drone.hp;
            enemyAttck = Drone.attck;
            enemyXP = Drone.xp;
            EnemyHP.Text = "EnemyHP:" + Drone.hp;
            Qcheck3 = true;
        }
        //rubber duck
        private void RubberDuck_Click(object sender, EventArgs e)
        {
            Enemy Drone = new Enemy();
            insatnceHP = Your_character.hp;
            Attack.Visible = true;
            BigTiger.Visible = false;
            RubberDuck.Visible = false;
            Amp.Visible = true;
            Defend.Visible = true;
            Tiger.Visible = false;
            start.Visible = false;
            Return.Visible = false;
            drone.Visible = false;
            BattleText.Visible = true;
            EnemyHP.Visible = true;
            enemyHP = Drone.hp;
            enemyAttck = Drone.attck;
            enemyXP = Drone.xp;
            EnemyHP.Text = "EnemyHP:" + Drone.hp;
            Qcheck4 = true;
        }
    }
}
