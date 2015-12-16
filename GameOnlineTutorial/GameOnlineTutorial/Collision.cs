using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace GameOnlineTutorial
{
    public class Collision : Game
    {
        
        public bool Collide(Vector2 mainCharPosition, int mainCharCollisionRectOffSet, Point mainCharFrameSize, Vector2 enemy1Position, int enemy1CollisionRectOffSet, Point enemy1FrameSize)
        { 
        Rectangle mainChar = new Rectangle(
                (int)mainCharPosition.X + mainCharCollisionRectOffSet,
                (int)mainCharPosition.Y + mainCharCollisionRectOffSet,
                mainCharFrameSize.X - (mainCharCollisionRectOffSet * 2),
                mainCharFrameSize.Y - (mainCharCollisionRectOffSet * 2));

        Rectangle enemy1 = new Rectangle(
            (int)enemy1Position.X + enemy1CollisionRectOffSet,
            (int)enemy1Position.Y + enemy1CollisionRectOffSet,
            enemy1FrameSize.X - (enemy1CollisionRectOffSet * 2),
            enemy1FrameSize.Y - (enemy1CollisionRectOffSet * 2));

        return mainChar.Intersects(enemy1);
        }

    }
}
