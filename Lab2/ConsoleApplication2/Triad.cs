using System;

namespace ConsoleApplication2
{
    public abstract class Triad
    {
        protected int first;
        protected int second;
        protected int third;

        public Triad(int first, int second, int third)
        {
            if(IsPositive(first, second, third)){
                this.first = first;
                this.second = second;
                this.third = third;
            }
            else throw new MyException();
        }

        public int First
        {

            get => first;
            set
            {
                if (first > 0)
                    first = value;
                else throw new MyException();
            }
        }

        public int Second
        {
            get => second;
            set
            {
                if (second > 0)
                    second = value;
                else throw new MyException();
            }
        }

        public int Third
        {
            get => third;
            set
            {
                if (third > 0)
                    third = value;
                else throw new MyException();
            }
        }
        protected bool IsPositive(int first, int second, int third)
        {
            return first >= 0 && second >= 0 && third >= 0;
        }

        public abstract void increment();
        public abstract void ToString();
        public abstract bool IsCorrect(int first, int second, int third);

        public bool Equals(Triad triad)
        {
            return triad.First == this.First && triad.Second == this.Second && triad.Third == this.Third;
        }

        public static bool operator ==(Triad triad1, Triad triad2)
        {
            return triad1.Equals(triad2);
        }
        
        public static bool operator !=(Triad triad1, Triad triad2)
        {
            return !triad1.Equals(triad2);
        }

        public int GetHashCode()
        {
            return first ^ second ^ third;
        }
    }
}