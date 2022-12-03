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
       //Players playerAffected;
        powerUpName powerupname;
        string name;
        string tagLine;
    
        public string getName
        {
            get { return name;}
        }

        public powerUpName getPowerUpName
        {
            get { return powerupname; }
        }
         
        public static PowerUps newPowerUp(powerUpName powerupname)
        {
            PowerUps powerUp = new PowerUps();
            powerUp.inUse = false;
            string tagLine;
            switch (powerupname)
            {
                case powerUpName.ShootYourNeighbour:
                    powerUp.name = "Shoot Your Neighbour";
                    powerUp.effect = Effects.KillPoint;
                    tagLine = "You shot your neighbour! Pew Pew";
                  //  powerUp.playerAffected = allPlayers[(allPlayers.IndexOf(currentPlayer)+1)];
                    break;

                case powerUpName.ShootanOpponent:
                    powerUp.name = "Shoot an Opponent";
                    powerUp.effect = Effects.KillPoint;
                    tagLine = "Ooh damn! Shots fired!";
                    break;

                case powerUpName.GoWithout:
                    powerUp.name = "Go Without";
                    powerUp.effect = Effects.KillPoint;
                    tagLine = "Sitting this one out huh?";
                    break;

                case powerUpName.GreenShell:
                    powerUp.name = "Green Shell";
                    powerUp.effect = Effects.MissTurn;
                    tagLine = "No copyright Mario references here, just an innocent shell";
                    break;

                case powerUpName.RedShell:
                    powerUp.name = "Red Shell";
                    powerUp.effect = Effects.MissTurn;
                    tagLine = "No copyright Mario references here, just an innocent shell";
                    break;

                case powerUpName.BigUp:
                    powerUp.name = "Big Up";
                    powerUp.effect = Effects.MissTurn;
                    tagLine = "Bigups to ";
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
