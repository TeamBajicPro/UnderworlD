using GameOnlineTutorial.Characters;
using GameOnlineTutorial.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameOnlineTutorial
{
    
    public class UnderworlD : Game, IAttack
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        Enemy orc;
        private Enemy goblin;
        private Enemy elf;
        private Texture2D forest;
        
        //Screen parameters
        private int screenWidth;
        private int screenHeight;

        public UnderworlD() : base()
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
            forest = Content.Load<Texture2D>("forest");
            player = new Player(new Vector2(350, 435), 200, 20, 0);
            player.LoadContent(Content);
            orc = new Orc(Content.Load<Texture2D>("orc"), new Rectangle(100, 100, 70, 70), 120, 50);
            elf = new Elf(Content.Load<Texture2D>("elf"), new Rectangle(500, 200, 70, 70), 150, 20);
            goblin = new Goblin(Content.Load<Texture2D>("goblin"), new Rectangle(200, 300, 70, 70), 100, 30);

            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;

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
            
            // TODO: use this.Content to load your game content here

            player.Update(gameTime);
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
            spriteBatch.Draw(forest, Vector2.Zero, Color.White);
            player.Draw(spriteBatch);
            elf.Draw(spriteBatch);
            orc.Draw(spriteBatch);
            goblin.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }


        public void Attack(Player player, Enemy enemy)
        {
           //collision if ()
            {
                enemy.Health -= player.Damage;
            }
        }
        
    }
}


