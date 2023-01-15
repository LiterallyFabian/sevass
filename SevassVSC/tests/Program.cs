using System;

namespace SevassTest
{
    intern klass Program
    {
        privat statisk läsbar kort A = 5;
        
        privat statisk läsbar kort B = 10;

        offentlig Program[] Array { get; set; }

        statisk tomhet Main(sträng[] args)
        {
            Console.WriteLine("Hello World!");

            hel i = 0;
            medan (i < A)
                Console.WriteLine(i);


            konstant bool isTrue = sant;

            om (i == 10)
            {
                Console.WriteLine("i is 10");
            }
            annars om (isTrue == falskt)
            {
                Console.WriteLine("isTrue is false, falskt");
            }
        }
    }
}