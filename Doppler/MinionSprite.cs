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
        SpriteEffects effect;

        public float Speed = 1.5f;
        public static int manaCost = 2;

        //static image rectangle
        public static Rectangle sourceRectangle;

        public MinionSprite(int lane, bool ally)
        {
            _texture = Game1.content.Load<Texture2D>("characters/chicken");
            _ally = ally;
            _position = getPositionByLane(lane);
            sourceRectangle = new Rectangle(0, 0, 550, 434);
        }

        public MinionSprite(int lane) : this(lane, true){}

        public Vector2 getPositionByLane(int lane)
        {
            if (_ally)
            {
                switch (lane)
                {
                    case 0: return new Vector2(170, 80);
                    case 1: return new Vector2(170, 230);
                    case 2: return new Vector2(170, 380);
                }
            }else
            {
                switch (lane)
                {
                    case 0: return new Vector2(720, 80);
                    case 1: return new Vector2(720, 230);
                    case 2: return new Vector2(720, 380);
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

        public void Draw(SpriteBatch spriteBatch, Rectangle sourceRectangle)
        {
            if (_ally)
            {
                effect = SpriteEffects.None;
            } else
            {
                effect = SpriteEffects.FlipHorizontally;
            }
            spriteBatch.Draw(_texture, _position, sourceRectangle, Color.White, 0f, new Vector2(612, 438), new Vector2(0.15f, 0.15f), effect, 1f);

        }
    }
}
