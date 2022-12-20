using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Math.Sin(1));
            SI(1);

        }
        public static double SI(double x)
        {

            double an = x;
            double SI = 0;
            int sign = -1;
            int n = 0;
            
            while (Math.Abs(an)>0.0000000000001)
            {

                SI += an;
                an = sign * x * x / (2 * n + 2) / (2 * n + 3) * an;
                n += 1;
                Console.WriteLine(SI);
                Console.ReadLine();
            }
            return SI;
        }
    }
}

