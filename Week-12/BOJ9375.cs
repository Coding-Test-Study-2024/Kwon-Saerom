using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CordingStudy_CS.Week_12
{
    internal class BOJ9375
    {
        public static void Main9375(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            Dictionary<string, int> dic = new Dictionary<string, int>();
            while(T-->0)
            {
                dic.Clear();

                // 입력을 받는다.
                int n = int.Parse(Console.ReadLine());
                while(n-->0)
                {
                    string[] input = Console.ReadLine().Split();
                    if (dic.ContainsKey(input[1]))
                        dic[input[1]] += 1;
                    else
                        dic.Add(input[1], 2); // 입지않는 경우도 포함해서
                }

                // 풀이 시작
                // 경우의 수 계산 (전체 경우 곱함 - 1(알몸상태))
                int answer = 1;
                foreach (int c in dic.Values)
                    answer *= c;
                answer -= 1;

                Console.WriteLine(answer);
            }
        }
    }
}
