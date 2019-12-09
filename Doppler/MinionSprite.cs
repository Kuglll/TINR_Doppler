using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doppler
{
    public class MinionSprite
    {
        public Texture2D _texture;
        public Vector2 _position;
        public bool _ally = true;

        public float Speed = 2f;

        public MinionSprite(Vector2 position, bool ally)
        {
            _position = position;
            _texture = Game1.content.Load<Texture2D>("characters/chicken");
            _ally = ally;
        }

        public MinionSprite(Vector2 position) : this(position, true){}

        public void Update()
        {
            if (_ally)
            {
                _position.X += Speed;
            }
            else
            {
                _position.X -= Speed;
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_ally)
            {
                spriteBatch.Draw(_texture, _position, new Rectangle(0, 0, 1090, 861), Color.White, 0f, new Vector2(612, 438), new Vector2(0.1f, 0.1f), SpriteEffects.None, 1f);
            } else
            {
                spriteBatch.Draw(_texture, _position, new Rectangle(0, 0, 1090, 861), Color.White, 0f, new Vector2(612, 438), new Vector2(0.1f, 0.1f), SpriteEffects.FlipHorizontally, 1f);
            }
        
        }
    }
}
