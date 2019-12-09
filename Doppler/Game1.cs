using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        public static ContentManager content;

        Random rnd;
        SpriteFont font;

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
            content = Content;
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
            font = content.Load<SpriteFont>("Level");

            // Create scene
            _scene = new Scene();

     
            coinTexture = content.Load<Texture2D>("coin");           
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            _scene.Update();
           
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
