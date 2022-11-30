using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Pusk
{
    internal class Program
    {
        private static Random rnd = new Random();
        private static Stopwatch stopwatch = new Stopwatch();
        private static int[,] matrix = new int[1000, 1000];
        private static int[,] matrix2 = (int[,]) matrix.Clone();
        private static int rows = matrix.GetUpperBound(0) + 1;
        private static int columns = matrix.GetUpperBound(1) + 1;
        
        public static void Main(string[] args)
        {
            stopwatch.Restart();
            Multiply(matrix, matrix2);
            Console.WriteLine("Умножение матриц: " + stopwatch.ElapsedMilliseconds + " (мс)");
            stopwatch.Restart();
            Sorting(matrix);
            Console.WriteLine("Сортировка: " + stopwatch.ElapsedMilliseconds + " (мс)");
        }

        static void Multiply(int[,] arr1, int[,] arr2)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    arr1[i, j] = rnd.Next(9999);
                    arr2[i, j] = rnd.Next(9999);
                    arr1[i, j] *= arr2[i, j];
                }
            }
        }

        static void Sorting(int[,] arr1)
        {
            int temp;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns - 1; j++)
                {
                    for (int k = i + 1; k < columns; k++)
                    {
                        if (arr1[i, j] > arr1[i, k])
                        {
                            temp = arr1[i, j];
                            arr1[i, j] = arr1[i, k];
                            arr1[i, k] = temp;
                        }
                    }
                }
            }
            //PrintMatrix(arr1);
        }

        static void PrintMatrix(int[,] array)
        {
            Console.WriteLine();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(array[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}