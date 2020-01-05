using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doppler
{
    class Settings
    {
        List<Button> buttons = new List<Button>();
        Texture2D buttonTexture;
        SpriteFont font;

        public Settings()
        {
            buttonTexture = Game1.content.Load<Texture2D>("button");
            font = Game1.content.Load<SpriteFont>("Level");
            CreateButtons();
        }

        public void CreateButtons()
        {
            String txt;
            if (Game1.configs.MuteStatus())
            {
                txt = "Unmute";
            }
            else
            {
                txt = "Mute";
            }

            var muteButton = new Button(buttonTexture, font)
            {
                Position = new Vector2(350, 200),
                Text = txt
            };

            muteButton.Click += MuteButtonClick;

            var backButton = new Button(buttonTexture, font)
            {
                Position = new Vector2(350, 250),
                Text = "Back"
            };

            backButton.Click += BackButtonClick;

            var saveButton = new Button(buttonTexture, font)
            {
                Position = new Vector2(650, 550),
                Text = "Save"
            };

            saveButton.Click += SaveButtonClick;

            buttons.Add(muteButton);
            buttons.Add(backButton);
            buttons.Add(saveButton);
        }

        private void MuteButtonClick(object sender, System.EventArgs e)
        {
            if(buttons[0].Text == "Mute")
            {
                buttons[0].Text = "Unmute";
                Game1.configs.Mute();
            }
            else
            {
                buttons[0].Text = "Mute";
                Game1.configs.Unmute();
            }
        }

        private void BackButtonClick(object sender, System.EventArgs e)
        {
            MainMenu.ShowMainMenu();
            Game1.configs.SetMouseVisible();
            Game1.deleteAllMessages();
        }

        private void SaveButtonClick(object sender, System.EventArgs e)
        {
            Game1.addMessage("Settings saved!", new Vector2(320, 300));
            //TODO: store to file + message saved
        }

        public void Update(GameTime gameTime)
        {
            foreach (var button in buttons)
                button.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (var button in buttons)
                button.Draw(gameTime, spriteBatch);
        }
    }
}
