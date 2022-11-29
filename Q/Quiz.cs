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
            List<Questions> questions = new List<Questions>();
            players = Players.Assemble();
            questions = Questions.Assemble();
            foreach (Questions question in questions)
            {
                foreach (Player player in players)
                {
                    Console.WriteLine(player.getName + ". It's your turn to play. Please answer the following question A, B or C");
                    question.writeQuestion();
                    string useranswer = Questions.Ask(player, "?> ");
                    question.getAnswer(useranswer, question);
                    Console.Clear();
                }
            }
        }
    }
}
