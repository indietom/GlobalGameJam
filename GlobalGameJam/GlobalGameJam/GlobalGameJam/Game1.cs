using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GlobalGameJam
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

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
        
        tower tower = new tower();
        wizard wizard = new wizard();
        List<bullet> bullets = new List<bullet>();
        List<enemy> enemies = new List<enemy>();
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            enemies.Add(new enemy(200, 400,3));
            base.Initialize();
        }

        Texture2D spritesheet;
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spritesheet = Content.Load<Texture2D>("spritesheet");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();
            tower.input(bullets);
            foreach (bullet b in bullets)
            {
                b.movment();
            }
            foreach (enemy e in enemies)
            {
                e.movment();
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);
            spriteBatch.Begin();
            for (int x = 0; x < 17; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    spriteBatch.Draw(spritesheet, new Vector2(x * 49, y * 49), new Rectangle(101, 1, 49, 49), Color.White);
                }
            }
            tower.drawSprite(spriteBatch, spritesheet);
            wizard.drawSprite(spriteBatch, spritesheet);
            foreach (enemy e in enemies)
            {
                e.drawSprite(spriteBatch, spritesheet);
            }
            foreach (bullet b in bullets)
            {
                spriteBatch.Draw(spritesheet, new Vector2(b.x, b.y), new Rectangle(b.imx, b.imy, b.width, b.height), Color.White, b.angle, new Vector2(6, 2), 1.0f, SpriteEffects.None, 0); 
            }
            MouseState mouse = Mouse.GetState();
            spriteBatch.Draw(spritesheet, new Vector2(mouse.X, mouse.Y), new Rectangle(1, 426, 12, 12), Color.White);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
