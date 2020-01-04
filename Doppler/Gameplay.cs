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
                        // if minions reach enemy
                        if(((AnimatedMinionSprite)AiSprite.minions[i])._position.X < 70)
                        {
                            GUI.UpdatePlayer1Health(GUI.getPlayer1Health() - 1);
                        }

                        if (((AnimatedMinionSprite)Sprite.minions[k])._position.X > 700)
                        {
                            GUI.UpdatePlayer2Health(GUI.getPlayer2Health() - 1);
                        }

                        // if minions collide together
                        if (((AnimatedMinionSprite)AiSprite.minions[i])._lane == ((AnimatedMinionSprite)Sprite.minions[k])._lane &&
                            ((AnimatedMinionSprite)AiSprite.minions[i])._position.X - ((AnimatedMinionSprite)Sprite.minions[k])._position.X < 70)
                        {
                            AiSprite.minions[i] = null;
                            Sprite.minions[k] = null;
                        }
                    }
                }
            }
        }

        public static void checkForWinCondition()
        {

        }

    }
}
