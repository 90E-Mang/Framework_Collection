using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ex09_01_Generic_Team_Homework
{
    class Quiz_ask
    {
        private Random random;
        private int rand1;
        private int rand2;
        private Dictionary<string, string> x;

        public Quiz_ask()
        {
            random = new Random();
            x = new Dictionary<string, string>();
        }

        public void quizStart()
        {
            for (int i = 0; i < 5; i++)
            {
                rand1 = random.Next(1, 10);
                rand2 = random.Next(1, 10);

                Console.Write($"{rand1} * {rand2} = ");
                string answer = Console.ReadLine();

                string result = (Quiz_answer(rand1, rand2) == Convert.ToInt32(answer)) ? "O" : "X";
                if (result == "O")
                {
                    Console.WriteLine("정답입니다.");

                }
                else
                {
                    Console.WriteLine("오답입니다.");
                }
                x.Add($"문제 : {rand1}*{rand2} 쓴답 : {answer}", $" 채점 : {result}");
            }
        }
        private int Quiz_answer(int rand1, int rand2)
        {
            return rand1 * rand2;
        }

        public void print()
        {
            foreach (var x in x)
            {
                Console.WriteLine($"{x.Key} {x.Value}");
            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Quiz_ask quiz = new Quiz_ask();
            quiz.quizStart();
            quiz.print();
        }
    }
}
