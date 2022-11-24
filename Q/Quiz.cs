using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q
{
    public class Quiz
    {
        public static void Play()
        {
            List<Players> players = new List<Players>();
            Players.Assemble(players);
            Questions.Assemble(questions);
            foreach (var question in questions)
            {
                foreach (var player in players)
                {

                }
            }
        }
    }
}
