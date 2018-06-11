using System;

namespace ConsoleApplication2
{
    public class Data : Triad
    {
        public Data(int first, int second, int third) : base(first, second, third)
        {}

        public override void increment()
        {
            if (++first == 30)
            {
                third = 0;
                if (++second == 12)
                {
                    second = 0;
                    third++;
                }
            }
            else first++;
        }

        public override void ToString()
        {
            Console.WriteLine("Data: "+first+"/"+second+"/" + third);
        }

        public override bool IsCorrect(int first, int second, int third)
        {
            return IsPositive(first, second, third) && first < 24 && second < 60 && third < 60;
        }
    }
}