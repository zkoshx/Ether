using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ether.Instances.Enemy
{
    public class EnemyLogic
    {
        public Texture2D _texture;
        public Vector2 _position;
        public Vector2 velocity;

        public int HP = 5;
        public int maxHP = 5;
        public int AP = 3;
        public int DF = 1;

        public bool isVisible = true;

        public Rectangle bonebox;

        public EnemyLogic(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
            bonebox = new Rectangle(Convert.ToInt32(position.X), Convert.ToInt32(position.Y), texture.Width, texture.Height);
        }

        public virtual void Update(GameTime gameTime, List<EnemyLogic> enemy)
        {
            
        }

        public bool hit(Rectangle soul)
        {
            if (bonebox.Intersects(soul))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void move(GameTime gameTime)
        {
            velocity = new Vector2(-100, 0);
            _position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                
            }
            
        }
    }
}
