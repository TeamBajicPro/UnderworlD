using System;
using GameOnlineTutorial;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameOnlineTutorial
{
    public class UserControlledSprite : Sprite
    {
        MouseState previousMouseState;

        public UserControlledSprite(Texture2D textureImage, Vector2 position,
            Point frameSize, int collisionOffSet, Point currentFrame, Point sheetSize, Vector2 speed) 
            : base(textureImage, position, frameSize, collisionOffSet, currentFrame, sheetSize, speed)
        {
        }

        public UserControlledSprite(Texture2D textureImage, Vector2 position, 
            Point frameSize, int collisionOffSet, Point currentFrame, Point sheetSize, Vector2 speed, int milisecondsPerFrame) 
            : base(textureImage, position, frameSize, collisionOffSet, currentFrame, sheetSize, speed, milisecondsPerFrame)
        {
        }

        public override Vector2 direction
        {
            get
            {
                Vector2 inputDirection = Vector2.Zero;
                KeyboardState keyboard = Keyboard.GetState();

                if (keyboard.IsKeyDown(Keys.Left))
                {
                    inputDirection.X -= 1;
                }

                if (keyboard.IsKeyDown(Keys.Right))
                {
                    inputDirection.X += 1;
                }
                if (keyboard.IsKeyDown(Keys.Up))
                {
                    inputDirection.Y -= 1;
                }
                if (keyboard.IsKeyDown(Keys.Down))
                {
                    inputDirection.Y += 1;
                }
                return inputDirection*speed;
            }
         }


        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            position += direction;
            MouseState currentMouseState = Mouse.GetState();

            if (currentMouseState.X != previousMouseState.X || currentMouseState.Y != previousMouseState.Y)
            {
                position = new Vector2(currentMouseState.X, currentMouseState.Y);
            }

            previousMouseState = currentMouseState;
            
            //if sprite moves off screen

            if (position.X <0)
            {
                position.X = 0;
            }
            
            if (position.Y < 0)
            {
                position.Y = 0;
            }

            if (position.X > clientBounds.Width - frameSize.X)
            {
                position.X = clientBounds.Width - frameSize.X;
            }

            if (position.Y > clientBounds.Height - frameSize.Y)
            {
                position.Y = clientBounds.Height - frameSize.Y;
            }

        }
    }
}
