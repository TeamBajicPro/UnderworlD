using GameOnlineTutorial;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameOnlineTutorial
{
    public class AutomatedSprite : Sprite
    {
        public AutomatedSprite(Texture2D textureImage, Vector2 position,
            Point frameSize, int collisionOffSet, Point currentFrame, Point sheetSize, Vector2 speed)
            : base(textureImage, position, frameSize, collisionOffSet, currentFrame, sheetSize, speed)
        {
        }

        public AutomatedSprite(Texture2D textureImage, Vector2 position, 
            Point frameSize, int collisionOffSet, Point currentFrame, Point sheetSize, 
            Vector2 speed, int milisecondsPerFrame)
            : base(textureImage, position, frameSize, collisionOffSet, currentFrame, sheetSize, speed, milisecondsPerFrame)
        {
        }

        public override Vector2 direction
        {
            get { return speed; }
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            position += direction;
            base.Update(gameTime, clientBounds);
        }
    }
}
