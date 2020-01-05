using Microsoft.Xna.Framework;
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
        List<Button> buttons = new List<Button>();
        SpriteFont font;
        Texture2D buttonTexture;
        static bool menu = true;
        static bool playing = false;
        static bool settings = false;

        Play play;
        Settings stg;

        public MainMenu()
        {
            Game1.configs.SetMouseVisible();
            buttonTexture = Game1.content.Load<Texture2D>("button");
            font = Game1.content.Load<SpriteFont>("Level");
            CreateButtons();
        }

        public void CreateButtons()
        {
            var playAiButton = new Button(buttonTexture, font)
            {
                Position = new Vector2(350, 150),
                Text = "1 Player"
            };

            playAiButton.Click += PlayAiButtonClick;

            var playHumanButton = new Button(buttonTexture, font)
            {
                Position = new Vector2(350, 200),
                Text = "2 Players"
            };

            playHumanButton.Click += PlayHumanButtonClick;

            var settingsButton = new Button(buttonTexture, font)
            {
                Position = new Vector2(350, 250),
                Text = "Settings"
            };

            settingsButton.Click += SettingButtonClick;

            var exitButton = new Button(buttonTexture, font)
            {
                Position = new Vector2(350, 300),
                Text = "Exit"
            };

            exitButton.Click += ExitButtonClick;


            buttons.Add(playAiButton);
            buttons.Add(playHumanButton);
            buttons.Add(settingsButton);
            buttons.Add(exitButton);
        }

        private void PlayAiButtonClick(object sender, System.EventArgs e)
        {
            Game1.configs.SetMouseInvisible();
            play = new Play();
            menu = false;
            playing = true;
        }

        private void PlayHumanButtonClick(object sender, System.EventArgs e)
        {
            Game1.configs.SetMouseInvisible();
            play = new Play(false);
            menu = false;
            playing = true;
        }

        private void SettingButtonClick(object sender, System.EventArgs e)
        {
            stg = new Settings();
            menu = false;
            settings = true;
        }

        private void ExitButtonClick(object sender, System.EventArgs e)
        {
            Game1.configs.Exit();
        }

        public static void ShowMainMenu()
        {
            menu = true;
            playing = false;
            settings = false;
        }


        public void Update(GameTime gameTime)
        {
            if (menu)
            {
                foreach (var button in buttons)
                    button.Update(gameTime);
            }
            else if (playing)
            {
                play.Update(gameTime);
            }
            else if (settings)
            {
                stg.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (menu)
            {
                foreach (var button in buttons)
                    button.Draw(gameTime, spriteBatch);
            }
            else if (playing)
            {
                play.Draw(spriteBatch, gameTime);
            }
            else if (settings)
            {
                stg.Draw(spriteBatch, gameTime);
            }
        }
    }
}
