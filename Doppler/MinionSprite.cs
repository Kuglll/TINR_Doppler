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
    public class MinionSprite
    {
        public Texture2D _texture;
        public Vector2 _position;
        public int _lane;
        public bool _ally = true;

        public float Speed = 1.5f;
        public static int manaCost = 2;

        public MinionSprite(int lane, bool ally)
        {
            _texture = Game1.content.Load<Texture2D>("characters/chicken");
            _ally = ally;
            _position = getPositionByLane(lane);

        }

        public MinionSprite(int lane) : this(lane, true){}

        public Vector2 getPositionByLane(int lane)
        {
            if (_ally)
            {
                switch (lane)
                {
                    case 0: return new Vector2(100, 50);
                    case 1: return new Vector2(100, 200);
                    case 2: return new Vector2(100, 350);
                }
            }else
            {
                switch (lane)
                {
                    case 0: return new Vector2(690, 50);
                    case 1: return new Vector2(690, 200);
                    case 2: return new Vector2(690, 350);
                }
            }
            return new Vector2(-100, -100); //non-reachable
        }
      
        public void Update()
        {
            if (_ally)
            {
                _position.X += Speed;
            }
            else
            {
                _position.X -= Speed;
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_ally)
            {
                spriteBatch.Draw(_texture, _position, new Rectangle(0, 0, 1090, 861), Color.White, 0f, new Vector2(612, 438), new Vector2(0.1f, 0.1f), SpriteEffects.None, 1f);
            } else
            {
                spriteBatch.Draw(_texture, _position, new Rectangle(0, 0, 1090, 861), Color.White, 0f, new Vector2(612, 438), new Vector2(0.1f, 0.1f), SpriteEffects.FlipHorizontally, 1f);
            }
        
        }
    }
}
