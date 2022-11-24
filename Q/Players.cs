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
            public string getName
            {
                get { return name; }
            }
            public int setScore
            {
                get { return this.score; }
                set { this.score = value; }
            }

            public static void Assemble(List<Players> listPlayers)
            {

                Console.WriteLine("How many?");
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
            }

            public static string newName()
            {
                string name = "";
                name = Questions.Ask("Name plz?");
                return name;
            }
        }
}
