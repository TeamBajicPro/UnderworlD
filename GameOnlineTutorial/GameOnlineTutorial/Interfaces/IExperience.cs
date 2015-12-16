using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOnlineTutorial.Interfaces
{
    public interface IExperience
    {
        int Experience { get; set; }

        void LevelUp();
    }
}
