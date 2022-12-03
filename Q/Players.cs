﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q
{
    public class Players
    {   
        private string name;
        private int score;
        private int index;
        public Answers answered;
        public PowerUps activePowerup;
        private List<PowerUps> listPowerUps;

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
                    listPlayers[i].clearScore();
                }
            }
            else
            {
                Environment.Exit(5);
            }
            return listPlayers;
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

        public void usePowerUp(PowerUps powerUp, Players chosenPlayer)
        {
            switch (powerUp.getPowerUpName)
            {
                case powerUpName.ShootYourNeighbour:
                case powerUpName.ShootanOpponent:
                    chosenPlayer.losePoint();
                    break;

                case powerUpName.GreenShell:
                case powerUpName.RedShell:
                case powerUpName.GoWithout:
                    chosenPlayer.skipTurn();
                    break;

                case powerUpName.BigUp:
                    chosenPlayer.addPoint();               
                    break;
            }
        }
    }
}
