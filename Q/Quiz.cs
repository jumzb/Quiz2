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
            int currentPlayerGetsPowerUp = 0; // count to 3 to give every 3rd question a powerup
            foreach (Questions question in questions)
            {
                currentPlayerGetsPowerUp++;
                foreach (Players player in players)
                {
                    if (currentPlayerGetsPowerUp == 2)
                    {
                        currentPlayerGetsPowerUp = 0;
                        player.earnRandomPowerup();
                    }
                    Console.WriteLine(player.getName + ". It's your turn to play. Please answer the following question A, B or C");
                    question.writeQuestion();
                    string useranswer = Questions.Ask(player, "Please type your answer below.");
                    player.answered = question.getAnswer(useranswer, question);
                    // use powerups
                    if (player.checkForPowerups())
                    {
                        player.showPowerUps();
                        PowerUps selectedpowerup = player.selectPowerUp();
                        player.usePowerUp(selectedpowerup, players);
                    }
;
                    //
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
