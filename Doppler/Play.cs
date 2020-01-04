using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doppler
{
    class Play
    {
        List<Button> buttons = new List<Button>();
        public static bool finished = false;
        String winner = "";

        Texture2D buttonTexture;
        public static bool paused = false;
        bool EscapePressed = false;


        //Scene
        private Scene _scene;

        //Gui
        private GUI _gui;

        public Play()
        {
            buttonTexture = Game1.content.Load<Texture2D>("button");

            // Create scene
            _scene = new Scene();

            // Create gui
            _gui = new GUI();

            // Create buttons for menu
            CreateButtons();
        }

        public void CreateButtons()
        {
            var resumeButton = new Button(buttonTexture, Game1.font)
            {
                Position = new Vector2(350, 200),
                Text = "Resume"
            };

            resumeButton.Click += ResumeButtonClick;

            var quitButton = new Button(buttonTexture, Game1.font)
            {
                Position = new Vector2(350, 250),
                Text = "Return to Main Menu"
            };

            quitButton.Click += QuitButtonClick;

            buttons.Add(resumeButton);
            buttons.Add(quitButton);
        }

        private void ResumeButtonClick(object sender, System.EventArgs e)
        {
            Game1.configs.SetMouseInvisible();
            paused = false;
        }

        private void QuitButtonClick(object sender, System.EventArgs e)
        {
            //Exit();
            //TODO: return back to mainmenu
        }

        public void Update(GameTime gameTime)
        {
            //pausing with escape
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) && !EscapePressed)
            {
                if (!paused)
                {
                    Game1.configs.SetMouseVisible();
                    paused = true;
                }
                else
                {
                    Game1.configs.SetMouseInvisible();
                    paused = false;
                }

                EscapePressed = true;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Escape))
            {
                EscapePressed = false;
            }

            //finished game
            if (finished)
            {
                Game1.configs.SetMouseVisible();
                paused = false;
            }

            //updating gameplay
            Gameplay.checkForCollisions();
            Gameplay.checkForMinionsReachingEnd();
            winner = Gameplay.checkForWinCondition();

            if (winner != "")
            {
                finished = true;
            }

            //updating scene
            _scene.Update(gameTime);

            // updating menu buttons
            if (paused)
            {
                foreach (var button in buttons)
                    button.Update(Game1._gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //scene
            _scene.Draw(spriteBatch, gameTime);

            //gui
            _gui.Draw(spriteBatch);

            //menu buttons
            if (paused)
            {
                foreach (var button in buttons)
                    button.Draw(gameTime, spriteBatch);
            }

            //finished state
            if (finished)
            {
                spriteBatch.DrawString(Game1.font, winner + " wins!", new Vector2(320, 200), Color.Black);
            }
        }

    }
}
