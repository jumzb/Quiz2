using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace Q
{
    public class QuizReader
    {
        private string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public string fileName = "Quiz.csv";
        public List<Questions> questions = new List<Questions>();
        //public List<Answers> answers = new List<Answers>();

        public void readCSV()
        {
            string file = filePath + "\\" + fileName;
            using (StreamReader reader = new StreamReader(filePath))
            {
                using (TextFieldParser parser = new TextFieldParser(reader))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        foreach (string field in fields)
                        {
                            // split row into 1 question & 3 answers
                            string[] quizarray = field.Split(",");
                            string q = quizarray[0];
                            string a1 = quizarray[1];
                            string a2 = quizarray[2];
                            string a3 = quizarray[3];
                            string correct = quizarray[3];
                            Answers answer1 = new Answers();
                            Answers answer2 = new Answers();
                            Answers answer3 = new Answers();
                            // convert into objects Answers & Questions
                            int intcorrect = Int32.Parse(correct);
                            switch (correct)
                            {
                                case "1":
                                    answer1 = Answers.newAnswer(a1, 0, true);
                                    answer2 = Answers.newAnswer(a2, 0, false);
                                    answer3 = Answers.newAnswer(a3, 0, false);
                                    break;
                                case "2":
                                    answer1 = Answers.newAnswer(a1, 0, false);
                                    answer2 = Answers.newAnswer(a2, 0, true);
                                    answer3 = Answers.newAnswer(a3, 0, false);
                                    break;
                                case "3":
                                    answer1 = Answers.newAnswer(a1, 0, false);
                                    answer2 = Answers.newAnswer(a2, 0, false);
                                    answer3 = Answers.newAnswer(a3, 0, true);
                                    break;
                                default:
                                    answer1 = Answers.newAnswer(a1, 0, true);
                                    answer2 = Answers.newAnswer(a2, 0, false);
                                    answer3 = Answers.newAnswer(a3, 0, false);
                                    break;
                            }

                            List<Answers> listAnswers = new List<Answers>();
                            listAnswers.Add(answer1);
                            listAnswers.Add(answer2);
                            listAnswers.Add(answer3);

                            Questions question = new Questions();
                            question = Questions.addQuestion2(q, listAnswers, intcorrect, i);
                            questions.Add(question);                            
                        }
                    }
                }
            }

        }
    }
}
