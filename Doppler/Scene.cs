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

        public Scene(ContentManager content)
        {
            _content = content;
            initTextures();
            generateTiles();
        }

        public void initTextures()
        {
            tileTexture = _content.Load<Texture2D>("tiles");
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

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Tile tile in tiles)
            {
                tile.Draw(spriteBatch);
            }
        }


    }
}
