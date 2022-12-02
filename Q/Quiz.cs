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
            ClearScreen();
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
                    ClearScreen();
                    if (player.answered.test())
                    {
                        Console.Write("correct the answer is: ");
                    }
                    else
                    {
                        Console.Write("incorrect the answer is: ");
                    }
                    question.showCorrectAnswer();
                    Console.Write("Press Enter"); ClearandPause();
                }
            }
        }
        public static void ClearScreen()
        {
            Console.Clear();
        }
        public static void ClearandPause()
        {
            Console.ReadLine();
            Console.Clear();
        }
    }
}
