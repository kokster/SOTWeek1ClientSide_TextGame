using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOTWeek1ClientSide_TextGame
{
    class Fight
    {
        private Form1 form;
        private Person person;
        private string status;
        private DungeonGame.enemy enemy;


         
        public Fight(Person person, DungeonGame.enemy enemy, Form1 form)
        {
            this.person = person;
            this.enemy = enemy;
            this.form = form;
        }

        //public Monster Monster
        //{
        //    get { return monster; }
        //    set { monster = value; }
        //}

            public DungeonGame.enemy Enemy
        {
            get { return enemy; }
            set { enemy = value; }
        }

        public string Status
        {
            get { return status; }
        }
        public Person Person
        {
            get { return person; }
            set {  person = value; }
        }

        bool playerTurn = true;
        public void turn()
        {
            if (person.Health > 0 && enemy.getLifePoints > 0) 
            {
                Random rnd = new Random();
                if (playerTurn)
                {
                    int doesPlayerHit = rnd.Next(1, 7);
                    if (doesPlayerHit > 2)
                    {
                        enemy.getLifePoints -= person.AttackPoints;
                        status = "player hits monster for " + person.AttackPoints + "! Monster is left with " + enemy.getLifePoints + " health!";
                        if (enemy.getLifePoints <= 0)
                        {
                            status = "The monster dies!";
                            person.AttackPoints++;
                            person.Health++;
                            form.deadEnemies.Add(this.enemy);
                            endBattle(true);
                        }
                    }
                    else
                    {
                        status = "Player tries to hit but misses!";
                    }
                    playerTurn = false;
                }
                else
                {
                    int doesMonsterHit = rnd.Next(1, 7);
                    if (doesMonsterHit > 2)
                    {
                        person.Health -= enemy.getAttackPoints;
                        status = "monster hits players for " + enemy.getAttackPoints + "! Player is left with " + person.Health + " health!";
                        if (person.Health <= 0)
                        {
                            status = "Player dies!";
                            endBattle(false);
                        }
                    }
                    else
                    {
                        status = "Monster tries to hit but misses!";
                    }
                    playerTurn = true;
                }

            }
            else
            {
                status = "One of the opponents is dead";
            }
        }


        void endBattle(bool isCharacterAlive)
        {
            if (isCharacterAlive)
            {
                form.interfaceAfterBattle();
            } else
            {
                form.gameOver();
            }

            
        }

        

    }
}
