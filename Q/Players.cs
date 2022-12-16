using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
//using Q.PowerUps;

namespace Q
{
    public class Players
    {
        private string name;
        private int score;
        private int index;
        public bool skipFlag;
        public Answers answered;
        public PowerUps activePowerup;
        public List<PowerUps> listPowerUps;

        public override bool Equals(object obj)
        {
            var other = obj as Players;

            if (other == null)
            {
                return false;
            }

            if (name != other.name || index != other.index)
            {
                return false;
            }

            return true;
        }

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
            skipFlag = true;
        }

        public static string newName()
        {
            string name = "";
            Console.WriteLine("Name plz?");
            name = Console.ReadLine();
            return name;
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
                    listPlayers[i].listPowerUps = new List<PowerUps>();
                    listPlayers[i].clearScore();
                }
            }
            else
            {
                Environment.Exit(5);
            }
            return listPlayers;
        }

        ///////////////////// PLAYER POWERUPS

        public bool checkForPowerups()
        {
            bool isNullOrEmpty = listPowerUps?.Any() != true;
            return !isNullOrEmpty;
            //{
            //    if (!isNullOrEmpty)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
        }

        public void showPowerUps()
        {
            string[] playerPowerUps = getPowerUpList;
            int i = 0;
            foreach (string powerupstring in playerPowerUps)
            {
                if (powerupstring != null)
                {
                    i++;
                    Console.WriteLine(i.ToString() + ". " + powerupstring);
                }
            }
        }

        public int selectPowerUp()
        {
            Console.WriteLine("Use a powerup? (choose number)");

            string s = Console.ReadLine();
            int selection = -1;
            if (Int32.TryParse(s, out int intpowerupselected))
            {
                if ((intpowerupselected <= listPowerUps.Count) && (intpowerupselected > 0)) 
                {
                    int powerupindex = intpowerupselected - 1;
                    selection = powerupindex;
                }
                else
                {
                    selection = -1;
                }
            }
            return selection;
        }


        public void earnRandomPowerup()
        {
            Random rnd = new Random();
            int chooseMeaPowerUp = rnd.Next(7);
            Array powerupnames = typeof(powerUpName).GetEnumValues();
            powerUpName powerup = (powerUpName)powerupnames.GetValue(chooseMeaPowerUp);
            addPowerup(powerup);
            Console.WriteLine("You gained a " + powerup.ToString());
        }

        public string[] getPowerUpList
        {
            get
            {
                int i = 0;
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

        public void addPowerup(powerUpName name)
        {
            PowerUps powerup = PowerUps.newPowerUp(name);
            listPowerUps.Add(powerup);
        }

        public void usePowerUp(PowerUps powerUp, List<Players> allPlayers)
        {
            //PlayerSelector playerSelector = new PlayerSelector();
            //playerSelector.allPlayers = allPlayers;
            //playerSelector.currentPlayer = this;
            Players player = new Players();
            MyConsole.ReadLine(this.getName + " used " + powerUp.getName + ".");
            MyConsole.ReadLine("It's very effective");
            Quiz.ClearScreen();

            switch (powerUp.getPowerUpName)
            {
                case powerUpName.ShootYourNeighbour:
                    // player = getAffectedPlayer(allPlayers);
                    player = getNextPlayer(allPlayers);
                    player.losePoint();
                    MyConsole.ReadLine(player.getName + ". You lose!");
                    MyConsole.ReadLine("-1 point");
                    break;

                case powerUpName.ShootanOpponent:
                    player = choosePlayer(allPlayers);
                    player.losePoint();
                    MyConsole.ReadLine(player.getName + ". You lose!");
                    MyConsole.ReadLine("-1 point");
                    break;

                case powerUpName.GreenShell:
                    player = getNextPlayer(allPlayers);
                    player.skipTurn();
                    MyConsole.ReadLine(player.getName + ". Skip a turn friend.");
                    MyConsole.ReadLine("Not my friend buddy? Skip a turn anyway.");
                    break;

                case powerUpName.RedShell:
                    //  player = getAffectedPlayer(allPlayers);
                    player = choosePlayer(allPlayers);
                    player.skipTurn();
                    MyConsole.ReadLine(player.getName + ". Skip a turn buddy.");
                    MyConsole.ReadLine("Not my friend pal? Skip a turn anyway.");
                    break;

                case powerUpName.GoWithout:
                    skipTurn();
                    MyConsole.ReadLine(player.getName + ". Just gonna sit this one out?");
                    break;

                case powerUpName.BigUp:
                    MyConsole.ReadLine(player.getName + " big up yoself!");
                    addPoint();
                    break;

                case powerUpName.Bomb:
                    foreach (Players players in allPlayers)
                    {
                        if (!(players.Equals(player)))
                        {
                            players.skipTurn();
                        }
                    }
                    break;
            }

            listPowerUps.RemoveAt(listPowerUps.IndexOf(powerUp));
        }

        ////////////////////////////// PLAYER SELECTOR

        private Players choosePlayer(List<Players> allPlayers)
        {
            int i = 0;
            foreach (Players player in allPlayers)
            {
                i++;
                Console.WriteLine(i.ToString() + ". " + player.getName);
            }

            string playerinfo = MyConsole.ReadLine("Please select a player");
            if (playerinfo != null)
            {
                if (Int32.TryParse(playerinfo, out int playerselected))
                {
                    if (playerselected <= allPlayers.Count)
                    {
                        int playerindex = playerselected - 1;
                        return allPlayers[playerindex];
                    }
                }
                else
                {
                    Console.WriteLine("YOU LOSE! ERROR: 0xUHAD1JOB");
                    Console.ReadLine();
                    return null;
                }
                Console.WriteLine("Out of loop. ERROR: CODER IS WHACK");
                Console.ReadLine();
                return null;
            }
            else
            {
                return allPlayers[0];
            }
        }

        private Players getNextPlayer(List<Players> allPlayers)
        {
            int indexcount = allPlayers.Count - 1;
            int playerpos = allPlayers.IndexOf(this);
            int nextplayer = playerpos + 1;
            if (nextplayer >= indexcount)
            {
                nextplayer = 0;
            }
            else
            {
                nextplayer = playerpos + 1;
            }
            return allPlayers[nextplayer];
        }
    }
}


    //public class PlayerSelector
    //{
    //    // pass player to class
    //    // return correct player based on enum
    //    //public powerUpName powerUp;
    //    public Players currentPlayer;
    //    // public Quiz quiz;
    //    public List<Players> allPlayers;


    //    //public Players getAffectedPlayer(PowerUps powerup, List<Players> allPlayers)
    //    //{
    //    //    Players affectedPlayer = new Players();
    //    //    powerUpName powerupname;
    //    //    powerupname = powerup.getPowerUpName;
    //    //    switch (powerupname)
    //    //    {
    //    //        case powerUpName.ShootYourNeighbour:
    //    //        case powerUpName.GreenShell:
    //    //            affectedPlayer = getNextPlayer(allPlayers);
    //    //            break;

    //    //        case powerUpName.ShootanOpponent:
    //    //        case powerUpName.RedShell:
    //    //        case powerUpName.BigUp:
    //    //            affectedPlayer = choosePlayer(allPlayers);
    //    //            break;

    //    //        case powerUpName.GoWithout:
    //    //            affectedPlayer = this;
    //    //            break;
    //    //    }
    //    //    return affectedPlayer;
    //    //}
    //}

