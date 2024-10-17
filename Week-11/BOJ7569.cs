using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CordingStudy_CS.Week11_CS
{
    using tup = Tuple<int, int, int, int>;
    internal class BOJ7569
    {
        // 위, 아래, 왼, 오, 앞, 뒤
        static int[] moveX = { 0, 0, -1, 1, 0, 0 };
        static int[] moveY = { 0, 0, 0, 0, 1, -1 };
        static int[] moveZ = { 1, -1, 0, 0, 0, 0 };


        public static void Main7569(string[] args)
        {
            // 입력
            string[] inputs = Console.ReadLine().Split(' ');
            int M = int.Parse(inputs[0]);
            int N = int.Parse(inputs[1]);
            int H = int.Parse(inputs[2]);

            int[,,] tomato = new int[H, N, M];
            for(int i=0;i<H;i++)
            {
                for(int j=0;j<N;j++)
                {
                    string[] input = Console.ReadLine().Split(' ');
                    for(int k = 0;k<M;k++)
                    {
                        tomato[i, j, k] = int.Parse(input[k]);
                    }
                }
            }


            // 토마토 익히기(BFS) 한꺼번에 익혀야함.
            int answer = BFS(tomato,M,N,H);

            //0이 없는지 검사하기
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < M; k++)
                    {
                        if (tomato[i,j,k] == 0)
                        {
                            answer = -1;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(answer);
        }

        public static int BFS(int[,,] tomato,int M,int N,int H)
        {
            int day = 0;
            Queue<tup> q = new Queue<tup>();
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < M; k++)
                    {
                        if (tomato[i, j, k] == 1)
                        {
                            q.Enqueue(new tup(i, j, k, 0));
                        }
                    }
                }
            }

            while(q.Count > 0)
            {
                tup t = q.Dequeue();
                day = t.Item4;
                for(int i=0;i<moveX.Length;i++)
                {
                    // 인덱스 검사
                    int X = t.Item3 + moveX[i];
                    int Y = t.Item2 + moveY[i];
                    int Z = t.Item1 + moveZ[i];

                    if (X < 0 || X >= M)
                        continue;
                    if (Y < 0 || Y >= N)
                        continue;
                    if (Z < 0 || Z >= H)
                        continue;

                    // 0이면 큐에 넣기.
                    if (tomato[Z,Y,X] == 0)
                    {
                        tomato[Z, Y, X] = 1;
                        q.Enqueue(new tup(Z,Y,X,day+1));
                    }
                }
            }

            return day;
        }
    }
}
