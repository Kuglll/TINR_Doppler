using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        public static GameTime _gameTime;

        Random rnd;
        SpriteFont font;

        //Scene
        private Scene _scene;

        //Gui
        private GUI _gui;

        //arrays
        List<Message> messages = new List<Message>();
        public static List<SoundEffect> sounds = new List<SoundEffect>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
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

            // Create gui
            _gui = new GUI();

            // Create sounds
            sounds.Add(content.Load<SoundEffect>("human"));
            sounds.Add(content.Load<SoundEffect>("ai"));
            sounds.Add(content.Load<SoundEffect>("minionSpawn"));
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            _scene.Update(gameTime);
           
            // check for message duration
            for(int i=0; i<messages.Count; i++)
            {
                if((float)gameTime.TotalGameTime.TotalSeconds - messages[i]._timer > 3)
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
            _scene.Draw(spriteBatch, gameTime);

            //gui
            _gui.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public Coin spawnNewCoin()
        {
            int x = rnd.Next(20, GraphicsDevice.Viewport.Bounds.Width - 20);
            int y = rnd.Next(20, GraphicsDevice.Viewport.Bounds.Height - 20);
            //return new Coin(coinTexture,  new Vector2(x,y));
            return null;
        }
    }
}
