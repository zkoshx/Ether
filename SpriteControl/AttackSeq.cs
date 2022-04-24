using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ether.SpriteControl
{
    public class AttackSeq
    {
        protected Texture2D _texture;

        public Vector2 Position;
        public Vector2 Velocity;
        public float Speed;
        public bool IsRemoved = false;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }
    }
}
