﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doppler
{
    class MainMenu
    {

        Texture2D buttonTexture;

        public MainMenu()
        {
            buttonTexture = Game1.content.Load<Texture2D>("button");
        }


        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

        }
    }
}
