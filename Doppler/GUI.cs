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
        static int maxMana = 10;

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

        public static int getPlayer1Health()
        {
            return health1;
        }

        public static void UpdatePlayer1Health(int h)
        {
            health1 = h;
        }

        public static void UpdatePlayer1Mana(int ma)
        {
            mana1 = ma;
            if(mana1 > maxMana)
            {
                mana1 = maxMana;
            }
        }

        public static void UpdatePlayer1Minion(int mi)
        {
            minion1 = mi;
        }

        public static int getPlayer2Health()
        {
            return health2;
        }

        public static void UpdatePlayer2Health(int h)
        {
            health2 = h;
        }

        public static void UpdatePlayer2Mana(int ma)
        {
            mana2 = ma;
            if(mana2 > maxMana)
            {
                mana2 = maxMana;
            }
        }

        public static void UpdatePlayer2Minion(int mi)
        {
            minion2 = mi;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(guiTexture, new Vector2(0, 450), new Rectangle(0, 1, 800, 150), Color.White); //background
            spriteBatch.Draw(guiTexture, new Vector2(400, 450), new Rectangle(1030, 0, 20, 150), Color.White); //splitting line

            //player1
            spriteBatch.DrawString(Game1.font, "Mana: ", new Vector2(175, 480), Color.Black);
            spriteBatch.DrawString(Game1.font, "Health: ", new Vector2(175, 543), Color.Black);
            for (int i = 0; i < mana1; i++)
            {
                spriteBatch.Draw(guiTexture, new Vector2(280, 475), new Rectangle(0, 325, 10*mana1, 38), Color.White); //mana
            }
            for (int i = 0; i < health1; i++)
            {
                spriteBatch.Draw(guiTexture, new Vector2(280, 538), new Rectangle(445, 325, 10*health1, 38), Color.White); //health
            }

            //numbers
            spriteBatch.DrawString(Game1.font, mana1.ToString(), new Vector2(315, 480), Color.Black);
            spriteBatch.DrawString(Game1.font, health1.ToString(), new Vector2(315, 543), Color.Black);

            //player2
            spriteBatch.DrawString(Game1.font, "Mana: ", new Vector2(575, 480), Color.Black);
            spriteBatch.DrawString(Game1.font, "Health: ", new Vector2(575, 543), Color.Black);

            for (int i = 0; i < mana2; i++) { 
                spriteBatch.Draw(guiTexture, new Vector2(680, 475), new Rectangle(0, 325, 10*mana2, 38), Color.White); //mana
             }
            for (int i = 0; i < health2; i++)
            {
                spriteBatch.Draw(guiTexture, new Vector2(680, 538), new Rectangle(445, 325, 10*health2, 38), Color.White); //health
            }

            //numbers
            spriteBatch.DrawString(Game1.font, mana2.ToString(), new Vector2(715, 480), Color.Black);
            spriteBatch.DrawString(Game1.font, health2.ToString(), new Vector2(715, 543), Color.Black);
        }

    }
}
