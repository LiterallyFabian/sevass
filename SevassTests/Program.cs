using System;

namespace SevassTest
{
    internal class Program
    {
        private static readonly short A = 5;
        
        private static readonly short isfalse = 10;

        public Program[] Array { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int i = 0;
            while (i < A)
                Console.WriteLine(i);

            const bool isTrue = true;

            if (i == 10)
            {
                Console.WriteLine("i is 10");
            }
            else if (isTrue == false)
            {
                Console.WriteLine("isTrue is false, false");
            }
        }
    }
}