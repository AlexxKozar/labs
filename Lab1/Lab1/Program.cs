/*
Варіант 11
N шестеpенок пpонумеpованы от 1 до N (N<=10). 
Заданы M (0<=M<=45) соединений паp шестеpенoк в виде (i,j), 1<=i<j<=N (шестеpня с номеpом i находится в зацеплении с шестеpней j).
Можно ли повеpнуть шестеpню с номеpом 1?
Если да, то найти количество шестеpен, пpишедших в движение.
Если нет, то тpебуется убpать минимальное число шестеpен так, чтобы в оставшейся системе пpи вpащении шестеpни 1 во вpащение пpишло бы максимальное число шестеpен. Указать номеpа убpанных шестеpен ( если такой набоp не один, то любой из них ) и количество шестеpен, пpишедших в движение.
 */


using System;
using System.Collections;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0, m;
            int[,] Matrix = new int[n, n];
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter number of nodes (max 10): ");
                    n = Convert.ToInt32(Console.ReadLine());
                    if (n > 10)
                    {
                        throw new Exception("You have't seen? 10 is maximum!!!!");
                    }
                    Matrix = new int[n, n];

                    Console.WriteLine("1 - fill matrix by hands");
                    Console.WriteLine("2 - fill matrix by random");
                    Console.WriteLine("Your desicion: ");

                    int desocion = Convert.ToInt32(Console.ReadLine());

                    if (desocion == 1)
                    {
                        Console.WriteLine("Enter number of connections: ");
                        m = Convert.ToInt32(Console.ReadLine());
                        fullMatrixHands(ref Matrix, m);
                        normalize(ref Matrix, n);
                        printMatrix(Matrix, n);

                    }
                    else if (desocion == 2)
                    {
                        fullMatrixRandom(ref Matrix, n);
                        normalize(ref Matrix, n);
                        printMatrix(Matrix, n);

                    }
                    else
                    {
                        Console.WriteLine("Wrong input. Please write correct number...");
                        continue;
                    }



                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Something was wrong... Please try again");
                    Console.WriteLine();
                }

                //Checking on possibility to rotate 1 item, writing rotation derections to dirArray
                bool possible = true;
                int[] dirArray = isPossible(Matrix, n, ref possible);

                //Printing results
                Console.Write("The rotation direction (0 left, 1 right, -1 doesn't rotate): ");
                for (int i = 0; i < n; i++)
                    Console.Write(dirArray[i] + " ");
                Console.WriteLine();


                while (!possible)
                {
                    // Finding the element to delete
                    int index = findIndex(Matrix, n, dirArray);

                    // Deleting the element
                    Delete(ref Matrix, ref n, index);


                    //Printing the results
                    Console.WriteLine();
                    Console.WriteLine("New matrix");
                    printMatrix(Matrix, n);
                    Console.WriteLine();

                    if (n == 2)
                    {
                        possible = true;
                        Console.WriteLine("Is possible to rotate 1 item: " + possible);
                        break;
                    }

                    //Trying to rotate again
                    dirArray = isPossible(Matrix, n, ref possible);

                    //Printing results
                    Console.Write("The rotation direction (0 left, 1 right, -1 doesn't rotate): ");
                    for (int i = 0; i < n; i++)
                        Console.Write(dirArray[i] + " ");
                    Console.WriteLine();



                }

                int k=0;
                for ( int i = 0; i < n; i++)
                {
                    if (dirArray[i] != -1)
                        k++;
                }

                Console.WriteLine("Number or rotating items: " + k);

                break;

            }
            Console.ReadKey();
        }

        public static int[,] fullMatrixHands(ref int[,] M, int max)
        {
            Console.WriteLine("Enter node in format i j (numeration from 1):");
            String input;
            while (max-- > 0 && (input = Console.ReadLine()).Length > 0)
            {
                String[] temp = input.Split(" ");
                int m = Convert.ToInt32(temp[0]);
                int n = Convert.ToInt32(temp[1]);
                m--;
                n--;
                M[m, n] = M[n, m] = 1;
            }
            Console.WriteLine("Matrix filling is finished!");
            return M;
        }

        public static int[,] fullMatrixRandom(ref int[,] M, int n)
        {
            Console.WriteLine("Random matrix genetation...");
            Console.WriteLine("Number of nodes variates from 1 to 45");
            Random rand = new Random();
            int tmp = rand.Next(1, 45);
            Console.WriteLine("Number of nodes: " + tmp);

            for (int i = 0; i < tmp; i++) {
                int temp1 = rand.Next(0, n);
                int temp2 = rand.Next(0, n);
                M[temp1, temp2] = M[temp2, temp1] = 1;
            }

            return M;
        }

        public static void normalize(ref int [,] M, int n)
        {
            for(int i=0; i < n; i++)
            {
                for(int j=0; j<n; j++)
                {
                    if (i == j)
                        M[i, j] = 0;
                }
            }
        }

        public static void printMatrix(int[,] M, int size) {
            Console.WriteLine("Adjacency matrix: ");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(M[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static int[] isPossible(int[,] M, int n, ref bool result)
        {
            result = true;
            int[] dirArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                dirArray[i] = -1;
            }

            dirArray[0] = 0;

            Queue queue = new Queue();
            queue.Enqueue(0);

            while (queue.Count != 0)
            {
                int node = Convert.ToInt32(queue.Dequeue());
                for (int i = 0; i < n; i++)
                {
                    if (M[i, node] == 1)
                    {
                        if (dirArray[i] == -1) {
                            dirArray[i] = (dirArray[node] + 1) % 2;
                            queue.Enqueue(i);
                        } else
                        if (dirArray[i] == dirArray[node]) {
                            result = false;
                        }

                    }
                }

            }

            Console.WriteLine("Is possible to rotate 1 item: " + result);
            Console.WriteLine();

            return dirArray; 
            
        }

        public static int findIndex(int[,] M, int n, int[] dirArray)
        {

            int sum = 0, maxSum = 0, index = 0;
            for (int i = 0; i < n; i++)
            {
                if (sum > maxSum)
                {
                    maxSum = sum;
                    index = i;
                }
                sum = 0;
                bool tmp = false;

                for (int j = 0; j < n; j++)
                {

                    if (M[i, j] == 1 && (dirArray[j] == dirArray[i]))
                    {   if (j == 1)
                        {
                            tmp = true;
                            break;
                        }
                             
                        sum++;
                    }
                }
                if (tmp)
                {
                    break;
                }
            }

            Console.WriteLine("MaxSum: " + maxSum);
            Console.WriteLine("Index of the node to be deleted (numeration from 1): " + (index+1));

            return index;
        }

        public static void Delete (ref int[,] M, ref int n, int num){

            n--;
            int[,] N = new int[n, n];


            for(int i=0; i<n; i++)
            {
                for(int j=num; j< n; j++)
                {
                    M[i, j] = M[i, j + 1];
                }
            }

            for (int i = num; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    M[i, j] = M[i+1, j];
                }
            }

            for(int i=0; i<n; i++)
            {
                for(int j=0; j<n; j++)
                {
                    N[i, j] = M[i, j];
                }
            }


            M = N;
        }

    }
}
