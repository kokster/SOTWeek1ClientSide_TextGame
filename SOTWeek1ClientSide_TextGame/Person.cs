using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOTWeek1ClientSide_TextGame
{
    class Person
    {
        private string name;
        private int health;
        private int location;
        private int attackPoints;

        public Person(string name, int health, int location, int attackPoints)
        {
            this.name = name;
            this.health = health;
            this.location = location;
            this.attackPoints = attackPoints;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int Location
        {
            get { return location; }
            set { location = value; }
        }

        public int AttackPoints
        {
            get { return attackPoints; }
            set { attackPoints = value; }
        }
    }
}
