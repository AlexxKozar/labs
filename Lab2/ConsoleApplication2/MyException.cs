using System;

namespace ConsoleApplication2
{
        public class MyException : Exception
        {
            public MyException() {
                Console.WriteLine("Write correct values!");
            }
        }

        public class MyIndexOutOfRangeException : Exception
        {
            public MyIndexOutOfRangeException()
            {
                Console.WriteLine("Index out of range!");
            }
        }
    
    }