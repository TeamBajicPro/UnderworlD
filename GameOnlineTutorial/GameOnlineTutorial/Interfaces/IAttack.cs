using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOnlineTutorial.Characters;

namespace GameOnlineTutorial.Interfaces
{
    public interface IAttack
    {
        int Damage { get;}
        void Attack(Character enemy);
    }
}
