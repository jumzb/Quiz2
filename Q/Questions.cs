using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q
{
    public class Questions
    {
        private string? question;
        private int? index;
        private int correctanswer;
        public List<Answers>? answers;

        public static List<Questions> Assemble()
        {
            QuizReader quizReader = new QuizReader();
            quizReader.readCSV();
            return quizReader.questions;
           
        }

        public static Questions newQuestion(string questiontext, List<Answers>answerlist, int correctanswer, int index)
        {
            Questions question = new Questions();
            question.question = questiontext;
            question.answers = answerlist;
            question.correctanswer = correctanswer;
            question.index = index;
            return question;
        }

        public void writeQuestion()
        {
            Console.WriteLine("Question " + index + ": " + question);
            foreach (Answers answer in this.answers)
            {
                answer.show();
            }
        }

        public static string Ask(Players p, string q)
        {
            string userAnswer = "";
            Console.WriteLine(q);
            userAnswer = Console.ReadLine();
            return userAnswer;
        }
        public Answers getAnswer(string selectedAnswer, Questions question)
        {
            Answers answer = new Answers() //.newAnswer("",0,false);
            switch (selectedAnswer)
            {
                case "a":
                case "A":
                    {
                        answer = question.answers[0];
                    }
                    break;

                case "b":
                case "B":
                    {
                        answer = question.answers[1];
                    }
                    break;

                case "c":
                case "C":
                    {
                        answer = question.answers[2];
                    }
                    break;
            }

            return answer;
        }
        
        public int getCorrectAnswerIndex
        {
            get { return correctanswer; }
        }

        public void showCorrectAnswer()
        {
            foreach (Answers answer in this.answers)
            {
                if (answer.test())
                {
                    answer.show();
                }
            }
        }

    }

}
