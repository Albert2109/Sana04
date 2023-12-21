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
}
