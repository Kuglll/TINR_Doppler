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
    public class Sprite
    {
        public Texture2D _texture;

        public Vector2 _position;

        public float Speed = 2f;
        public int numberOfCoins = 0;
        public int level = 0;

        public Sprite(Texture2D texture, Vector2 position)
        {
            _position = position;
            _texture = texture;
        }

        public void addCoin()
        {
            numberOfCoins++;
        }

        public void Update()
        {
            if(numberOfCoins == 5)
            {
                level++;
                numberOfCoins = 0;
                Console.WriteLine("LEVEL UP!");
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                _position.Y -= Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                _position.Y += Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _position.X -= Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _position.X += Speed;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, new Rectangle(74, 22, 1176, 1203), Color.White, 0f, new Vector2(595, 474), new Vector2(0.1f, 0.1f), SpriteEffects.None, 1f);
        }
    }
}
