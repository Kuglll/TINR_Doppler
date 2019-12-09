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
        ContentManager _content;
        Texture2D tileTexture;

        //player
        private Sprite _sprite1;
        Texture2D playerTexture;

        //AI
        private AiSprite _spriteAi;
        Texture2D aiTexture;

        public Scene(ContentManager content)
        {
            _content = content;
            initTextures();
            setupPlayers();
            generateTiles();
        }

        public void setupPlayers()
        {
            _sprite1 = new Sprite(playerTexture, new Vector2(60, 50));
            _spriteAi = new AiSprite(aiTexture, new Vector2(730, 215));
        }

        public void initTextures()
        {
            tileTexture = _content.Load<Texture2D>("tiles");
            playerTexture = _content.Load<Texture2D>("characters/greenBird");
            aiTexture = _content.Load<Texture2D>("characters/monster");
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

        public void Update()
        {
            _sprite1.Update();
            _spriteAi.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Tile tile in tiles)
            {
                tile.Draw(spriteBatch);
            }

            //player
            _sprite1.Draw(spriteBatch);

            //ai
            _spriteAi.Draw(spriteBatch);
        }


    }
}
