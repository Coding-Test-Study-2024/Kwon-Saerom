using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CordingStudy_CS.Week11_CS
{
    using tup = Tuple<int, int, int>;
    internal class BOJ7576
    {
        // 왼, 오, 앞, 뒤
        static int[] moveX = {-1, 1, 0, 0 };
        static int[] moveY = {0, 0, 1, -1 };

        public static void Main7576(string[] args)
        {
            // 입력
            string[] inputs = Console.ReadLine().Split(' ');
            int M = int.Parse(inputs[0]);
            int N = int.Parse(inputs[1]);

            int[,] tomato = new int[N, M];
            for (int j = 0; j < N; j++)
            {
                string[] input = Console.ReadLine().Split(' ');
                for (int k = 0; k < M; k++)
                {
                    tomato[j, k] = int.Parse(input[k]);
                }
            }


            // 토마토 익히기(BFS) 한꺼번에 익혀야함.
            int answer = BFS(tomato, M, N);

            //0이 없는지 검사하기
            for (int j = 0; j < N; j++)
            {
                for (int k = 0; k < M; k++)
                {
                    if (tomato[j, k] == 0)
                    {
                        answer = -1;
                        break;
                    }
                }
            }
            Console.WriteLine(answer);
        }

        public static int BFS(int[,] tomato, int M, int N)
        {
            int day = 0;
            Queue<tup> q = new Queue<tup>();
            for (int j = 0; j < N; j++)
            {
                for (int k = 0; k < M; k++)
                {
                    if (tomato[j, k] == 1)
                    {
                        q.Enqueue(new tup(j, k, 0));
                    }
                }
            }

            while (q.Count > 0)
            {
                tup t = q.Dequeue();
                day = t.Item3;
                for (int i = 0; i < moveX.Length; i++)
                {
                    // 인덱스 검사
                    int X = t.Item2 + moveX[i];
                    int Y = t.Item1 + moveY[i];

                    if (X < 0 || X >= M)
                        continue;
                    if (Y < 0 || Y >= N)
                        continue;

                    // 0이면 큐에 넣기.
                    if (tomato[Y, X] == 0)
                    {
                        tomato[Y, X] = 1;
                        q.Enqueue(new tup(Y, X, day + 1));
                    }
                }
            }

            return day;
        }
    }
}
