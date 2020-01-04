using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doppler
{
    public class Configs
    {

        private Game _game; 

        public Configs(Game game)
        {
            _game = game;
        }

        public void SetMouseVisible()
        {
            _game.IsMouseVisible = true;
        }
        public void SetMouseInvisible()
        {
            _game.IsMouseVisible = false;
        }
    }
}
