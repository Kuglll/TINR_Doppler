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

        public float Speed = 2f;
        public int currentLane;
        ArrayList minions = new ArrayList();

        float lastActionTime = 0;

        int[] enemyMinionCount = {0, 0, 0};

        public AiSprite(Texture2D texture, int lane)
        {
            _position.X = 730;
            currentLane = lane;
            _texture = texture;
        }

        public void Update(GameTime gameTime)
        {
            //update minions
            foreach (MinionSprite minion in minions)
            {
                minion.Update();
            }

            // BROKEN PART
            checkEnemyMinions();

            for (int i = 0; i < 3; i++)
            {
                //Console.WriteLine("Lane " + i + ": Number of minions: " + enemyMinionCount[i]);
            }
            // END OF BROKEN PART

            //Do action every 0.5 second
            if ((float)gameTime.TotalGameTime.TotalSeconds - lastActionTime > 1f ){
                doAction();
                lastActionTime = (float)gameTime.TotalGameTime.TotalSeconds;
            }

            updatePosition(currentLane);
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
            spawnMinion();
        }

        public void spawnMinion()
        {
            minions.Add(new MinionSprite(currentLane, false));
        }

        public void checkEnemyMinions()
        {
            foreach(MinionSprite enemyMinion in Sprite.minions)
            {
                enemyMinionCount[enemyMinion._lane]++; 
            }
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
