using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Doppler
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random rnd;
        SpriteFont font;


        //player
        private Sprite _sprite1;
        Texture2D playerTexture;
        int currentLevel = -1;

        //coin
        private Sprite _coin;
        Texture2D coinTexture;

        //arrays
        List<Message> messages = new List<Message>();
        Coin[] coins = new Coin[5];


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            rnd = new Random();
            font = Content.Load<SpriteFont>("Level");

            // Create textures
            playerTexture = Content.Load<Texture2D>("characters/greenBird");
            coinTexture = Content.Load<Texture2D>("coin");

            _sprite1 = new Sprite(playerTexture, new Vector2(100, 100));
            
            // create coins
            for(int i=0; i<coins.Length; i++)
            {
                coins[i] = spawnNewCoin();
            }


        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            _sprite1.Update();

            //level up
            if (currentLevel != -1 && _sprite1.level != currentLevel)
            {
                messages.Add(new Message("Level up", (float)gameTime.TotalGameTime.TotalSeconds, new Vector2(GraphicsDevice.Viewport.Bounds.Width / 2, GraphicsDevice.Viewport.Bounds.Height / 2)));
            }

            //save previous level
            currentLevel = _sprite1.level;

            // constantly spawn 3 coins
            for (int i = 0; i < coins.Length; i++)
            {
                if (Math.Abs(coins[i]._position.X - _sprite1._position.X) < 65 && Math.Abs(coins[i]._position.Y - _sprite1._position.Y) < 45)
                {
                    _sprite1.addCoin();
                    coins[i] = spawnNewCoin();
                }
            }

            // check for message duration
            for(int i=0; i<messages.Count; i++)
            {
                if(messages[i]._timer - (float)gameTime.TotalGameTime.TotalSeconds < -3)
                {
                    messages.RemoveAt(i);
                }
            }


            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //score
            spriteBatch.DrawString(font, ("Level: " + _sprite1.level), new Vector2(0, 0), Color.Black);

            //display messages
            foreach (var message in messages)
            {
                spriteBatch.DrawString(font, message._text, message._position, Color.Black);
            }
            

            //coins
            for (int i=0; i < coins.Length; i++){
                if(coins[i] != null)
                {
                    coins[i].Draw(spriteBatch);
                }
            }
       
            //player
            _sprite1.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public Coin spawnNewCoin()
        {
            int x = rnd.Next(20, GraphicsDevice.Viewport.Bounds.Width - 20);
            int y = rnd.Next(20, GraphicsDevice.Viewport.Bounds.Height - 20);
            return new Coin(coinTexture,  new Vector2(x,y));
        }
    }
}
