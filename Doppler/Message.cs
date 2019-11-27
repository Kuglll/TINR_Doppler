using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doppler
{
    class Message
    {
        public String _text;
        public float _timer;
        public Vector2 _position;

        public Message(String text, float timer , Vector2 position)
        {
            _text = text;
            _timer = timer;
            _position = position;
        }



    }
}
