using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOTWeek1ClientSide_TextGame
{
    class Monster
    {
        private int health;
        private int attackPoints;
        private string name;

        public Monster(int health, int attackPoints, string name)
        {
            this.health = health;
            this.attackPoints = attackPoints;
            this.name = name;
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int AttackPoints
        {
            get { return attackPoints; }
            set { attackPoints = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
