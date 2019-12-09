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
    public class Sprite
    {
        public Texture2D _texture;
        public Vector2 _position;

        public float Speed = 2f;
        public int currentLane = 0;

        public bool WPressed = false;
        public bool SPressed = false;
        public bool SpacePressed = true;

        ArrayList minions = new ArrayList();

        public Sprite(Texture2D texture, Vector2 position)
        {
            _position = position;
            _texture = texture;
        }

        public void Update()
        {
            foreach (MinionSprite minion in minions)
            {
                minion.Update();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W) && !WPressed){
                WPressed = true;
                if (currentLane > 0)
                {
                    currentLane -= 1;
                }
            } else if(Keyboard.GetState().IsKeyUp(Keys.W)){
                WPressed = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && !SPressed){
                SPressed = true;
                if (currentLane < 2)
                {
                    currentLane += 1;
                }
            } else if(Keyboard.GetState().IsKeyUp(Keys.S)){
                SPressed = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !SpacePressed){
                SpacePressed = true;
                spawnMinion();
            } else if(Keyboard.GetState().IsKeyUp(Keys.Space)){
                SpacePressed = false;
            }

            updatePosition(currentLane);
        }

        public void updatePosition(int lane)
        {
            switch (lane)
            {
                case 0: _position.Y = 50; break;
                case 1: _position.Y = 200; break;
                case 2: _position.Y = 350; break;
            }
        }

        public void spawnMinion()
        {
            minions.Add(new MinionSprite(currentLane));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, new Rectangle(74, 22, 1176, 1203), Color.White, 0f, new Vector2(595, 474), new Vector2(0.1f, 0.1f), SpriteEffects.None, 1f);
            foreach (MinionSprite minion in minions)
            {
                minion.Draw(spriteBatch);
            }
        }
    }
}
