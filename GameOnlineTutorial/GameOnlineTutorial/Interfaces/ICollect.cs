using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOnlineTutorial.Interfaces;
using UnderworlD.Item;

namespace GameOnlineTutorial.Content
{
    public interface ICollect
    {
        IEnumerable<IItem> Inventory { get; }

        void AddItemToInventory(IItem item);

    }
}
