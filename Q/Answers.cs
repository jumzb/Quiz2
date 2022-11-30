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
        public Answers(string Answer, int Index, bool CorrectAnswer)
        {
            index = Index;
            correctaswer = CorrectAnswer;
            answer = Answer;
        }

        public void show()
        {
            string letter = "";
            switch (index)
            {
                case 1:
                    letter = "A";
                    break;
                case 2:
                    letter = "B";
                    break;
                case 3:
                    letter = "C";
                    break;
            }
            Console.WriteLine(letter + ") " + answer);
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
