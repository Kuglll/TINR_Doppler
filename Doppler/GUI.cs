using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doppler
{
    class GUI
    {
        Texture2D guiTexture;

        //player 1
        private static int health1;
        private static int mana1;
        private static int minion1;

        //player2
        private static int health2;
        private static int mana2;
        private static int minion2;

        public GUI()
        {
            guiTexture = Game1.content.Load<Texture2D>("gui");
        }

        public static void UpdatePlayer1(int h, int ma, int mi)
        {
            health1 = h;
            mana1 = ma;
            minion1 = mi;
        }

        public static void UpdatePlayer2(int h, int ma, int mi)
        {
            health2 = h;
            mana2 = ma;
            minion2 = mi;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(guiTexture, new Vector2(0, 450), new Rectangle(0, 1, 800, 150), Color.White); //background

            //player1
            for (int i = 0; i < mana1; i++)
            {
                spriteBatch.Draw(guiTexture, new Vector2(200, 475), new Rectangle(0, 325, 10*mana1, 38), Color.White); //mana
            }
            for (int i = 0; i < health1; i++)
            {
                spriteBatch.Draw(guiTexture, new Vector2(200, 538), new Rectangle(445, 325, 100, 38), Color.White); //health
            }

            //player2
            for (int i = 0; i < mana2; i++) { 
                spriteBatch.Draw(guiTexture, new Vector2(600, 475), new Rectangle(0, 325, 10*mana2, 38), Color.White); //mana
             }
            for (int i = 0; i < health2; i++)
            {
                spriteBatch.Draw(guiTexture, new Vector2(600, 538), new Rectangle(445, 325, 100, 38), Color.White); //health
            }

        }

    }
}
