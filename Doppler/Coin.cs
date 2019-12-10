using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doppler
{
    public class Coin
    {
        public Texture2D _texture;
        public Vector2 _position;

        public Coin(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
        }

        public void Update()
        {
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, new Rectangle(65, 62, 130, 130), Color.White, 0f, new Vector2(65/2, 68/2), new Vector2(0.1f, 0.1f), SpriteEffects.None, 1f);
        }

    }
}