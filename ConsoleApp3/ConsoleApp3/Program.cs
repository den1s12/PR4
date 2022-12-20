using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            float NN = 300;
            float zz = 1;
            float kk = 0.5f;
            float nn = 1;
            float vv = 0;
            float ww = 0;

            int i = 0;
            int D = 50;
            float[] A = new float[6] { 0, 0, 0, 0, 0, 0 };
            float n0 = nn;
            for (i=0;i<D;i++)

            {
                Console.WriteLine($"i = {i + 1} z = {zz:f1} v {vv:f1} n = {nn:f1} w = {ww:f1} NN-nn-ww {(NN - nn - ww )}");
                if (i >5) { vv = A[(i % 6)];}
                A[i % 6] = zz;

                zz = kk * (NN - nn - ww) / (NN - n0) * nn;
                nn = nn + zz - vv;
                ww = ww + vv;
                Console.ReadLine();
            }
        }
    }
}
