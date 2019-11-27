using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Doppler
{
    public class AnimatedSprite : Sprite
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        public AnimatedSprite(Texture2D texture, Vector2 position, int rows, int columns) : base(texture, position)
        {
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = rows * columns;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames) currentFrame = 0;
            base.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = _texture.Width / Columns;
            int height = _texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, width, height);

            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
