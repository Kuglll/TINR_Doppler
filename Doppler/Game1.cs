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
       
        //AI
        private AiSprite _spriteAi;
        Texture2D aiTexture;

        //coin
        private Sprite _coin;
        Texture2D coinTexture;

        //Scene
        private Scene _scene;

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
            Console.WriteLine("Width: " + GraphicsDevice.Viewport.Bounds.Width + " Height: " + GraphicsDevice.Viewport.Bounds.Height);
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            rnd = new Random();
            font = Content.Load<SpriteFont>("Level");

            // Create scene
            _scene = new Scene(Content);

            // Create textures
            playerTexture = Content.Load<Texture2D>("characters/greenBird");
            aiTexture = Content.Load<Texture2D>("characters/monster");
            coinTexture = Content.Load<Texture2D>("coin");

            _sprite1 = new Sprite(playerTexture, new Vector2(60, 50));
            _spriteAi = new AiSprite(aiTexture, new Vector2(730, 215));
            
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            _sprite1.Update();
            _spriteAi.Update();

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
            //scene
            _scene.Draw(spriteBatch);
       
            //player
            _sprite1.Draw(spriteBatch);

            //ai
            _spriteAi.Draw(spriteBatch);

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
