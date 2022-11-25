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
            Console.WriteLine("The answer is: " + index.ToString() + ") " + answer);
        }
        public bool test()
        {
            return true;
        }
    }
}
