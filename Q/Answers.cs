using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q
{
    public class Answers
    {
        private int index;
        private string answer;
        private bool correctaswer;
    
        public static Answers newAnswer(string Answer, int Index, bool CorrectAnswer)
        {
            Answers answer = new Answers();
            answer.index = Index;
            answer.correctaswer = CorrectAnswer;
            answer.answer = Answer;
            return answer;
        }

        public void show()
        {
            string letter = "";
            switch (index)
            {
                case 0:
                    letter = "A";
                    break;
                case 1:
                    letter = "B";
                    break;
                case 2:
                    letter = "C";
                    break;
            }
            Console.WriteLine(letter + ". " + answer);
        }

        public bool test()
        {
            bool result;
            if (correctaswer)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public int getIndex
        {
            get { return index; }
        }

        public override string ToString()
        {
            return answer;
        }

    }
}
