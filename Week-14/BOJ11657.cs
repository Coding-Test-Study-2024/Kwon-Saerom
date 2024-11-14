using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingStudy_CS.Week_14
{
    using tu = Tuple<int, int, int>;
    internal class BOJ11657
    {
        public static void Main(string[] args)
        {
            // 입력받기
            string[] input = Console.ReadLine().Split(' ');
            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);

            List<tu> edge = new List<tu>();
            for(int i=0;i<M;i++)
            {
                string[] input2 = Console.ReadLine().Split(' ');
                int A = int.Parse(input2[0]);
                int B = int.Parse(input2[1]);
                int C = int.Parse(input2[2]);
                edge.Add(new tu(A, B, C));
            }

            // 정답배열 초기화
            List<long> answer = new List<long>();
            for (int i = 0; i <= N; i++)
            {
                answer.Add(long.MaxValue);
            }
            answer[1] = 0; // 1에서부터 시작

            // 벨만-포드 알고리즘
            for (int i = 1; i < N; i++)
            {
                for(int j=0;j<M;j++)
                {
                    tu t = edge[j];
                    if (answer[t.Item1] != long.MaxValue)
                    {
                        long num = answer[t.Item1] + t.Item3;
                        if (num < answer[t.Item2])
                            answer[t.Item2] = num;
                    }
                }
            }

            // 음수 사이클이 있는지 확인
            bool isCircle = false;
            for(int i=0;i<M;i++)
            {
                tu t = edge[i];
                if (answer[t.Item1] != long.MaxValue)
                {
                    long num = answer[t.Item1] + t.Item3;
                    if (num < answer[t.Item2])
                    {
                        isCircle = true;
                        break;
                    }
                }
            }

            if(isCircle)
                Console.WriteLine(-1);
            else
            {
                for (int i = 2; i <= N; i++)
                {
                    if (answer[i] == long.MaxValue)
                        Console.WriteLine(-1);
                    else
                        Console.WriteLine(answer[i]);
                }
            }
        }
    }
}
