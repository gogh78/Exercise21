using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Exercise21
{
    //Имеется пустой участок земли(двумерный массив) и план сада, который необходимо реализовать.
    //Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом.
    //Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо,
    //сделав ряд, он спускается вниз.
    //Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх,
    //сделав ряд, он перемещается влево.
    //Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше.
    //Садовники должны работать параллельно.
    //Создать многопоточное приложение, моделирующее работу садовников.
    class Program
    {
        const int n = 6;
        const int m = 5;

        static int[,] path = new int[n, m]
        {
            { 100, 20, 20, 30, 50 },
            { 50, 20, 30, 0, 10 },
            { 100, 20, 50, 30, 50 },
            { 10, 50, 10, 30, 40 },
            { 50, 20, 40, 70, 100 },
            { 20, 100, 10, 30, 20 }
        };
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Gardner1);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardner2();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{path[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        static void Gardner1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (path[i, j] >= 0)
                    {
                        int delay = path[i, j];
                        path[i, j] = -1;
                        Thread.Sleep(delay);
                    }
                }

            }
        }

        static void Gardner2()
        {
            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (path[j, i] >= 0)
                    {
                        int delay = path[j, i];
                        path[j, i] = -2;
                        Thread.Sleep(delay);
                    }
                }
            }
        }
    }
}
