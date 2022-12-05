using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q;

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
            ClearScreen();
            int countTo3 = 0;
            foreach (Questions question in questions)
            {
                countTo3++;
                foreach (Players player in players)
                {
                    
                    if (countTo3 == 1)
                    {
                        Random rnd = new Random();
                        int chooseMeaPowerUp = rnd.Next(7);
                        //countTo3 = 0;
                        //player.addPowerup(powerUpName[]);
                        Array powerupnames = typeof(powerUpName).GetEnumValues();
                        powerUpName powerup = (powerUpName)powerupnames.GetValue(chooseMeaPowerUp);
                        player.addPowerup(powerup);
                        Console.WriteLine(powerup.ToString());
                    }
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
                    Console.Write("Press Enter"); PauseandClear();
                }
            }
        }
        public static void ClearScreen()
        {
            Console.Clear();
        }
        public static void PauseandClear()
        {
            Console.ReadLine();
            Console.Clear();
        }
    }
}
