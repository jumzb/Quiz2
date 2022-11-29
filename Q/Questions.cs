using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q
{
    public class Questions
    {
        private string question;
        private string index;
        private int correctanswer;
        public List<Answers> answers;

        public static Questions newQuestion(string questionText, Answers answerA, Answers answerB, Answers answerC, int correctAnswer)
        {
            Questions question = new Questions();
            question.question = questionText;
            question.correctanswer = correctAnswer;
            List<Answers> answers = new List<Answers>();
            answers.Add(answerA);
            answers.Add(answerB);
            answers.Add(answerC);
            question.answers = answers;
            return question;
        }

        public static List<Questions> Assemble()
        {
            List<Questions> questions = new List<Questions>();
            questions.Add(Questions.addQuestion("What is A?", "A", "B", "C", 1));
            questions.Add(Questions.addQuestion("What is B?", "A", "B", "C", 2));
            questions.Add(Questions.addQuestion("What is C?", "A", "B", "C", 3));
            return questions;
        }

        public static Questions addQuestion(string questiontext, string answera, string answerb, string answerc, int correctanswer)
        {
            bool correctorno1 = false;
            bool correctorno2 = false;
            bool correctorno3 = false;

            switch (correctanswer)
            {
                case 1: correctorno1 = true; break;
                case 2: correctorno2 = true; break;
                case 3: correctorno3 = true; break;
            }

            Answers answerA = new Answers(answera,1,correctorno1);
            Answers answerB = new Answers(answerb,2,correctorno2);
            Answers answerC = new Answers(answerc,3, correctorno3);

            return Questions.newQuestion(questiontext, answerA, answerB, answerC, correctanswer);
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
            Answers answer = new Answers("",0,false);
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
    }

}
