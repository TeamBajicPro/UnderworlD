using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOnlineTutorial.Interfaces
{
    public interface ICharacter : IAttack, IDestroyable
    {
        string Name { get; }
        
    }
}
