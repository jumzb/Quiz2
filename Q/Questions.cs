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
            QuizReader quizReader = new QuizReader();
            quizReader.readCSV();
            return quizReader.questions;
            //List<Questions> questions = new List<Questions>();
            //questions.Add(Questions.addQuestion("What's the answer to this question?", "Unknown", "Undefined", "Undescriptive", 2));
            //questions.Add(Questions.addQuestion("How you gonna do this question? 3", "1", "2", "3", 3));
            //questions.Add(Questions.addQuestion("What is the best football game to date?", "1966", "1996", "2006", 1));
            //return questions;
        }

        public static Questions addQuestion2(string questiontext, List<Answers>answerlist, int correctanswer, int index)
        {
            Questions question = new Questions();
            question.question = questiontext;
            question.answers = answerlist;
            question.correctanswer = correctanswer;
            question.index = index;
            return question;
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

            Answers answerA = Answers.newAnswer(answera,0,correctorno1);
            Answers answerB = Answers.newAnswer(answerb,1,correctorno2);
            Answers answerC = Answers.newAnswer(answerc,2, correctorno3);

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
            Answers answer = Answers.newAnswer("",0,false);
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
