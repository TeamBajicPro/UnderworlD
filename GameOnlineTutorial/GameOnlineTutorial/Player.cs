using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using GameOnlineTutorial.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using UnderworlD.Item;

namespace GameOnlineTutorial
{
    public class Player : AnimatedSprite, IPlayer
    {
        float mySpeed = 100;
        bool attacking = false;
        private int health;
        private int damage;
        
        public Player(Vector2 position, int health, int damage, int experience) : base(position)
        {
            FramesPerSecond = 10;
            AddAnimation(12, 0, 0, "Down", 50, 50, new Vector2(0, 0));
            AddAnimation(1, 0, 0, "IdleDown", 50, 50, new Vector2(0, 0));
            AddAnimation(12, 50, 0, "Up", 50, 50, new Vector2(0, 0));
            AddAnimation(1, 50, 0, "IdleUp", 50, 50, new Vector2(0, 0));
            AddAnimation(8, 100, 0, "Left", 50, 50, new Vector2(0, 0));
            AddAnimation(1, 100, 0, "IdleLeft", 50, 50, new Vector2(0, 0));
            AddAnimation(8, 100, 8, "Right", 50, 50, new Vector2(0, 0));
            AddAnimation(1, 100, 8, "IdleRight", 50, 50, new Vector2(0, 0));
            AddAnimation(9, 150, 0, "AttackDown", 70, 80, new Vector2(0, 0));
            AddAnimation(9, 230, 0, "AttackUp", 70, 80, new Vector2(-13, -27));
            AddAnimation(9, 310, 0, "AttackLeft", 70, 70, new Vector2(-30, -5));
            AddAnimation(9, 380, 0, "AttackRight", 70, 70, new Vector2(+15, -5));
            this.Health = health;
            this.Damage = damage;
            this.Experience = experience;
            //starting animation
            PlayAnimation("IdleUp");
        }
        

        public int Health {
            get { return this.health; }
            set {
            if (value < 0)
            {
                throw new ArgumentException("Health cannot be negative");
            }
            this.health = value;
        }
        }
        
        public int Damage
        {
            get { return this.damage; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Damage cannot be negative");
                }
                this.damage = value;
            }
        }
        
        public void LoadContent(ContentManager content)
        {
            sTexture = content.Load<Texture2D>("playerSheet");
        }

        public override void Update(GameTime gameTime)
        {
            //Makes the player stop moving when no key is pressed
            sDirection = Vector2.Zero;

            //Handles the users input
            HandleInput(Keyboard.GetState());

            //Calculates how many seconds that has passed since last iteration of Update
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Applies our speed to our direction
            sDirection *= mySpeed;

            //Makes the movement framerate independent by multiplying with deltaTime
            sPostion += (sDirection * deltaTime);

            base.Update(gameTime);
        }

        private void HandleInput(KeyboardState keyState)
        {
            if (!attacking)
            {
                if (keyState.IsKeyDown(Keys.W))
                {
                    //Move char Up
                    sDirection += new Vector2(0, -1);
                    PlayAnimation("Up");
                    currentDir = myDirection.up;

                }
                if (keyState.IsKeyDown(Keys.A))
                {
                    //Move char Left
                    sDirection += new Vector2(-1, 0);
                    PlayAnimation("Left");
                    currentDir = myDirection.left;

                }
                if (keyState.IsKeyDown(Keys.S))
                {
                    //Move char Down
                    sDirection += new Vector2(0, 1);
                    PlayAnimation("Down");
                    currentDir = myDirection.down;

                }
                if (keyState.IsKeyDown(Keys.D))
                {
                    //Move char Right
                    sDirection += new Vector2(1, 0);
                    PlayAnimation("Right");
                    currentDir = myDirection.right;

                }
            }
            if (keyState.IsKeyDown(Keys.Space))
            {
                if (currentAnimation.Contains("Down"))
                {
                    PlayAnimation("AttackDown");
                    attacking = true;
                    currentDir = myDirection.down;
                }
                if (currentAnimation.Contains("Left"))
                {
                    PlayAnimation("AttackLeft");
                    attacking = true;
                    currentDir = myDirection.left;
                }
                if (currentAnimation.Contains("Right"))
                {
                    PlayAnimation("AttackRight");
                    attacking = true;
                    currentDir = myDirection.right;
                }
                if (currentAnimation.Contains("Up"))
                {
                    PlayAnimation("AttackUp");
                    attacking = true;
                    currentDir = myDirection.up;
                }
            }
            else if (!attacking)
            {
                if (currentAnimation.Contains("Left"))
                {
                    PlayAnimation("IdleLeft");
                }
                if (currentAnimation.Contains("Right"))
                {
                    PlayAnimation("IdleRight");
                }
                if (currentAnimation.Contains("Up"))
                {
                    PlayAnimation("IdleUp");
                }
                if (currentAnimation.Contains("Down"))
                {
                    PlayAnimation("IdleDown");
                }
            }
            currentDir = myDirection.none;

        }

        public override void AnimationDone(string animation)
        {
            if (animation.Contains("Attack"))
            {
                attacking = false;
            }
        }

        public IEnumerable<IItem> Inventory { get; }

        public void AddItemToInventory(IItem item)
        {
            throw new NotImplementedException();
        }
        

        public void Heal(IItem item)
        {
            this.Health += item.healingEffect;
        }

        public int Experience { get; set; }

        public void LevelUp()
        {
            this.Experience++;
        }
    }
}
