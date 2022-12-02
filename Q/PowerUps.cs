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
       // List<Effects> effectsList;
        Players owner;
       // Players playerAffected;
        string name;
        string tagLine;

        public void apply()
        {

        }

        public static PowerUps addPowerUp(powerUpName powerupname, Players currentPlayer)
        {
            PowerUps powerUp = new PowerUps();
            powerUp.inUse = false;

            switch (powerupname)
            {
                case powerUpName.ShootYourNeighbour:
                    powerUp.name = "Shoot Your Neighbour";
                    powerUp.effect = Effects.KillPoint;
                    string tagLine = "You shot your neighbour! Pew Pew";
                    // playerAffected = 
                    break;

                case powerUpName.ShootanOpponent:
                    powerUp.name = "Shoot an Opponent";
                    powerUp.effect = Effects.KillPoint;
                    string tagLine = "Ooh damn! Shots fired!";
                    break;

                case powerUpName.GoWithout:
                    powerUp.name = "Go Without";
                    powerUp.effect = Effects.KillPoint;
                    string tagLine = "Sitting this one out huh?";
                    break;

                case powerUpName.GreenShell:
                    powerUp.name = "Green Shell";
                    powerUp.effect = Effects.MissTurn;
                    string tagLine = "No copyright Mario references here, just a ";
                    break;

                case powerUpName.RedShell:
                    powerUp.name = "Red Shell";
                    powerUp.effect = Effects.MissTurn;
                    break;

                case powerUpName.BigUp:
                    powerUp.name = "Big Up";
                    powerUp.effect = Effects.MissTurn;
                    break;
            }

            return powerUp;
        }
    }

    public enum powerUpName
    {
        ShootYourNeighbour, // Next person loses a point
        ShootanOpponent, // Choose someone to lose a point
        GoWithout, // You skip a turn and gain the point
        GreenShell, // Next person loses a turn
        RedShell, // Choose someone to lose a turn
        BigUp, // Nominate a player to have double points for a round
        Bomb, // everyone misses a turn
    }
}
