using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOnlineTutorial.Content;

namespace GameOnlineTutorial.Interfaces
{
    public interface IPlayer : ICharacter, ICollect, IHeal, IExperience
    {
        void FuckYes();
        void Eat();
    }
}
