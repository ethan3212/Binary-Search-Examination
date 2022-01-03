using System;
using System.Diagnostics;
using static System.Console;

namespace Lab_03
{
    class Program
    {
        const int N = 100;
        const int TRYS = 10;
        static int loopCount = 0;
        static int level = 0;
        static int averageLevel = 0;

        static void Main(string[] args)
        {
            Random r = new Random();
            Stopwatch SW = new Stopwatch();
            int[] list = new int[N];

            for(int i = 0; i<N; i++)
            {
                list[i] = r.Next(1, N + 1);
            }

            Array.Sort(list);

            foreach (int i in list)
            {
                Write(i + " ");
            }

            int target;
            int index;
            double elapsed = 0;

            for(int t=0; t<TRYS; t++)
            {
                target = r.Next(1, N + 1);
                SW.Restart();
                index = BinarySearch(list, target, N);
                SW.Stop();
                elapsed += SW.Elapsed.TotalMilliseconds;
                WriteLine(" ");
                WriteLine("Target = " + target + ": index = " + index + ": level = " + level + ":");
                averageLevel = level;
                level = 0;
            }

            WriteLine("The average loopcount is: " + (double) loopCount / TRYS);
            WriteLine("The average level is :" + (double) averageLevel / TRYS);
            WriteLine("Time elapsed is: " + (double)elapsed / TRYS);
            ReadLine();

            static int BinarySearch (int[] list, int target, int max)
            {
                int start = 0;
                int end = max;

                while(start <= end)
                {
                    int middle = (start + end) / 2;

                    switch(list[middle].CompareTo(target))
                    {
                        case -1: start = middle + 1;
                            loopCount += 1;
                            level += 1;
                            break;
                        case 0: return middle;
                            loopCount += 1;
                            level += 1;
                            break;
                        case 1: end = middle - 1;
                            loopCount += 1;
                            level += 1;
                            break;
                    }
                }

                loopCount = max;
                level = 0;
                return -1;
            }
        }
    }
}
