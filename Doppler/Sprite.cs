﻿using Microsoft.Xna.Framework;
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
        public int currentLane;

        public bool WPressed = false;
        public bool SPressed = false;
        public bool SpacePressed = true;

        private int health = 10;
        private int mana = 0;
        private int minionSelected = 0;

        float lastManaObtained = 0;

        ArrayList minions = new ArrayList();
        public static int[] minionsPerLane = { 0, 0, 0 };

        public Sprite(Texture2D texture, int lane)
        {
            _position.X = 60;
            currentLane = lane;
            _texture = texture;
        }

        public void Update(GameTime gameTime)
        {
            //update all minions
            foreach (MinionSprite minion in minions)
            {
                minion.Update();
            }

            //obtain 1 mana
            if ((float)gameTime.TotalGameTime.TotalSeconds - lastManaObtained > 1f)
            {
                mana += 1;
                lastManaObtained = (float)gameTime.TotalGameTime.TotalSeconds;
                Console.WriteLine("Mana player1: "+ mana);
            }

            //process all the keys
            if (Keyboard.GetState().IsKeyDown(Keys.W) && !WPressed){
                WPressed = true;
                if (currentLane > 0)
                {
                    currentLane -= 1;
                    Game1.sounds[0].Play();
                }
            } else if(Keyboard.GetState().IsKeyUp(Keys.W)){
                WPressed = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && !SPressed){
                SPressed = true;
                if (currentLane < 2)
                {
                    currentLane += 1;
                    Game1.sounds[0].Play();
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

            //update GUI
            GUI.UpdatePlayer1(health, mana, minionSelected);
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
            if(mana >= MinionSprite.manaCost)
            {
                minions.Add(new MinionSprite(currentLane));
                minionsPerLane[currentLane]++;
                Game1.sounds[2].Play();
                mana -= MinionSprite.manaCost;
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(_texture, _position, new Rectangle(74, 22, 1176, 1203), Color.White, 0f, new Vector2(595, 474), new Vector2(0.1f, 0.1f), SpriteEffects.None, 1f);
            foreach (MinionSprite minion in minions)
            {
                minion.Draw(spriteBatch);
            }
        }
    }
}