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
        //private string filePath = "C:\\temp";
        public string fileName = "Quiz.csv";
        public List<Questions> questions = new List<Questions>();
        //public List<Answers> answers = new List<Answers>();

        public void readCSV()
        {
          //  string file = filePath + "\\" + fileName;
            using (StreamReader reader = new StreamReader(fileName))
            {
                using (TextFieldParser parser = new TextFieldParser(reader))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    int i = 0;
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        i++;
                        string q = fields[0];
                        string a1 = fields[1];
                        string a2 = fields[2];
                        string a3 = fields[3];
                        string correct = fields[4];
                        Answers answer1 = new Answers();
                        Answers answer2 = new Answers();
                        Answers answer3 = new Answers();
                        Int32.TryParse(correct, out int intcorrect);
                        switch (correct)
                        {
                            case "1":
                                answer1 = Answers.newAnswer(a1, 0, true);
                                answer2 = Answers.newAnswer(a2, 1, false);
                                answer3 = Answers.newAnswer(a3, 2, false);
                                break;
                            case "2":
                                answer1 = Answers.newAnswer(a1, 0, false);
                                answer2 = Answers.newAnswer(a2, 1, true);
                                answer3 = Answers.newAnswer(a3, 2, false);
                                break;
                            case "3":
                                answer1 = Answers.newAnswer(a1, 0, false);
                                answer2 = Answers.newAnswer(a2, 1, false);
                                answer3 = Answers.newAnswer(a3, 2, true);
                                break;
                            default:
                                answer1 = Answers.newAnswer(a1, 0, false);
                                answer2 = Answers.newAnswer(a2, 1, false);
                                answer3 = Answers.newAnswer(a3, 2, false);
                                break;
                        }

                        List<Answers> listAnswers = new List<Answers>();
                        listAnswers.Add(answer1);
                        listAnswers.Add(answer2);
                        listAnswers.Add(answer3);

                        //Questions question = new Questions();
                        Questions question = Questions.addQuestion(q, listAnswers, intcorrect, i);
                        questions.Add(question);
                    }
               }
            }

        }
    }
}
