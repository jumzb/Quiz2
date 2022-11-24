using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q
{
    public class Answers
    {
        private string index;
        private string answer;
        private bool correctAnswer;
        public void show()
        {
            Console.WriteLine("The answer is: " + index + ") " + answer);
        }
    }
}
