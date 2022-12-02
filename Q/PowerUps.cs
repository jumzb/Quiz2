using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q
{
    public class PowerUps
    {
        bool inUse;
        Effects effect;
        List<Effects> effectsList;
        Players owner;
        Players playerAffected;
        string name;


        public void apply()
        {

        }
        public PowerUps addPowerUp(powerUpName powerupname, Players currentPlayer)
        {
            PowerUps powerUp = new PowerUps();
            powerUp.inUse = false;

            switch (powerupname)
            {
                case powerUpName.ShootYourNeighbour:
                    powerUp.name = "Shoot Your Neighbour";
                    effect = Effects.MissTurn;
                    powerUp.effect = effect;
                    // playerAffected = 
                    break;

                case powerUpName.ShootanOpponent:
                    powerUp.name = "Shoot an Opponent";
                    effect = Effects.MissTurn;
                    powerUp.effect = effect;
                    break;
            }

            return powerUp;
        }
    }

    public enum powerUpName
    {
        ShootYourNeighbour, // Next person misses a turn
        ShootanOpponent, // Choose someone to miss a turn
        GoWithout, // You skip a turn
        Bomb, // everyone misses a turn

    }
}
