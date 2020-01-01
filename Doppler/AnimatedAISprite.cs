using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Doppler
{
    public class AnimatedAISprite : AiSprite
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        float lastUpdate = 0;


        public AnimatedAISprite(Texture2D texture, int currentLane, int rows, int columns) : base(texture, currentLane)
        {
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = rows * columns;
        }

        public void Update(GameTime gameTime)
        {
            if ((float)gameTime.TotalGameTime.TotalSeconds - lastUpdate > 0.1f)
            {
                lastUpdate = (float)gameTime.TotalGameTime.TotalSeconds;
                currentFrame++;
                if (currentFrame == totalFrames) currentFrame = 0;
            }
            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            int width = _texture.Width / Columns;
            int height = _texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, width, height);

            spriteBatch.Draw(_texture, _position, sourceRectangle, Color.White, 0f, new Vector2(595, 474), new Vector2(0.3f, 0.3f), SpriteEffects.FlipHorizontally, 1f);
            DrawMinions(spriteBatch, gameTime);
        }
    }
}
