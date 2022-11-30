using System;
using System.Collections.Generic;
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
            public List<PowerUps> powerUps;

            public string getName
            {
                get { return name; }
            }
            public int getScore
            {
                get { return this.score; }
            }
            public void addScore()
            {
                this.score++;
            }
            public void clearScore
            {
                this.score = 0;
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
                        listPlayers[i].setScore = 0;
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
        }
}
