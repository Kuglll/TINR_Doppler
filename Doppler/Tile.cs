using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doppler
{
    public class Tile
    {

        public Texture2D _texture;
        public Vector2 _position;

        public Tile(Texture2D texture, Vector2 position)
        {
            _position = position;
            _texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, new Rectangle(1024, 512, 511, 511), Color.White, 0f, new Vector2(0, 0), new Vector2(0.1f, 0.1f), SpriteEffects.FlipHorizontally, 1f);
        }

    }
}


