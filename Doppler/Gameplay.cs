using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doppler
{
    class Gameplay
    {

        public static void checkForCollisions(ArrayList minions1, ArrayList minions2)
        {
            for (int i=0; i < minions1.Count; i++)
            {
                for (int k=0; k<minions2.Count; k++)
                {
                    if (minions1[i] != null && minions2[k] != null)
                    {
                        // if minions collide together
                        if (((AnimatedMinionSprite)minions1[i])._lane == ((AnimatedMinionSprite)minions2[k])._lane &&
                            ((AnimatedMinionSprite)minions1[i])._position.X - ((AnimatedMinionSprite)minions2[k])._position.X < 70)
                        {
                            Sprite.minionsPerLane[((AnimatedMinionSprite)minions1[i])._lane]--; //AI correction
                            minions1[i] = null;
                            minions2[k] = null;
                            Game1.sounds[3].Play(0.2f, 0 ,0);
                        }
                    }
                }
            }
        }

        public static void checkForMinionsReachingEnd(ArrayList minions1, ArrayList minions2)
        {
            for (int i = 0; i < minions1.Count; i++)
            {
                if (minions1[i] != null && ((AnimatedMinionSprite)minions1[i])._position.X < 150)
                {
                    GUI.UpdatePlayer1Health(GUI.getPlayer1Health() - 1);
                    minions1[i] = null;
                    Game1.sounds[4].Play(0.4f, 0 , 0);
                }
            }
            for (int i = 0; i < Sprite.minions.Count; i++)
            {
                if (minions2[i] != null && ((AnimatedMinionSprite)minions2[i])._position.X > 750)
                {
                    GUI.UpdatePlayer2Health(GUI.getPlayer2Health() - 1);
                    minions2[i] = null;
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
