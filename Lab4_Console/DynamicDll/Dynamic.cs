using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDll
{
    public class Dynamic
    {
        public static double[,] MultiplicationMatrixD(double[,] a, double[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) { throw new Exception("Матрицы нельзя перемножить"); }
 
            int ma = a.GetLength(0);
            int mb = b.GetLength(0);
            int nb = b.GetLength(1);
 
            double[,] r = new double[ma, nb];
 
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < nb; j++)
                {
                    for (int k = 0; k < mb; k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }
    }
}
