namespace Lab5_TestingCPU;

public class Matrix
{
    int m; // количество строк
    int n; // количество столбцов

    static double[][] MatrixCreate(int rows, int cols)
    {
        // Создаем матрицу, полностью инициализированную
        // значениями 0.0. Проверка входных параметров опущена.
        double[][] result = new double[rows][];
        for (int i = 0; i < rows; ++i)
            result[i] = new double[cols]; // автоинициализация в 0.0
        return result;
    }

    static string MatrixAsString(double[][] matrix)
    {
        string s = "";
        for (int i = 0; i < matrix.Length; ++i)
        {
            for (int j = 0; j < matrix[i].Length; ++j)
                s += matrix[i][j].ToString("F3").PadLeft(8) + " ";
            s += Environment.NewLine;
        }
        return s;
    }

}