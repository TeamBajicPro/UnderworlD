using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOnlineTutorial.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameOnlineTutorial.Characters
{
    public class Elf : Enemy
    {
        public Elf(Texture2D texture, Rectangle form, int health, int damage)
            : base(texture, form, health, damage)
        {
        }
    }
}
