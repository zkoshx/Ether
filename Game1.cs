using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ether
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static Rectangle hitbox;
        public static Rectangle LWall;
        public static Rectangle RWall;
        public static Rectangle TWall;
        public static Rectangle BWall;

        public Vector2 test;
        public bool inter;

        Instances.PlayerLogic soulinfo = new Instances.PlayerLogic();

        Texture2D soul;
        Texture2D bulletBoard;
        public static Texture2D bone;

        Instances.Enemy.EnemyLogic enemyblock1 = new Instances.Enemy.EnemyLogic(bone, new Vector2(512, 250));
        Instances.Enemy.EnemyLogic enemyblock2 = new Instances.Enemy.EnemyLogic(bone, new Vector2(512, 300));
        Instances.Enemy.EnemyLogic enemyblock3 = new Instances.Enemy.EnemyLogic(bone, new Vector2(512, 350));

        

        Vector2 boardpos = new Vector2(200, 225);
        Vector2 soulpos = new Vector2(250, 200);
        Vector2 velocity = new Vector2(0, 0);



        public bool IsTouchingLeft()
        {
            return hitbox.Left + velocity.X < LWall.Right;
        }
        bool IsTouchingRight()
        {
            return hitbox.Right + velocity.X > RWall.Left;
        }
        bool IsTouchingBottom()
        {
            return hitbox.Bottom + velocity.Y > BWall.Top;
        }
        bool IsTouchingTop()
        {
            return hitbox.Top + velocity.Y < TWall.Bottom;
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;

        }

        protected override void Initialize()
        {
            hitbox = new Rectangle(Convert.ToInt32(soulpos.X), Convert.ToInt32(soulpos.Y), 257, 196);
            LWall = new Rectangle(Convert.ToInt32(boardpos.X - 111), Convert.ToInt32(boardpos.Y + 90), 0 , 1);
            RWall = new Rectangle(Convert.ToInt32(boardpos.X + 521), Convert.ToInt32(boardpos.Y + 90), 0, 1);
            BWall = new Rectangle(Convert.ToInt32(boardpos.X - 111), Convert.ToInt32(boardpos.Y + 265), 1000, 1);
            TWall = new Rectangle(Convert.ToInt32(boardpos.X - 111), Convert.ToInt32(boardpos.Y - 76), 1000, 1);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            soul = Content.Load<Texture2D>("download-removebg-preview");
            bulletBoard = Content.Load<Texture2D>("Bullet Board");
            bone = Content.Load<Texture2D>("images-removebg-preview");

        }

        protected override void Update(GameTime gameTime)
        {
            hitbox.X = Convert.ToInt32(soulpos.X);
            hitbox.Y = Convert.ToInt32(soulpos.Y);

            if (enemyblock1.hit(hitbox))
            {
                soulinfo.HP = soulinfo.HP - soulinfo.dmgcalc(enemyblock1.AP);
                while (gameTime.ElapsedGameTime.TotalSeconds != 10)
                {

                }
            }

            enemyblock1.move(gameTime);
            enemyblock2.move(gameTime);
            enemyblock3.move(gameTime);

           if (Keyboard.GetState().IsKeyDown(Keys.W))
           {
                velocity.Y -= 2;
           }
           if (Keyboard.GetState().IsKeyDown(Keys.S))
           {
                velocity.Y += 2;
           }
           if (Keyboard.GetState().IsKeyDown(Keys.A))
           {
                velocity.X -= 2;
           }
           if (Keyboard.GetState().IsKeyDown(Keys.D))
           {
                velocity.X += 2;
           }

           if (velocity.X < 0 && IsTouchingLeft() || velocity.X > 0 && IsTouchingRight())
           {
                velocity.X = 0;
           }
           if (velocity.Y > 0 && IsTouchingBottom() || velocity.Y < 0 && IsTouchingTop())
           {
                velocity.Y = 0;
           }
           
           
            soulpos = soulpos + velocity;
            velocity = new Vector2(0, 0);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            _spriteBatch.Draw(bulletBoard, boardpos, Color.White);
            _spriteBatch.Draw(soul, soulpos, Color.White);
            
            _spriteBatch.Draw(bone, enemyblock1._position, Color.White);
            _spriteBatch.Draw(bone, enemyblock2._position, Color.White);
            _spriteBatch.Draw(bone ,enemyblock3._position, Color.White);

            _spriteBatch.End();

            
            base.Draw(gameTime);
        }
    }
}
