using System;

namespace ConsoleApplication2
{
    public class Time : Triad
    {
        public Time(int first, int second, int third) : base(first, second, third)
        {
        }


        public override void increment()
        {
            if (++third == 60)
            {
                third = 0;
                if (++second == 60)
                {
                    second = 0;
                    if (++first == 24)
                    {
                        first = 0;
                    }
                }
            }
            else third++;
        }

        public override void ToString()
        {
            Console.WriteLine("Time - "+first+":"+second+":" + third);
        }

        public override bool IsCorrect(int first, int second, int third)
        {
            return IsPositive(first, second, third) && first < 24 && second < 60 && third < 60;
        }
    }
}