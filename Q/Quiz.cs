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
            List<Questions> questions= new List<Questions>();
            players = Players.Assemble();
            questions = Questions.Assemble();
           //Console.Clear();
            foreach (Questions question in questions)
            {
                foreach (Players player in players)
                {
                    Console.WriteLine(player.getName + ". It's your turn to play. Please answer the following question A, B or C");
                    question.writeQuestion();
                    string useranswer = Questions.Ask(player, "Please type your answer below.");
                    player.answered = question.getAnswer(useranswer, question);
                    if (player.answered.test())
                    {
                        Console.WriteLine("correct");
                    }
                    else
                    {
                        Console.WriteLine("wrong");
                    }
                    question.showCorrectAnswer();
                }
            }
        }
    }
}
