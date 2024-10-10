using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CordingStudy_CS.Week10_CS
{
    internal class BOJ1074
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int N = int.Parse(input[0]);
            int r = int.Parse(input[1]);
            int c = int.Parse(input[2]);

            Console.WriteLine(Search(N,r,c));
        }


        public static int Search(int N,int r,int c)
        {
            int k;
            int minusR = 0, minusC = 0;

            double powResult = Math.Pow(2, N - 1);

            //0,1면
            if(powResult > r)
            {
                if (powResult > c)
                    k = 0;
                else
                {
                    k = 1;
                    minusC = (int)powResult;
                }
            } //2,3면
            else
            {
                if (powResult > c)
                    k = 2;
                else
                {
                    k = 3;
                    minusC = (int)powResult;
                }
                minusR = (int)powResult;
            }

            int tmp = (int)Math.Pow(powResult, 2) * k;
            if (N == 1)
                return k;
            return tmp + Search(N - 1, r - minusR, c - minusC);
        }
    }
}
