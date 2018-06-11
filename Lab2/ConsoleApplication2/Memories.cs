using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApplication2
{
    public class Memories
    {
        List<allTime> memorie = new List<allTime>();

        public Memories()
        {
        }

        public Memories(allTime triad)
        {
            memorie.Add(triad);
        }

        public void AddTriad(allTime triad)
        {
            memorie.Add(triad);
        }

        public void ShowInfo()
        {
            foreach (allTime element in memorie)
            {
                element.data.ToString();
                element.time.ToString();
            }
        }

        public void Remove(int index)
        {
            if (index > 0 && index < memorie.Count)
                memorie.RemoveAt(index);
            else throw new MyIndexOutOfRangeException();
        }

        public void ChangeData(int index, int day, int month, int year, int hour, int minute, int second)
        {
            if (index > 0 && index < memorie.Count)
            {
                int iter = 0;
                foreach (allTime element in memorie)
                {
                    if (iter == index)
                    {
                        element.data.First = day;
                        element.data.Second = month;
                        element.data.Third = year;
                        element.time.First = hour;
                        element.time.Second = minute;
                        element.time.Third = second;
                        break;
                    }

                    iter++;
                }
            }
            else throw new MyIndexOutOfRangeException();
        }
       

        public List<allTime> DeepCopy()
        {
            List<allTime> copy = new List<allTime>();
            foreach (allTime element in memorie)
            {
                copy.Add(element);
            }

            return copy;
        }

        public void early()
        {
            Console.WriteLine("Early:");
            var result = from allTime in memorie
                orderby allTime.data.Third, allTime.data.Second, allTime.data.First, allTime.time.First, allTime.time
                    .Second, allTime.time.Third
                select allTime;
            foreach (allTime element in result)
            {
                element.data.ToString();
                element.time.ToString();
                break;
            }
            Console.WriteLine();
        }
        public void late()
        {
            Console.WriteLine("Late:");
            var result = from allTime in memorie
                orderby allTime.data.Third, allTime.data.Second, allTime.data.First, allTime.time.First, allTime.time
                    .Second, allTime.time.Third
                select allTime;
            int iter = 0;
            int iter2 = 0;
            foreach (allTime element in result)
            {
                iter++;
            }
            foreach (allTime element in result)
            {
                iter2++;
                if (iter == iter2)
                {
                    element.data.ToString();
                    element.time.ToString();
                }
            }
            Console.WriteLine();
        }
    }
}