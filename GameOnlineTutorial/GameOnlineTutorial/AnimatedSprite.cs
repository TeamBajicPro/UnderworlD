using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameOnlineTutorial
{
    public abstract class AnimatedSprite
    {
        public enum myDirection { none, left, right, up, down };
        protected myDirection currentDir = myDirection.none;
        protected Texture2D sTexture;
        protected Vector2 sPostion;
        private int frameIndex;
        private double timeElapsed;
        private double timeToUpdate;
        protected string currentAnimation;
        protected Vector2 sDirection = Vector2.Zero;

        public int FramesPerSecond
        {
            set { timeToUpdate = (1f / value); }
        }

        // Dictionary that contains all animations
        private Dictionary<string, Rectangle[]> sAnimations = new Dictionary<string, Rectangle[]>();
        
        private Dictionary<string, Vector2> sOffsets = new Dictionary<string, Vector2>();
        
        protected AnimatedSprite(Vector2 position)
        {
            sPostion = position;
        }


        // Adds an animation to the AnimatedSprite

        public void AddAnimation(int frames, int yPos, int xStartFrame, string name, int width, int height, Vector2 offset)
        {

            //Creates an array of rectangles which will be used when playing an animation
            Rectangle[] Rectangles = new Rectangle[frames];

            //Fills up the array of rectangles
            for (int i = 0; i < frames; i++)
            {
                Rectangles[i] = new Rectangle((i + xStartFrame) * width, yPos, width, height);
            }
            sAnimations.Add(name, Rectangles);
            sOffsets.Add(name, offset);
        }


        // Determines when we have to change frames

        public virtual void Update(GameTime gameTime)
        {
            //Adds time that has elapsed since our last draw
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;

            //We need to change our image if our timeElapsed is greater than our timeToUpdate(calculated by our framerate)
            if (timeElapsed > timeToUpdate)
            {
                //Resets the timer in a way, so that we keep our desired FPS
                timeElapsed -= timeToUpdate;

                //Adds one to our frameIndex
                if (frameIndex < sAnimations[currentAnimation].Length - 1)
                {
                    frameIndex++;
                }
                else //Restarts the animation
                {
                    AnimationDone(currentAnimation);
                    frameIndex = 0;
                }
            }
        }

        // Draws the sprite on the screen

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sTexture, sPostion + sOffsets[currentAnimation], sAnimations[currentAnimation][frameIndex], Color.White);

        }

        // Plays an animation

        public void PlayAnimation(string name)
        {
            //Makes sure we won't start a new annimation unless it differs from our current animation
            if (currentAnimation != name && currentDir == myDirection.none)
            {
                currentAnimation = name;
                frameIndex = 0;
            }
        }
        // Method that is called every time an animation finishes
        public abstract void AnimationDone(string animation);
    }
}

