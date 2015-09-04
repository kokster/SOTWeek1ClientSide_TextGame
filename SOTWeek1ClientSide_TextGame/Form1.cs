using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SOTWeek1ClientSide_TextGame.DungeonGame;

namespace SOTWeek1ClientSide_TextGame
{
    public partial class Form1 : Form
    {
        Monster monster;
        Person person;
        Fight fight;
        private DungeonGame.SimpleDungeonClient client;

        private int[] currentPotentialPos;

        public List<DungeonGame.enemy> deadEnemies; 

        public Form1()
        {
            
            InitializeComponent();
            monster = new Monster(5, 1, "Dragondude");
            person = new Person("koko", 5, 0, 1);
            client = new DungeonGame.SimpleDungeonClient();
            currentPotentialPos = new int[4];
            deadEnemies = new List<enemy>();
            //richTextBox1.Text += Environment.NewLine + (client.move(0));
            // start at 0 pos
            move(0);
            
        }


        private void move(int nextPos)
        {
            if (person.Location != 10)
            {
                String direction = client.move(nextPos);

                string[] directionStrings = direction.Substring(1, direction.Length - 2).Split(',');

                for (int i = 0; i < directionStrings.Length; i++)
                {
                    currentPotentialPos[i] = Convert.ToInt32(directionStrings[i]);
                    Console.WriteLine("We can go to:" + directionStrings[i]);
                }
                // TOP BOTTOM RIGHT LEFT
                button3.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;

                if (Convert.ToInt32(directionStrings[0]) != -1)
                {
                    button1.Enabled = true;
                }
                if (Convert.ToInt32(directionStrings[1]) != -1)
                {
                    button3.Enabled = true;
                }
                if (Convert.ToInt32(directionStrings[2]) != -1)
                {
                    button2.Enabled = true;
                }
                if (Convert.ToInt32(directionStrings[3]) != -1)
                {
                    button4.Enabled = true;
                }

                Console.WriteLine("We are at:" + person.Location);
                richTextBox1.Text += Environment.NewLine + client.getStory(person.Location);

                try
                {
                    enemy enemy = client.isEnemy(person.Location);
                    if (enemy != null && !deadEnemies.Contains(enemy))
                    {
                        button5.Enabled = true;
                        button3.Enabled = false;
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button4.Enabled = false;
                        fight = new Fight(person, enemy, this);
                    }
                    
                    Console.WriteLine(enemy.name.ToString());
                    
                    
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show("You found the treasure");
            }
        }

        public void interfaceAfterBattle()
        {
            button3.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

            if (Convert.ToInt32(currentPotentialPos[0]) != -1)
            {
                button1.Enabled = true;
            }
            if (Convert.ToInt32(currentPotentialPos[1]) != -1)
            {
                button3.Enabled = true;
            }
            if (Convert.ToInt32(currentPotentialPos[2]) != -1)
            {
                button2.Enabled = true;
            }
            if (Convert.ToInt32(currentPotentialPos[3]) != -1)
            {
                button4.Enabled = true;
            }
        }

        public void gameOver()
        {
            MessageBox.Show("Sorry, the enemy killed you.");
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fight.turn();
            richTextBox1.Text += Environment.NewLine + fight.Status;   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            person.Location = currentPotentialPos[0];
            move(person.Location);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            person.Location = currentPotentialPos[3];
            move(person.Location);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            person.Location = currentPotentialPos[1];
            move(person.Location);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            person.Location = currentPotentialPos[2];
            move(person.Location);
        }
    }
}
