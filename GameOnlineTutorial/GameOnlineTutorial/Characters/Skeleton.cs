using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOnlineTutorial.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace GameOnlineTutorial.Characters
{
    public class Skeleton : Character
    {
        private const string SkeletonName = "Gosho";
        private const int SkeletonDamage = 20;
        private const int SkeletonHealth = 50;

        public Skeleton(Texture2D texture) 
            : base(SkeletonName, SkeletonDamage, SkeletonHealth, texture)
        {
        }
    }
}
