using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOnlineTutorial.Characters;

namespace GameOnlineTutorial.Interfaces
{
    public interface IAttack
    {
        void Attack(Player player, Enemy enemy);
    }
}
