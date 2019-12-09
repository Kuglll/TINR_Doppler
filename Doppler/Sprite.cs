﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
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

        public bool WPressed = false;
        public bool SPressed = false;

        public Sprite(Texture2D texture, Vector2 position)
        {
            _position = position;
            _texture = texture;
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) && !WPressed){
                WPressed = true;
                if(_position.Y > 50) _position.Y -= 150;
            } else if(Keyboard.GetState().IsKeyUp(Keys.W)){
                WPressed = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && !SPressed){
                SPressed = true;
                if(_position.Y < 350) _position.Y += 150;
            } else if(Keyboard.GetState().IsKeyUp(Keys.S)){
                SPressed = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, new Rectangle(74, 22, 1176, 1203), Color.White, 0f, new Vector2(595, 474), new Vector2(0.1f, 0.1f), SpriteEffects.None, 1f);
        }
    }
}
