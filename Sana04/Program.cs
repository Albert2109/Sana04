using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Введіть n-стовбців");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введіть m-рядків");
        int m = int.Parse(Console.ReadLine());
        int[,] arr = new int[n, m];
        Random rand = new Random();
        int kilkistdodatnixelementiv = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                arr[i, j] = rand.Next(-20, 20);
            }
        }

        Console.WriteLine("Отримана матриця:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(arr[i, j] + " ");
            }
            Console.WriteLine();
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (arr[i, j] >= 0)
                {
                    kilkistdodatnixelementiv++;
                }
            }
        }

        Console.WriteLine("Кількість додатніх елементів в масиві = " + kilkistdodatnixelementiv);

        int maxvalue = FindMaxValue(arr);
        int kilkistmaxvalue = CountMaxValue(arr, maxvalue);

        Console.WriteLine("Максимальне число: " + maxvalue);
        Console.WriteLine("Кількість максимального числа: " + kilkistmaxvalue);

        int countzeroline = NOCountnozeroline(arr);
        Console.WriteLine("Кількість рядків без нульового елемента: " + countzeroline);

        int countzerocolumm = Countzerocolumm(arr);
        Console.WriteLine("Кількість стовпців, які містять хоча б один нульовий елемент: " + countzerocolumm);
        int longestSeriesRow = FindLongestSeriesRow(arr);
        Console.WriteLine("номер рядка, в якому знаходиться найдовша серія однакових елементів " + longestSeriesRow);
        Console.WriteLine("Добуток елементів в рядках, де немає від'ємних елементів:");

        for (int i = 0; i < n; i++)
        {
            if (!RowContainsNegatives(arr, m, i))
            {
                int product = ProductRow(arr, m, i);
                Console.WriteLine($"Рядок {i + 1}: {product}");
            }
        }
    
    int maxSum = FindMaxParallelDiagonalSum(arr, n, m);
        Console.WriteLine("максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці  "+maxSum);
        Console.WriteLine("Суми елементів в стовбцях, де немає від'ємних елементів:");

        for (int j = 0; j < m; j++)
        {
            if (!ColumnContainsNegatives(arr, n, j))
            {
                int sum = SumColumn(arr, n, j);
                Console.WriteLine($"Стовпець {j + 1}: {sum}");
            }
        }
    


}

    static int FindMaxValue(int[,] arr)
    {
        int maxvalue = int.MinValue;

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] > maxvalue)
                {
                    maxvalue = arr[i, j];
                }
            }
        }

        return maxvalue;
    }

    static int CountMaxValue(int[,] arr, int maxvalue)
    {
        int count = 0;

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] == maxvalue)
                {
                    count++;
                }
            }
        }

        return count;
    }

    static int NOCountnozeroline(int[,] arr)
    {
        int countzeroline = 0;

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            bool hasZero = false;

            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] == 0)
                {
                    hasZero = true;
                    break;
                }
            }

            if (!hasZero)
            {
                countzeroline++;
            }
        }

        return countzeroline;
    }

    static int Countzerocolumm(int[,] arr)
    {
        int countzerocolumm = 0;

        for (int j = 0; j < arr.GetLength(1); j++)
        {
            bool hasZero = false;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (arr[i, j] == 0)
                {
                    hasZero = true;
                    break;
                }
            }

            if (hasZero)
            {
                countzerocolumm++;
            }
        }

        return countzerocolumm;
    }

    static int FindLongestSeriesRow(int[,] arr)
    {
        int longestSeriesRow = -1;
        int maxLength = 0;

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            int currentLength = 1;

            for (int j = 1; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] == arr[i, j - 1])
                {
                    currentLength++;
                }
                else
                {
                    currentLength = 1;
                }

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    longestSeriesRow = i;
                }
            }
        }

        return longestSeriesRow;
    }

    static bool RowContainsNegatives(int[,] arr, int m, int rowIndex)
    {
        for (int j = 0; j < m; j++)
        {
            if (arr[rowIndex, j] < 0)
            {
                return true;
            }
        }
        return false;
    }

    static int ProductRow(int[,] arr, int m, int rowIndex)
    {
        int product = 1;

        for (int j = 0; j < m; j++)
        {
            product *= arr[rowIndex, j];
        }

        return product;
    }

static int FindMaxParallelDiagonalSum(int[,] arr, int n, int m)
    {
        int maxSum = int.MinValue;

        
        for (int j = 0; j < m; j++)
        {
            int diagonalSum = 0;
            for (int i = 0; i < n && i + j < m; i++)
            {
                diagonalSum += arr[i, i + j];
            }
            maxSum = Math.Max(maxSum, diagonalSum);
        }

       
        for (int i = 1; i < n; i++)
        {
            int diagonalSum = 0;
            for (int j = 0; j < m && i + j < n; j++)
            {
                diagonalSum += arr[i + j, j];
            }
            maxSum = Math.Max(maxSum, diagonalSum);
        }

        return maxSum;
    }
    static bool ColumnContainsNegatives(int[,] arr, int n, int columnIndex)
    {
        for (int i = 0; i < n; i++)
        {
            if (arr[i, columnIndex] < 0)
            {
                return true;
            }
        }
        return false;
    }

   

    static int SumColumn(int[,] arr, int n, int columnIndex)
    {
        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            sum += arr[i, columnIndex];
        }

        return sum;
    }
}