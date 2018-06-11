using System;
using System.Collections.Generic;

namespace ConsoleApplication2
 {
     public struct allTime
     {
         public Data data;
         public Time time;
     }
     internal class Program
     {
         public static void Main(string[] args)
         {
             allTime allTime1 = new allTime();
             allTime allTime2 = new allTime();
             allTime allTime3 = new allTime();
             allTime1.data = new Data(13, 1, 1999);
             allTime1.time = new Time(15,10,40);
             allTime2.data = new Data(16, 4, 1999);
             allTime2.time = new Time(20,0,4);
             allTime3.data = new Data(7, 5, 1976);
             allTime3.time = new Time(1,45,30);
             Memories memories = new Memories();
             memories.AddTriad(allTime1);
             memories.AddTriad(allTime2);
             memories.AddTriad(allTime3);
             memories.early();
             memories.late();
             Tests(memories);
            Console.Read();
         }
         public static void Tests(Memories memories)
         {
             Triad data1 = new Data(13, 1, 1999);
             if(data1.Equals( new Data(13, 1, 1999)))
                 Console.WriteLine("Method Equals is correct");
             else
                 Console.WriteLine("Method Equals is not correct");
             Data data2 = new Data(13, 1, 1999);
             if(data1.GetHashCode() == data2.GetHashCode())
                 Console.WriteLine("Method GetHashCode is correct");
             else
                 Console.WriteLine("Method GetHashCode is not correct");
             List<allTime> copy = new List<allTime>();
             copy = memories.DeepCopy();
             Console.WriteLine();
             Console.WriteLine("Test method DeepCopy:");
             foreach (allTime element in copy)
             {
                 element.data.ToString();
                 element.time.ToString();
             }
         }
     }
 }