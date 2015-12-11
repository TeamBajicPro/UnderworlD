using System;
using GameOnlineTutorial.Interfaces;

namespace GameOnlineTutorial.Characters
{
    public abstract class Character : ICharacter
    {
        public string Name { get; }
        public int Damage { get; }
        

        public int Health { get; }


        public void Attack(Character enemy)
        {
            throw new NotImplementedException();
        }

    }
}
