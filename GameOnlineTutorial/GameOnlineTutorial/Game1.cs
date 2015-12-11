using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UnderworlD
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D star;
        Texture2D star2;
        

        //collison
        Vector2 star2Position = new Vector2(300, 300);
        Point starFrameSize = new Point(250, 250); // pixel X pixel , 1st one divided by roughly 3, second one is height default
        Point starFrameSize2 = new Point(250, 250);
        int starCollisionRectOffSet = 10;
        int star2CollisionRectOffSet = 10;

        protected bool Collide()
        {
            Rectangle starRect = new Rectangle(
                (int)starPosition.X + starCollisionRectOffSet,
                (int)starPosition.Y + starCollisionRectOffSet,
                starFrameSize.X - (starCollisionRectOffSet * 2),
            starFrameSize.Y - (starCollisionRectOffSet * 2));

            Rectangle star2Rect = new Rectangle(
                (int)star2Position.X + star2CollisionRectOffSet,
                (int)star2Position.Y + star2CollisionRectOffSet,
                starFrameSize2.X - (star2CollisionRectOffSet * 2),
            starFrameSize2.Y - (star2CollisionRectOffSet * 2));

            return starRect.Intersects(star2Rect);

        }       
        //
        //variables for key logic
        Vector2 starPosition = Vector2.Zero;
        const float starSpeed = 5;
        

        public Game1()
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
            star = Content.Load<Texture2D>("star");
            star2 = Content.Load<Texture2D>("star2");
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
            //keyboard logic
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            {
                starPosition.X -= starSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                starPosition.X += starSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W))
            {
                starPosition.Y -= starSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S))
            {
                starPosition.Y += starSpeed;
            }

            //mouse logic

           
            //collision detector
            if (Collide())
            {
                Exit();
            }
            //keep sprite in window

            if (starPosition.X < 0)
            {
                starPosition.X = 0;

            }
            if (starPosition.Y < 0)
            {
                starPosition.Y = 0;
            }

            if (starPosition.X > Window.ClientBounds.Width - starFrameSize.X)
            {
                starPosition.X = Window.ClientBounds.Width - starFrameSize.X;
            }

            if (starPosition.Y > Window.ClientBounds.Height - starFrameSize.Y)
            {
                starPosition.Y = Window.ClientBounds.Height - starFrameSize.Y;
            }

            base.Update(gameTime);
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
            //Viewport viewport = graphics.GraphicsDevice.Viewport;
            //Vector2 screenCenter = new Vector2(viewport.Width / 2, viewport.Height / 2);
            // Vector2 imageCenter = new Vector2(star.Width / 2, viewport.Height / 2);

            //spriteBatch.Draw(texture, position, sourceRectangle, Color, Rotation, Origin, Scale, Effects, LayerDepth);
            //spriteBatch.Draw(spriteSheet1, Vector2.Zero, new Rectangle(
            //    (starCurrentFrame.X * starFrameSize.X),
            //    (starCurrentFrame.Y * starFrameSize.Y),
            //    starFrameSize.X,
            //    starFrameSize.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

            //spriteBatch.Draw(spriteSheet2, new Vector2(300, 300), 
            //    new Rectangle(
            //        (starCurrentFrame.X * starFrameSize2.Y), 
            //        (starCurrentFrame.Y * starFrameSize2.Y), 
            //        starFrameSize2.X, starFrameSize2.Y), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);

            spriteBatch.Begin();
            spriteBatch.Draw(star, starPosition, Color.White);
            spriteBatch.Draw(star2, star2Position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
