using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
//using Q.PowerUps;

namespace Q
{
    public class Players
    {   
        private string name;
        private int score;
        private int index;
        public Answers answered;
        public PowerUps activePowerup;
        public List<PowerUps> listPowerUps;

        public string getName
        {
            get { return name; }
        }
        public int getScore
        {
            get { return this.score; }
        }

        public void addPoint()
        {
            this.score++;
        }
        public void losePoint()
        {
            this.score--;
        }
        public void clearScore()
        {
            this.score = 0;
        }

        public void setScore(int val)
        {
            this.score = val;
        }
        public void skipTurn()
        {
        }

        public static List<Players> Assemble()
        {
            List<Players> listPlayers = new List<Players>();
            Console.WriteLine("How many players?");
            if (Int32.TryParse(Console.ReadLine(), out int numPlayers))
            {
                for (int i = 0; i < numPlayers; i++)
                {
                    listPlayers.Add(new Players());
                    listPlayers[i].index = i;
                    listPlayers[i].name = Players.newName();
                    listPlayers[i].listPowerUps= new List<PowerUps>();
                    listPlayers[i].clearScore();
                }
            }
            else
            {
                Environment.Exit(5);
            }
            return listPlayers;
        }

        public string[] getPowerUpList
        {
            get
            {
                int i=0;
                if (listPowerUps != null)
                {
                    string[] poweruplist = new string[listPowerUps.Count + 1];
                    foreach (PowerUps powerup in listPowerUps)
                    {
                        poweruplist[i] = powerup.getName;
                        i++;
                    }
                    return poweruplist;
                }
                else 
                {
                    string[] nopowerups = new string[1];
                    nopowerups[0] = "No Powerups";
                    return nopowerups;
                }
            }
        }

        public static string newName()
        {
            string name = "";
            Console.WriteLine("Name plz?");
            name = Console.ReadLine();
            return name;
        }

        public void addPowerup(powerUpName name)
        {
            PowerUps powerup = PowerUps.newPowerUp(name);
            listPowerUps.Add(powerup);
        }



        public void usePowerUp(PowerUps powerUp, PlayerSelector playerSelector)
        {
            //PlayerSelector playerSelector = new PlayerSelector();
            Players player = new Players();
            switch (powerUp.getPowerUpName)
            {                
                case powerUpName.ShootYourNeighbour:
                    player = playerSelector.getAffectedPlayer(powerUp);
                    player.losePoint();
                    break;

                case powerUpName.ShootanOpponent:
                    player.losePoint();
                    break;

                case powerUpName.GreenShell:

                    break;
                case powerUpName.RedShell:

                case powerUpName.GoWithout:
                    player.skipTurn();
                    break;

                case powerUpName.BigUp:
                    player.addPoint();               
                    break;
            }
        }
    }
}
