using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doppler
{
    public class Configs
    {

        private Game _game;
        public static bool mute;

        public Configs(Game game)
        {
            mute = false;
            ReadSettingsFile();
            _game = game;
        }

        private void ReadSettingsFile()
        {
            string readText = File.ReadAllText("..\\..\\..\\..\\Settings\\settings.txt");
            if(readText == "True")
            {
                Mute();
            }
            else
            {
                Unmute();
            }
        }

        public void SetMouseVisible()
        {
            _game.IsMouseVisible = true;
        }
        public void SetMouseInvisible()
        {
            _game.IsMouseVisible = false;
        }

        public void Mute()
        {
            SoundEffect.MasterVolume = 0f;
            mute = true;
        }

        public void Unmute()
        {
            SoundEffect.MasterVolume = 1f;
            mute = false;
        }

        public void Exit()
        {
            _game.Exit();
        }

        public bool MuteStatus()
        {
            return mute;
        }
    }
}
