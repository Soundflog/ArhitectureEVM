using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Reflection;
using BiblsDll;
using DynamicDll;

namespace Lab4_Console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Вычисляет площадь прямоугольника с заданными координатами.
            Zadanie1();
            // Вычисляет время перемножения двух матриц произвольного размера.
            Zadanie2();
        }

        private static void Zadanie1()
        {
            Console.WriteLine("Задайте координаты для прямоугольника:");
            Console.Write("X1= ");
            string x1 = Console.ReadLine();
            Console.Write("Y1= ");
            string y1 = Console.ReadLine();
            Console.Write("X2= ");
            string x2 = Console.ReadLine();
            Console.Write("Y2= ");
            string y2 = Console.ReadLine();
            Console.WriteLine("Площадь прямоугольника: " + 
                              StaticDll.RectangleArea(x1, y1, x2, y2));
        }

        private static void Zadanie2()
        {
            Random rnd = new Random();
            int len = rnd.Next(100, 500);
            Console.WriteLine("Длина массивов: " + len);
            double[,] matrix1 = new double[len, len];
            double[,] matrix2 = new double[len, len];
            matrix1 = Zapolenenie(matrix1);
            matrix2 = Zapolenenie(matrix2);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            double[,] outmatrix = DynamicDll.Dynamic.MultiplicationMatrixD(matrix1, matrix2);
            // for (int i = 0; i < outmatrix.GetLength(0); i++)
            // {
            //     for (int j = 0; j < outmatrix.GetLength(1); j++)
            //     {
            //         Console.WriteLine(matrix1[i, j] + " * " + matrix2[i, j] + " = " + outmatrix[i, j]);
            //     }
            // }
            
            Console.WriteLine("Время выполнения: " + stopwatch.ElapsedMilliseconds + " мс");
            stopwatch.Stop();
        }

        private static double[,] Zapolenenie(double[,] matrix)
        {
            Random rnd = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(0, 10);
                }
            }

            return matrix;
        }
    }
}