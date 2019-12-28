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
    public class AiSprite
    {
        public Texture2D _texture;
        public Vector2 _position;
        Random rnd;

        public float Speed = 2f;
        public int currentLane;
        public int? selectedLane;
        ArrayList minions = new ArrayList();

        private int health = 10;
        private int mana = 0;
        private int minionSelected = 0;

        float lastActionTime = 0;

        public AiSprite(Texture2D texture, int lane)
        {
            rnd = new Random();
            _position.X = 730;
            _texture = texture;

            selectedLane = null;
            currentLane = lane;
        }

        public void Update(GameTime gameTime)
        {
            if (!Game1.paused)
            {
                //update minions
                foreach (MinionSprite minion in minions)
                {
                    minion.Update();
                }

                //Do action every 1 second + obtain 1 mana
                if ((float)gameTime.TotalGameTime.TotalSeconds - lastActionTime > 1f)
                {
                    mana += 1;
                    doAction();
                    lastActionTime = (float)gameTime.TotalGameTime.TotalSeconds;
                    Console.WriteLine("Mana player2: " + mana);
                }

                updatePosition(currentLane);

                //update GUI
                GUI.UpdatePlayer2(health, mana, minionSelected);
            }
        }

        public void updatePosition(int lane)
        {
            switch (lane)
            {
                case 0: _position.Y = 65; break;
                case 1: _position.Y = 215; break;
                case 2: _position.Y = 365; break;
            }
        }

        public void doAction()
        {
            if (selectedLane == currentLane)
            {
                if(mana >= MinionSprite.manaCost)
                {
                    selectedLane = null;
                    spawnMinion();
                    Game1.sounds[2].Play();
                    mana -= MinionSprite.manaCost;
                }
            }
            if (selectedLane == null) {
                selectLane();
            } else if (selectedLane != currentLane)
            {
                if(selectedLane > currentLane)
                {
                    currentLane++;
                    Game1.sounds[1].Play();
                }
                else
                {
                    currentLane--;
                    Game1.sounds[1].Play();
                }
            }
        }

        public void selectLane()
        {
            int random = rnd.Next(Sprite.minionsPerLane.Sum() + 3);

            if(random >= 0 && random <= Sprite.minionsPerLane[0])
            {
                selectedLane = 0;
            }
            else if(random >= Sprite.minionsPerLane[0] + 1 && random <= Sprite.minionsPerLane[1] + Sprite.minionsPerLane[0] + 1)
            {
                selectedLane = 1;
            }
            else if(random >= Sprite.minionsPerLane[1] + Sprite.minionsPerLane[0] + 1 && random <= Sprite.minionsPerLane.Sum() + 3)
            {
                selectedLane = 2;
            }
        }

        public void spawnMinion()
        {
            minions.Add(new MinionSprite(currentLane, false));
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(_texture, _position, new Rectangle(0, 0, 1116, 864), Color.White, 0f, new Vector2(470, 642), new Vector2(0.1f, 0.1f), SpriteEffects.FlipHorizontally, 1f);
            foreach (MinionSprite minion in minions)
            {
                minion.Draw(spriteBatch);
            }
        }
    }
}
