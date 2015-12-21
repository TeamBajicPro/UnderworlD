using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOnlineTutorial.Interfaces
{
    public interface IItem
    {
        string itemName { get; }
        int healingEffect {get;} // potion gives a flat and instant increase, ex + 200 hp
        int permenentDmgBoost { get; }// items that give a small amount of damage, permenently , ex + 5dmg
        int permenentDefBoost { get; } // items that give a small amount of defense, permenently, ex + 10 def
        int permenentHealthBoost { get; } // items that give a small amount of healrth, permenently, ex + 10hp
    }
}
