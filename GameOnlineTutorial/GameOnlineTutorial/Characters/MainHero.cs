using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOnlineTutorial.Interfaces;
using UnderworlD.Item;

namespace GameOnlineTutorial.Characters
{
    public class MainHero : IPlayer
    {
        public int Damage { get; }

        public void Attack(Character enemy)
        {
            throw new NotImplementedException();
        }

        public int Health { get; }
        public string Name { get; }
        public IEnumerable<Item> Inventory { get; }

        public void AddItemToInventory(Item item)
        {
            throw new NotImplementedException();
        }

        public void Heal()
        {
            throw new NotImplementedException();
        }


        public int Experience { get; set; }

        public void LevelUp()
        {
            throw new NotImplementedException();
        }
    }
}
