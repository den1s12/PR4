using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            double N = 1000, n=0, z = 5, v = 0.0, w = 0.0, k = 0.5;
            int i;
            int D = 100;
            {
                for (i = 1; i < D; i++);
                {
                    z = k * (N - v - w) / N * n;
                        if (i % 7 == 0);
                    {
                        double temp = 0;
                        v = temp;
                        temp = z;
                    }
                    w = w + v;
                    N = n + z;
                }
                Console.WriteLine($"{n} {w} \n");
            }
        }
    }
}
