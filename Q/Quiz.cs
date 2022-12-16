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
            ///////////// INITIALISE PLAYERS & QUESTIONS
            List<Players> players = new List<Players>();
            List<Questions> questions = new List<Questions>();
            players = Players.Assemble();
            questions = Questions.Assemble();
            ClearScreen();

            ///////////// MAIN LOOP
            int currentPlayerGetsPowerUp = 0; // count to 3 to give every 3rd question a powerup
            foreach (Questions question in questions)
            {
                currentPlayerGetsPowerUp++;
                foreach (Players player in players)
                {
                    if (!player.skipFlag)
                    {
                        // Give powerups
                        if (currentPlayerGetsPowerUp == 3)
                        {
                            player.earnRandomPowerup();
                        }
                        // Player turn
                        Console.WriteLine(player.getName + ". It's your turn to play. Please answer the following question A, B or C");
                        question.writeQuestion();
                        string useranswer = Questions.Ask(player, "Please type your answer below.");
                        player.answered = question.getAnswer(useranswer, question);
                        ClearScreen();
                        if (player.answered.test())
                        {
                            Console.Write("correct the answer is: ");
                            player.addPoint();
                        }
                        else
                        {
                            Console.Write("incorrect the answer is: ");
                        }
                        question.showCorrectAnswer();
                        PauseandClear();
                        // Player powerup turn
                        if (player.checkForPowerups())
                        {
                            player.showPowerUps();
                            int selectedpowerup = player.selectPowerUp();
                            if (selectedpowerup > -1)
                            {
                                player.usePowerUp(player.listPowerUps[selectedpowerup], players);
                            }
                        }

                        // End of player turn
                    }
                    else
                    {
                        Console.WriteLine(player.getName + " skipped a turn :( sad day");
                        player.skipFlag = false;
                    }
                    PauseandClear();
                }
                PauseandClear();
                // END OF  ROUND - SCORES ON THE DOORS
                Console.WriteLine("-- THE SCORES ON THE DOORS --");
                foreach (Players player in players)
                {
                    Console.WriteLine(player.getName + " : " + player.getScore.ToString());
                }
                Console.Write("Next round. Press Enter"); PauseandClear();
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
