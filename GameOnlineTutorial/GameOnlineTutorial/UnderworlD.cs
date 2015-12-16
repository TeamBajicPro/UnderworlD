using System.Security.Cryptography.X509Certificates;
using GameOnlineTutorial;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UnderworlD
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class UnderworlD : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        Texture2D mainChar;
        Texture2D enemy1;
        
        Collision collision = new Collision();
        
        //main char logic
        Vector2 mainCharPosition = Vector2.Zero;
        readonly int mainCharCollisionRectOffSet = 10;
        readonly Point mainCharFrameSize = new Point(100, 100); // pixel X pixel , 1st one divided by roughly 3, second one is height default
        private float mainCharSpeed = 5;
        //enemy1 logic
        Vector2 enemy1Position = new Vector2(300, 300);
        int enemy1CollisionRectOffSet = 10;
        Point enemy1FrameSize = new Point(100, 100);
        
        //variables for key logic

        public UnderworlD()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        /// 
       
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mainChar = Content.Load<Texture2D>("MainChar");
            enemy1 = Content.Load<Texture2D>("enemy1");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState keyboardState = Keyboard.GetState();
            CharMovement(keyboardState);
            DetectOutOfBox();
            
            if (collision.Collide(mainCharPosition, mainCharCollisionRectOffSet, mainCharFrameSize, enemy1Position, enemy1CollisionRectOffSet, enemy1FrameSize))
            {
                Exit();
            }
            base.Update(gameTime);
            
            // TODO: Add your update logic here
        }
        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            

            spriteBatch.Begin();
            spriteBatch.Draw(mainChar, mainCharPosition, Color.White);
            spriteBatch.Draw(enemy1, enemy1Position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        //main char movemenet
        private void CharMovement(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            {
                mainCharPosition.X -= mainCharSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                mainCharPosition.X += mainCharSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W))
            {
                mainCharPosition.Y -= mainCharSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S))
            {
                mainCharPosition.Y += mainCharSpeed;
            }
        }
        //detection for sprite to stay in the screen
        private void DetectOutOfBox()
        {
            if (mainCharPosition.X < 0)
            {
                mainCharPosition.X = 0;
            }
            if (mainCharPosition.Y < 0)
            {
                mainCharPosition.Y = 0;
            }

            if (mainCharPosition.X > Window.ClientBounds.Width - mainCharFrameSize.X)
            {
                mainCharPosition.X = Window.ClientBounds.Width - mainCharFrameSize.X;
            }

            if (mainCharPosition.Y > Window.ClientBounds.Height - mainCharFrameSize.Y)
            {
                mainCharPosition.Y = Window.ClientBounds.Height - mainCharFrameSize.Y;
            }
        }
    }
}


//animation logic
//timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

//if (timeSinceLastFrame > milisecondsPerFrame)
//{
//    timeSinceLastFrame -= milisecondsPerFrame;
//    ++starCurrentFrame.X;

//    if (starCurrentFrame.X >= starSheetSize.X)
//    {
//        starCurrentFrame.X = 0;
//        ++starCurrentFrame.Y;

//        if (starCurrentFrame.Y >= starSheetSize.Y)
//        {
//            starCurrentFrame.Y = 0;
//        }
//    }
//}

//position1.X += speed1;
//if (position1.X > (Window.ClientBounds.Width - star.Width) || position1.X <0)
//{
//    speed1 *= -1;
//}

//position2.Y += speed2;

//if (position2.Y > (Window.ClientBounds.Height - star2.Height) || position2.Y < 0)
//{
//    speed2 *= -1;
//}