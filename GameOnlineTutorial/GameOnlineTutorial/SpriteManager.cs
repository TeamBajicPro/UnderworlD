//using System;
//using System.Collections.Generic;
//using GameOnlineTutorial;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;

//namespace GameOnlineTutorial
//{
//    public partial class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
//    {
//        SpriteBatch spriteBatch;
//        UserControlledSprite player;
//        List<Sprite> spriteList = new List<Sprite>();
//        private AnimatedSprite animatedSprite;

//        public SpriteManager(Game game) : base(game)
//        {

//        }

//        public override void Initialize()
//        {
//            base.Initialize();
//        }

//        protected override void LoadContent()
//        {
//            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
//            Texture2D texture = Game.Content.Load<Texture2D>("MainChar");
            
//            //player sprite
//            player = new UserControlledSprite(Game.Content.Load<Texture2D>("MainChar"),
//                Vector2.Zero, new Point(75,75), 10, new Point(0,0), 
//                new Point(6,8), new Vector2(6,6));
            
//            //enemy sprites
//            spriteList.Add(
//                new AutomatedSprite(Game.Content.Load<Texture2D>("enemy1"),
//                new Vector2(150,150), new Point(75,75),
//                10, new Point(0,0),
//                new Point(6,8), Vector2.Zero));
            
            
//            spriteList.Add(
//               new AutomatedSprite(Game.Content.Load<Texture2D>("enemy1"),
//               new Vector2(150, 300), new Point(75, 75),
//               10, new Point(0, 0),
//               new Point(6, 8), Vector2.Zero));

//            spriteList.Add(
//               new AutomatedSprite(Game.Content.Load<Texture2D>("enemy1"),
//               new Vector2(300, 150), new Point(75, 75),
//               10, new Point(0, 0),
//               new Point(6, 8), Vector2.Zero));

//            spriteList.Add(
//               new AutomatedSprite(Game.Content.Load<Texture2D>("enemy1"),
//               new Vector2(150, 150), new Point(75, 75),
//               10, new Point(0, 0),
//               new Point(400, 500), Vector2.Zero));

//            base.LoadContent();
//        }

//        public override void Update(GameTime gameTime)
//        {
//            player.Update(gameTime, Game.Window.ClientBounds);
//            foreach (Sprite s in spriteList)
//            {
//                if (s.collisionRect.Intersects(player.collisionRect))
//                {
//                    Game.Exit();
//                }
//            }
//            base.Update(gameTime);
//        }

//        public override void Draw(GameTime gameTime)
//        {
//            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
//            player.Draw(gameTime, spriteBatch);

//            foreach (Sprite s in spriteList)
//            {
//                s.Draw(gameTime, spriteBatch);
//            }

//            spriteBatch.End();

//            base.Draw(gameTime);
//        }
//    }
//}
