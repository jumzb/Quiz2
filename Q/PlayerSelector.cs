using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q
{
    public class PlayerSelector
    {
        // pass player to class
        // return correct player based on enum
        //public powerUpName powerUp;
        public Players player;
        public Quiz quiz;
        public List<Players> players;

        public Players getAffectedPlayer(PowerUps powerup)
        {
            powerUpName powerupname;
            powerupname = powerup.getPowerUpName;
            switch (powerupname)
            {
                case powerUpName.ShootYourNeighbour:
                    
                    break;

                case powerUpName.ShootanOpponent:
               
                    break;

                case powerUpName.GoWithout:
            
                    break;

                case powerUpName.GreenShell:
             
                    break;

                case powerUpName.RedShell:
                 
                    break;

                case powerUpName.BigUp:
                
                    break;
            }
        }
            
    }
}
