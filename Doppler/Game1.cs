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
        public static SpriteFont font;
        public static Configs configs;

        //arrays
        static List<Message> messages;
        public static List<SoundEffect> sounds;

        MainMenu menu;

        public Game1()
        {
            //window size
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            content = Content;

            messages = new List<Message>();
            sounds = new List<SoundEffect>();
        }

        protected override void Initialize()
        {
            configs = new Configs(this);
            menu = new MainMenu();

            base.Initialize();
            Console.WriteLine("Width: " + GraphicsDevice.Viewport.Bounds.Width + " Height: " + GraphicsDevice.Viewport.Bounds.Height);
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = content.Load<SpriteFont>("Level");

            // Create sounds
            sounds.Add(content.Load<SoundEffect>("human"));
            sounds.Add(content.Load<SoundEffect>("ai"));
            sounds.Add(content.Load<SoundEffect>("minionSpawn"));
            sounds.Add(content.Load<SoundEffect>("collision"));
            sounds.Add(content.Load<SoundEffect>("collision2"));
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            menu.Update(gameTime);

            _gameTime = gameTime;

            // check for message duration
            for(int i=0; i<messages.Count; i++)
            {
                if((float)gameTime.TotalGameTime.TotalSeconds - messages[i]._timer > 1.5f)
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

            menu.Draw(spriteBatch, gameTime);

            foreach (var message in messages)
            {
                spriteBatch.DrawString(font, message._text, message._position, Color.Black);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public static void deleteAllMessages()
        {
            for(int i=0; i<messages.Count; i++)
            {
                messages.RemoveAt(i);
            }
        }

        public static void addMessage(String msg, Vector2 position)
        {
            messages.Add(new Message(msg, (float)_gameTime.TotalGameTime.TotalSeconds, position));
        }
    }
}
