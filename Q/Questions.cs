using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q
{
    public class Questions
    {
        public Questions(
            string questionText,
            Answers answerA,
            Answers answerB,
            Answers answerC,
            Answers correctAnswer
            )
        {
            question = questionText;
            correctanswer = correctAnswer;
        }
        private string question;
        private string index;
        private Answers correctanswer;
        private List<Answers> answers;

        public static List<Questions> Assemble()
        {
            int arraySize = 5;            
            string[] questiontext = new string[4];
            Answers[] answera = new Answers[4];
            Answers[] answerb = new Answers[4];
            Answers[] answerc = new Answers[4];
            Answers[] correctanswer = new Answers[4];



            List<Questions> questions = new List<Questions>();
            for (int i = 0; i < arraySize; i++)
            questions.Add(new Questions(questiontext[i], answera[i], answerb[i], answerc[i], correctanswer[i]));
        }

        public void writeQuestion()
        {
            Console.WriteLine("Question " + index + ": " + question);
            foreach (Answers answer in answers)
            {
                answer.show();
            }
        }

        public static string Ask(string q)
        {
            string userAnswer = "";
            Console.WriteLine(q);
            userAnswer = Console.ReadLine();
            return userAnswer;
        }
    }

}
