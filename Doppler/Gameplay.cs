using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doppler
{
    class Gameplay
    {

        public static void checkForCollisions()
        {
            for (int i=0; i < AiSprite.minions.Count; i++)
            {
                for (int k=0; k<Sprite.minions.Count; k++)
                {
                    if (AiSprite.minions[i] != null && Sprite.minions[k] != null)
                    {
                        // if minions collide together
                        if (((AnimatedMinionSprite)AiSprite.minions[i])._lane == ((AnimatedMinionSprite)Sprite.minions[k])._lane &&
                            ((AnimatedMinionSprite)AiSprite.minions[i])._position.X - ((AnimatedMinionSprite)Sprite.minions[k])._position.X < 70)
                        {
                            AiSprite.minions[i] = null;
                            Sprite.minions[k] = null;
                            Game1.sounds[3].Play(0.2f, 0 ,0);
                        }
                    }
                }
            }
        }

        public static void checkForMinionsReachingEnd()
        {
            for (int i = 0; i < AiSprite.minions.Count; i++)
            {
                if (AiSprite.minions[i] != null && ((AnimatedMinionSprite)AiSprite.minions[i])._position.X < 150)
                {
                    GUI.UpdatePlayer1Health(GUI.getPlayer1Health() - 1);
                    AiSprite.minions[i] = null;
                    Game1.sounds[4].Play(0.4f, 0 , 0);
                }
            }
            for (int i = 0; i < Sprite.minions.Count; i++)
            {
                if (Sprite.minions[i] != null && ((AnimatedMinionSprite)Sprite.minions[i])._position.X > 750)
                {
                    GUI.UpdatePlayer2Health(GUI.getPlayer2Health() - 1);
                    Sprite.minions[i] = null;
                    Game1.sounds[4].Play(0.4f, 0, 0);
                }
            }
        }

        public static String checkForWinCondition()
        {
            if(GUI.getPlayer1Health() <= 0)
            {
                return "Player 2";
            }
            else if(GUI.getPlayer2Health() <= 0)
            {
                return "Player 1";
            }
            return "";
            
        }

    }
}
