using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CordingStudy_CS.Week10_CS
{
    internal class BOJ1012
    {
        //상, 하, 좌, 우
        static int[] moveX = { 0, 0, -1, 1 };
        static int[] moveY = { -1, 1, 0, 0 };
        public static void Main1012(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
        
            while(T-- > 0)
            {
                // 입력
                string[] input = Console.ReadLine().Split(" ");
                int M = int.Parse(input[0]);
                int N = int.Parse(input[1]);
                int K = int.Parse(input[2]);

                int[,] arr = new int[N, M];
                while(K-- > 0)
                {
                    string[] input2 = Console.ReadLine().Split(" ");
                    int X = int.Parse(input2[0]);
                    int Y = int.Parse(input2[1]);
                    arr[Y, X] = 1;
                }

                int answer = 0;
                for(int i=0;i<N;i++)
                {
                    for(int j=0;j<M;j++)
                    {
                        if (arr[i, j] == 1)
                        {
                            answer++;
                            BFS(j, i, arr);
                        }
                    }
                }

                Console.WriteLine(answer);
            }
        }

        public static void BFS(int startX,int startY,int[,] arr)
        {
            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
            
            q.Enqueue(new Tuple<int, int>(startX, startY));
            arr[startY, startX] = 0; //방문함

            while (q.Count() > 0)
            {
                Tuple<int, int> t = q.Peek();
                for (int i = 0; i < 4; i++)
                {
                    int X = t.Item1 + moveX[i];
                    int Y = t.Item2 + moveY[i];
                    if (X >= arr.GetLength(1) || Y >= arr.GetLength(0) || X < 0 || Y < 0)
                        continue;
                    if (arr[Y, X] == 1)
                    {
                        q.Enqueue(new Tuple<int, int>(X, Y));
                        arr[Y, X] = 0;
                    }
                }
                q.Dequeue();
            }
        }
    }
}
