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
        Texture2D buttonTexture;
        public static bool paused = false;
        bool EscapePressed = false;

        //Scene
        private Scene _scene;

        //Gui
        private GUI _gui;

        //arrays
        List<Message> messages = new List<Message>();
        public static List<SoundEffect> sounds = new List<SoundEffect>();
        List<Button> buttons = new List<Button>();

        public Game1()
        {
            //window size
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
            buttonTexture = content.Load<Texture2D>("button");

            // Create scene
            _scene = new Scene();

            // Create gui
            _gui = new GUI();

            // Create buttons for menu
            CreateButtons();

            // Create sounds
            sounds.Add(content.Load<SoundEffect>("human"));
            sounds.Add(content.Load<SoundEffect>("ai"));
            sounds.Add(content.Load<SoundEffect>("minionSpawn"));
        }

        public void CreateButtons()
        {
            var resumeButton = new Button(buttonTexture, font)
            {
                Position = new Vector2(350, 200),
                Text = "Resume"
            };

            resumeButton.Click += ResumeButtonClick;

            var quitButton = new Button(buttonTexture, font)
            {
                Position = new Vector2(350, 250),
                Text = "Quit"
            };

            quitButton.Click += QuitButtonClick;

            buttons.Add(resumeButton);
            buttons.Add(quitButton);
        }

        private void ResumeButtonClick(object sender, System.EventArgs e)
        {
            IsMouseVisible = false;
            paused = false;
        }

        private void QuitButtonClick(object sender, System.EventArgs e)
        {
            Exit();
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            //pausing with escape
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) && !EscapePressed)
            {
                if (!paused)
                {
                    IsMouseVisible = true;
                    paused = true;
                } else
                {
                    IsMouseVisible = false;
                    paused = false;
                }
                
                EscapePressed = true;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Escape))
            {
                EscapePressed = false;
            }

            
            _scene.Update(gameTime);

            // updating menu buttons
            if (paused)
            {
                foreach (var button in buttons)
                    button.Update(_gameTime);
            }
            
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

            //menu buttons
            if (paused)
            {
                foreach (var button in buttons)
                    button.Draw(_gameTime, spriteBatch);
            }

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
