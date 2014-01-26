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
        List<powerUp> powerUps = new List<powerUp>();
        List<blood> bloodSplatters = new List<blood>();
        List<particle> particles = new List<particle>();
        List<runor> runorer = new List<runor>();
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            rebuildBarrier();
            walls.Add(new wall(9000, 9000));
            base.Initialize();
        }

        public void rebuildBarrier()
        {
            walls.Clear();
            for (float i = 0; i < 360; i += 10)
            {
                walls.Add(new wall(tower.x + (float)Math.Cos(i) * 50 + 5, tower.y + (float)Math.Sin(i) * 50 + 20));
            }
        }

        Texture2D spritesheet;
        Texture2D p1winS;
        Texture2D p2winS;
        SpriteFont font;
        SoundEffect towerHit;
        SoundEffect runePickUp;
        SoundEffect music;
        SoundEffect wizardHit;
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spritesheet = Content.Load<Texture2D>("spritesheet");
            p1winS = Content.Load<Texture2D>("winScreen1");
            p2winS = Content.Load<Texture2D>("winScreen");
            font = Content.Load<SpriteFont>("font");
            towerHit = Content.Load<SoundEffect>("towerHit");
            runePickUp = Content.Load<SoundEffect>("runePickup");
            wizardHit = Content.Load<SoundEffect>("wizardHit");
            music = Content.Load<SoundEffect>("music");
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
        string gameState = "menu";
        int countToMenu = 0;
        int countToWinScreen = 0;
        int spawnPowerUps = 0;
        int spawnRunor = 0;
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
                    Rectangle runorC;
                    Rectangle wallC;
                    Rectangle bulletsC;
                    Rectangle enemyBulletsC;
                    Rectangle wizardC = new Rectangle((int)wizard.x, (int)wizard.y, 32, 32);
                    Rectangle towerC = new Rectangle(384, 228, 24, 48);
                    Rectangle powerUpsC;
                    KeyboardState keyboard = Keyboard.GetState();
                    MouseState mouse = Mouse.GetState();
                    tower.input(bullets);
                    tower.checkHelath();
                    tower.checkPowerUp();
                    wizard.input(enemies, ref tower.inputActive, enemyBullets);
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
                    spawnPowerUps += 1;
                    if (spawnPowerUps == 64*3)
                    {
                        powerUps.Add(new powerUp());
                        spawnPowerUps = 0;
                    }
                    spawnRunor += 1;
                    if (spawnRunor == 64*2)
                    {
                        runorer.Add(new runor());
                        spawnRunor = 0;
                    }
                    foreach (runor r in runorer)
                    {
                        r.checkLifeTime();
                        r.movment();
                        runorC = new Rectangle((int)r.x, (int)r.y, 24, 24);
                        if (collision(runorC, wizardC))
                        {
                            runePickUp.Play();
                            switch (r.type)
                            {
                                case 1:
                                    wizard.magicSpell = 1;
                                    break;
                                case 2:
                                    wizard.magicSpell = 2;
                                    break;
                                case 3:
                                    wizard.magicSpell = 3;
                                    break;
                            }
                            r.destroy = true;
                        }
                    }
                    foreach (powerUp pu in powerUps)
                    {
                        pu.checkLifeTime();
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
                            wizardHit.Play();
                            b.destroy = true;
                        }
                        foreach (powerUp pu in powerUps)
                        {
                            powerUpsC = new Rectangle((int)pu.x, (int)pu.y, 24, 24);
                            if (collision(bulletsC, powerUpsC))
                            {
                                if (pu.type == 1)
                                {
                                    tower.gunType = 1;
                                    tower.powerUpActive = 1;
                                    pu.destroy = true;
                                }
                                if (pu.type == 2)
                                {
                                    rebuildBarrier();
                                    pu.destroy = true;
                                }
                                if (pu.type == 3)
                                {
                                    tower.gunType = 2;
                                    tower.powerUpActive = 1;
                                    pu.destroy = true;
                                }
                            }
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
                                towerHit.Play();
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
                            towerHit.Play();
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
                    for (int i = 0; i < powerUps.Count; i++)
                    {
                        if (powerUps[i].destroy)
                        {
                            powerUps.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < runorer.Count; i++)
                    {
                        if (runorer[i].destroy)
                        {
                            runorer.RemoveAt(i);
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
                case "menu":
                    menu.drawMenu(spriteBatch, font);
                    break;
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
                    foreach (powerUp pu in powerUps)
                    {
                        pu.drawSprite(spriteBatch, spritesheet);
                    }
                    foreach (runor r in runorer)
                    {
                        r.drawSprite(spriteBatch, spritesheet);
                    }
                    spriteBatch.Draw(spritesheet, new Vector2(0, 0), new Rectangle(581, 0, 110, 480), Color.White);
                    spriteBatch.Draw(spritesheet, new Vector2(690, 0), new Rectangle(691, 0, 110, 480), Color.White);
                    spriteBatch.DrawString(font, "Mana: " + wizard.mana.ToString(), new Vector2(0,240), Color.White);
                    spriteBatch.DrawString(font, "Helath: " + wizard.hp.ToString(), new Vector2(0, 270), Color.White);
                    if (wizard.magicSpell != 0)
                    {
                        spriteBatch.DrawString(font, "Hit Q to use \n magic spell", new Vector2(0, 290), Color.White);
                    }
                    spriteBatch.DrawString(font, "Helath: " + tower.hp.ToString(), new Vector2(690, 270), Color.White);
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
