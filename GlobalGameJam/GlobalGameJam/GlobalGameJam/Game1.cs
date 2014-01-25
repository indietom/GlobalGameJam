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
        menu menu = new menu();
        List<bullet> bullets = new List<bullet>();
        List<enemy> enemies = new List<enemy>();
        List<enemyBullet> enemyBullets = new List<enemyBullet>();
        List<wall> walls = new List<wall>();
        List<blood> bloodSplatters = new List<blood>();
        List<particle> particles = new List<particle>();
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            for (float i = 0; i < 360; i += 10)
            {
               walls.Add(new wall(tower.x+(float)Math.Cos(i)*50+5, tower.y+(float)Math.Sin(i)*50 + 20));
            }
            walls.Add(new wall(9000, 9000));
            base.Initialize();
        }

        Texture2D spritesheet;
        Texture2D p1winS;
        Texture2D p2winS;
        SpriteFont font;
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spritesheet = Content.Load<Texture2D>("spritesheet");
            p1winS = Content.Load<Texture2D>("winScreen1");
            p2winS = Content.Load<Texture2D>("winScreen");
            font = Content.Load<SpriteFont>("font");
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

        public bool collision(Rectangle object1, Rectangle object2)
        {
            if (object1.Y >= object2.Y + object2.Height)
                return false;
            if (object1.X >= object2.X + object2.Width)
                return false;
            if (object1.Y + object1.Height <= object2.Y)
                return false;
            if (object1.X + object1.Width <= object2.X)
                return false;
            return true;
        }
        string gameState = "game";
        int countToMenu = 0;
        int countToWinScreen = 0;
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            switch(gameState)
            {
                case "menu":
                    wizard.reset();
                    tower.reset();
                    countToWinScreen = 0;
                    countToMenu = 0;
                    enemies.Clear();
                    bullets.Clear();
                    particles.Clear();
                    bloodSplatters.Clear();
                    enemyBullets.Clear();
                    Initialize();
                    menu.input(ref gameState);
                    break;
                case "p1 win":
                    countToMenu += 1;
                    if (countToMenu >= 200)
                    {
                        gameState = "menu";
                    }
                    break;
                case "p2 win":
                    countToMenu += 1;
                    if (countToMenu >= 200)
                    {
                        gameState = "menu";
                    }
                    break;
                case "game":
                    Rectangle enemyC;
                    Rectangle wallC;
                    Rectangle bulletsC;
                    Rectangle enemyBulletsC;
                    Rectangle wizardC = new Rectangle((int)wizard.x, (int)wizard.y, 32, 32);
                    Rectangle towerC = new Rectangle(384, 228, 24, 48);
                    KeyboardState keyboard = Keyboard.GetState();
                    MouseState mouse = Mouse.GetState();
                    tower.input(bullets);
                    tower.checkHelath();
                    wizard.input(enemies);
                    wizard.manaAdding();
                    wizard.checkHelath();
                    if (wizard.hp <= 0 || tower.hp <= 0)
                    {
                        countToWinScreen += 1;
                    }
                    if (countToWinScreen == 100)
                    {
                        if (wizard.hp <= 0)
                        {
                            gameState = "p1 win";
                        }
                        if (tower.hp <= 0)
                        {
                            gameState = "p2 win";
                        }
                    }
                    foreach (particle p in particles)
                    {
                        p.movment();
                    }
                    foreach (bullet b in bullets)
                    {
                        b.movment();
                        bulletsC = new Rectangle((int)b.x, (int)b.y, 12, 12);
                        if (collision(bulletsC, wizardC))
                        {
                            wizard.hp -= 1;
                            b.destroy = true;
                        }
                        foreach (enemy e in enemies)
                        {
                            enemyC = new Rectangle((int)e.x + 6, (int)e.y + 3, 11, 18);
                            if (collision(bulletsC, enemyC))
                            {
                                e.hp -= 1;
                                b.destroy = true;
                            }
                        }
                    }
                    foreach (enemy e in enemies)
                    {
                        e.movment(enemyBullets);
                        e.animation();
                        e.checkHealth(bloodSplatters, particles);
                        enemyC = new Rectangle((int)e.x + 6, (int)e.y + 3, 11, 18);
                        if (collision(towerC, enemyC))
                        {
                            if (e.attackCounter >= 20)
                            {
                                tower.hp -= 1;
                            }
                        }
                        foreach (wall w in walls)
                        {
                            wallC = new Rectangle((int)w.x, (int)w.y, 16, 16);
                            if (collision(towerC, enemyC) && e.type == 1 && !collision(wallC, enemyC))
                            {
                                e.running = false;
                            }
                            if (collision(wallC, enemyC) && e.type == 1 && !collision(enemyC, towerC))
                            {
                                e.running = false;
                                if (e.attackCounter >= 20)
                                {
                                    w.hp -= 1;
                                }
                                if (w.hp <= 0)
                                {
                                    e.running = true;
                                }
                            }

                        }
                    }
                    foreach (enemyBullet eb in enemyBullets)
                    {
                        eb.movment();
                        enemyBulletsC = new Rectangle((int)eb.x, (int)eb.y, 6, 6);
                        if (collision(enemyBulletsC, towerC))
                        {
                            tower.hp -= 1;
                            eb.destroy = true;
                        }
                        foreach (wall w in walls)
                        {
                            wallC = new Rectangle((int)w.x, (int)w.y, 16, 16);
                            if (collision(enemyBulletsC, wallC))
                            {
                                w.hp -= 1;
                                eb.destroy = true;
                            }
                        }
                    }
                    foreach (wall w in walls)
                    {
                        w.checkHelath(particles);
                    }
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        if (enemies[i].destroy)
                        {
                            enemies.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < bullets.Count; i++)
                    {
                        if (bullets[i].destroy)
                        {
                            bullets.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < enemyBullets.Count; i++)
                    {
                        if (enemyBullets[i].destroy)
                        {
                            enemyBullets.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < walls.Count; i++)
                    {
                        if (walls[i].destroy)
                        {
                            walls.RemoveAt(i);
                        }
                    }
            break;
        }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            switch (gameState)
            {
                case "game":
                    for (int x = 0; x < 17; x++)
                    {
                        for (int y = 0; y < 10; y++)
                        {
                            spriteBatch.Draw(spritesheet, new Vector2(x * 49, y * 49), new Rectangle(101, 1, 49, 49), Color.White);
                        }
                    }
                    foreach (blood b in bloodSplatters)
                    {
                        b.drawSprite(spriteBatch, spritesheet);
                    }
                    foreach (particle p in particles)
                    {
                        p.drawSprite(spriteBatch, spritesheet);
                    }
                    tower.drawSprite(spriteBatch, spritesheet);
                    wizard.drawSprite(spriteBatch, spritesheet);
                    foreach (enemy e in enemies)
                    {
                        e.drawSprite(spriteBatch, spritesheet);
                    }
                    foreach (wall w in walls)
                    {
                        w.drawSprite(spriteBatch, spritesheet);
                    }
                    foreach (enemyBullet eb in enemyBullets)
                    {
                        eb.drawSprite(spriteBatch, spritesheet);
                    }
                    foreach (bullet b in bullets)
                    {
                        spriteBatch.Draw(spritesheet, new Vector2(b.x, b.y), new Rectangle(b.imx, b.imy, b.width, b.height), Color.White, b.angle, new Vector2(6, 2), 1.0f, SpriteEffects.None, 0);
                    }
                    spriteBatch.Draw(spritesheet, new Vector2(0, 0), new Rectangle(581, 0, 110, 480), Color.White);
                    spriteBatch.Draw(spritesheet, new Vector2(690, 0), new Rectangle(691, 0, 110, 480), Color.White);
                    spriteBatch.DrawString(font, "Mana: " + wizard.mana.ToString(), new Vector2(0,240), Color.White);
                    MouseState mouse = Mouse.GetState();
                    spriteBatch.Draw(spritesheet, new Vector2(mouse.X - 6, mouse.Y - 6), new Rectangle(1, 426, 12, 12), Color.White);
                    break;
                case "p1 win":
                    spriteBatch.Draw(p1winS, new Vector2(0,0), Color.White);
                    break;
                case "p2 win":
                    spriteBatch.Draw(p2winS, new Vector2(0, 0), Color.White);
                    break;
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
