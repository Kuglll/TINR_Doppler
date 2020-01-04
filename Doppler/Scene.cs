using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doppler
{
    class Scene
    {

        ArrayList tiles = new ArrayList();
        Texture2D tileTexture;

        //player
        private AnimatedSprite _sprite1;
        Texture2D playerTexture;

        //AI
        private AnimatedAISprite _spriteAi;
        Texture2D aiTexture;

        public Scene()
        {
            initTextures();
            setupPlayers();
            generateTiles();
        }

        public void initTextures()
        {
            tileTexture = Game1.content.Load<Texture2D>("tiles");
            playerTexture = Game1.content.Load<Texture2D>("characters/pinkBird");
            aiTexture = Game1.content.Load<Texture2D>("characters/yellowBird");
        }

        public void setupPlayers()
        {
            _sprite1 = new AnimatedSprite(playerTexture, 0, 1, 2);
            _spriteAi = new AnimatedAISprite(aiTexture, 0, 1, 2);
        }


        public void generateTiles()
        {
            int x = 0;
            int y = 100;
            for (int k = 1; k < 4; k++)
            {
                x = 0;
                for (int i = 0; i < 16; i++)
                {
                    tiles.Add(new Tile(tileTexture, new Vector2(x, y)));
                    x += 50;
                }
                y += 150;
            }
        }

        public void Update(GameTime gameTime)
        {
            _sprite1.Update(gameTime);
            _spriteAi.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach(Tile tile in tiles)
            {
                tile.Draw(spriteBatch);
            }

            //player
            _sprite1.Draw(spriteBatch, gameTime);

            //ai
            _spriteAi.Draw(spriteBatch, gameTime);
        }


    }
}
