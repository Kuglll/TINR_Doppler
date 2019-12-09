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
    public class AiSprite
    {
        public Texture2D _texture;
        public Vector2 _position;

        public float Speed = 2f;

        public AiSprite(Texture2D texture, Vector2 position)
        {
            _position = position;
            _texture = texture;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, new Rectangle(0, 0, 1116, 864), Color.White, 0f, new Vector2(470, 642), new Vector2(0.1f, 0.1f), SpriteEffects.FlipHorizontally, 1f);
        }
    }
}
