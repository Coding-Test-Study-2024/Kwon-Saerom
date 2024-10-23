using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CordingStudy_CS.Week_12
{
    internal class BOJ9461
    {
        // DP?
        public static void Main9461(string[] args)
        {
            // 삼각형 규칙 저장하기
            List<long> P = new List<long>();
            P.Add(0);
            P.Add(1);
            P.Add(1);
            P.Add(1);
            P.Add(2);
            P.Add(2);
            for(int i = 6;i<=100;i++)
                P.Add(P[i - 1] + P[i - 5]);

            // 입력받기
            int T = int.Parse(Console.ReadLine());
            while(T-->0)
            {
                int N = int.Parse(Console.ReadLine());
                Console.WriteLine(P[N]);
            }
        }
    }
}
