using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab21
{
        class Program
    {

        public static int a;   // длина
        public static int b;    // ширина
        public static int[,] array;

        public static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Введите размеры садового участка");
                Console.Write("Длина = ");
                a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ширина = ");
                b = Convert.ToInt32(Console.ReadLine());
                array = new int[a, b];
            Console.WriteLine();
            Console.WriteLine("Вот участок:");
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    array[i, j] = 0;
                    Console.Write($"{array[i, j],3}  ");
                }
                Console.WriteLine();
            }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Thread myThread1 = new Thread(Garden1);         // поток для садовника 1
            Thread myThread2 = new Thread(Garden2);         // поток для садовника 2
            myThread1.Start();
            myThread2.Start();
            myThread1.Join();
            myThread2.Join();

            Console.WriteLine("Садовники поработали:");
            for (int i = 0; i < a; i++)                         // вывод итогового участка
            {
                for (int j = 0; j < b; j++)
                {
                    if (array[i, j] == 1)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                    {
                        if (array[i, j] == 2)
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        else
                            Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write($"{array[i, j],3}  ");
                    Thread.Sleep(10);
                }
                Console.WriteLine();
            }

            Console.ReadKey();

        }

        public static void Garden1()
        {
            for (int i = 0; i < a ; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (array[i, j] == 0)
                        array[i, j] = 1;
                    Thread.Sleep(5);

                }
                Console.WriteLine();
            }
        }

        public static void Garden2()
        {
            {

                for (int i = a - 1; i >=0; i--)
                {
                    for (int j = b - 1; j >=0; j--)
                    {
                        if (array[i, j] == 0)
                            array[i, j] = 2;
                        Thread.Sleep(5);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
