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
        Texture2D backgroundTexture;
        bool _ai;

        //player1
        private AnimatedSprite _sprite1;
        Texture2D playerTexture;

        //player2
        private AnimatedSprite2 _sprite2;

        //AI
        private AnimatedAISprite _aiSprite;
        Texture2D aiTexture;

        public Scene(bool ai)
        {
            _ai = ai;
            initTextures();
            setupPlayers();
            generateTiles();
        }

        public void initTextures()
        {
            tileTexture = Game1.content.Load<Texture2D>("tiles");
            playerTexture = Game1.content.Load<Texture2D>("characters/pinkBird");
            aiTexture = Game1.content.Load<Texture2D>("characters/yellowBird");
            backgroundTexture = Game1.content.Load<Texture2D>("background_small");
        }

        public void setupPlayers()
        {
            _sprite1 = new AnimatedSprite(playerTexture, 0, 1, 2);
            if (_ai)
            {
                _aiSprite = new AnimatedAISprite(aiTexture, 0, 1, 2);
            }
            else
            {
                _sprite2 = new AnimatedSprite2(aiTexture, 0, 1, 2);
            }
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
            if (_ai)
            {
                _aiSprite.Update(gameTime);
                Gameplay.checkForCollisions(_aiSprite.getMinions(), _sprite1.getMinions());
                Gameplay.checkForMinionsReachingEnd(_aiSprite.getMinions(), _sprite1.getMinions());
            }
            else
            {
                _sprite2.Update(gameTime);
                Gameplay.checkForCollisions(_sprite2.getMinions(), _sprite1.getMinions());
                Gameplay.checkForMinionsReachingEnd(_sprite2.getMinions(), _sprite1.getMinions());
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(backgroundTexture, new Vector2(0,0), Color.White);

            foreach(Tile tile in tiles)
            {
                tile.Draw(spriteBatch);
            }

            //player
            _sprite1.Draw(spriteBatch, gameTime);

            if (_ai)
            {
                //ai
                _aiSprite.Draw(spriteBatch, gameTime);
            }
            else
            {
                _sprite2.Draw(spriteBatch, gameTime);
            }
        }


    }
}
