using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doppler
{
    public class Sprite2
    {
        public Texture2D _texture;
        public Vector2 _position;

        public float Speed = 2f;
        public int currentLane;

        public bool UpPressed;
        public bool DownPressed;
        public bool EnterPressed;

        private int health;
        private int mana;
        private int minionSelected;

        float lastManaObtained;

        public static ArrayList minions;

        public Sprite2(Texture2D texture, int lane)
        {
            init();
            _position.X = 870;
            currentLane = lane;
            _texture = texture;

            GUI.UpdatePlayer2Health(health);
        }

        public void init()
        {
            UpPressed = false;
            DownPressed = false;
            EnterPressed = true;

            health = 10;
            mana = 0;
            minionSelected = 0;
            lastManaObtained = 0;

            minions = new ArrayList();
        }

        public void Update(GameTime gameTime)
        {
            if (!Play.paused && !Play.finished)
            {
                //update all minions
                foreach (AnimatedMinionSprite minion in minions)
                {
                    if (minion != null)
                    {
                        minion.Update(gameTime);
                    }
                }

                //obtain 1 mana
                if ((float)gameTime.TotalGameTime.TotalSeconds - lastManaObtained > 1f)
                {
                    mana += 1;
                    lastManaObtained = (float)gameTime.TotalGameTime.TotalSeconds;
                    //Console.WriteLine("Mana player1: " + mana);
                }

                //process all the keys
                if (Keyboard.GetState().IsKeyDown(Keys.Up) && !UpPressed)
                {
                    UpPressed = true;
                    if (currentLane > 0)
                    {
                        currentLane -= 1;
                        Game1.sounds[0].Play();
                    }
                }
                else if (Keyboard.GetState().IsKeyUp(Keys.Up))
                {
                    UpPressed = false;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down) && !DownPressed)
                {
                    DownPressed = true;
                    if (currentLane < 2)
                    {
                        currentLane += 1;
                        Game1.sounds[0].Play();
                    }
                }
                else if (Keyboard.GetState().IsKeyUp(Keys.Down))
                {
                    DownPressed = false;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && !EnterPressed)
                {
                    EnterPressed = true;
                    spawnMinion();
                }
                else if (Keyboard.GetState().IsKeyUp(Keys.Enter))
                {
                    EnterPressed = false;
                }

                updatePosition(currentLane);

                //update GUI
                GUI.UpdatePlayer2Mana(mana);
            }
        }

        public void updatePosition(int lane)
        {
            switch (lane)
            {
                case 0: _position.Y = 150; break;
                case 1: _position.Y = 300; break;
                case 2: _position.Y = 450; break;
            }
        }

        public void spawnMinion()
        {
            if(mana >= MinionSprite.manaCost)
            {
                minions.Add(new AnimatedMinionSprite(_texture, currentLane, 4, 1, false));
                Game1.sounds[2].Play();
                mana -= MinionSprite.manaCost;
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(_texture, _position, new Rectangle(74, 22, 1176, 1203), Color.White, 0f, new Vector2(595, 474), new Vector2(0.1f, 0.1f), SpriteEffects.None, 1f);
            DrawMinions(spriteBatch, gameTime);
        }

        public void DrawMinions(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (AnimatedMinionSprite minion in minions)
            {
                if(minion != null){
                    minion.Draw(spriteBatch);
                }
            }
        }

        public ArrayList getMinions()
        {
            return minions;
        }
    }
}
