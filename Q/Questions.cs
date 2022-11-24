using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q
{
    public class Questions
    {
        public Questions()
        {
            string questionText;
            Answers answerA;
            Answers answerB;
            Answers answerC;
            Answers correctAnswer;
        }
        private string question;
        private string index;
        private string correctAnswer;
        private List<Answers> answers;

        public static List<Questions> Assemble()
        {
            string questiontext = ""


            List<Questions> questions = new List<Questions>();
            questions.Add(new Questions(questiontext, answera, answerb, answerc, correctanswer));
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
