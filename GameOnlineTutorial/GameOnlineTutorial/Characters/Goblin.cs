using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOnlineTutorial.Interfaces;

namespace GameOnlineTutorial.Characters
{
    public class Goblin : Character
    {
        public int Damage { get; }
        public void Attack(Character enemy)
        {
            throw new NotImplementedException();
        }

        public int Health { get; }
        public string Name { get; }
    }
}
