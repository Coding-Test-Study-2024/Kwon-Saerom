using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CordingStudy_CS.Week_12
{
    internal class BOJ11047
    {
        // 그리디 대표문제
        public static void Main11047(string[] args)
        {
            // 입력 받기
            string[] input = Console.ReadLine().Split(' ');
            int N = int.Parse(input[0]);
            int K = int.Parse(input[1]);

            // 코인 등록
            List<int> coin = new List<int>();
            while(N-->0)
            {
                int n = int.Parse(Console.ReadLine());
                coin.Add(n);
            }

            // 계산하기
            int answer = 0;
            for(int i=coin.Count-1;i>=0;i--)
            {
                answer += K / coin[i];
                K %= coin[i];
                if (K == 0)
                    break;
            }

            Console.WriteLine(answer);
        }
    }
}
