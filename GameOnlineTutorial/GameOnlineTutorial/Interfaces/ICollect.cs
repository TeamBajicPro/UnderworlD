using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnderworlD.Item;

namespace GameOnlineTutorial.Content
{
    public interface ICollect
    {
        IEnumerable<Item> Inventory { get; }

        void AddItemToInventory(Item item);

    }
}
