using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CordingStudy_CS.Week_12
{
    using tu = Tuple<int, int>;
    // BFS
    internal class BOJ10026
    {
        static List<List<char>> list = new List<List<char>>();
        static int N;
        // 위, 아래, 왼, 오
        static int[] moveX = { 0, 0, -1, 1 };
        static int[] moveY = { -1, 1, 0, 0 };
        
        public static void Main(string[] args)
        {
            // 입력을 받는다.
            N = int.Parse(Console.ReadLine());
            for(int i=0;i<N;i++)
            {
                List<char> tmp = new List<char>();
                string input = Console.ReadLine();
                for(int j=0;j<N;j++)
                {
                    tmp.Add(input[j]);
                }
                list.Add(tmp);
            }

            //계산 시작.
            int gen = BFS((a, b) => { return a != b; });
            int r = BFS((a, b) => 
            {
                if (a == b)
                    return false;
                if (a == 'R' && b == 'G')
                    return false;
                if (a == 'G' && b == 'R')
                    return false;
                return true;
            });
            Console.WriteLine($"{gen} {r}");
        }

        public static int BFS(Func<char, char, bool> pre)
        {
            //BFS 시작
            List<List<bool>> isCheck = new List<List<bool>>();
            for (int i = 0; i < N; i++)
            {
                List<bool> tmp = new List<bool>();
                for (int j = 0; j < N; j++)
                    tmp.Add(false);
                isCheck.Add(tmp);
            }
            int count = 0;
            for(int i=0;i<N;i++)
            {
                for(int j=0;j<N;j++)
                {
                    if (isCheck[i][j] == false)
                    {
                        PlayBFS(j,i,pre, isCheck);
                        count++;
                    }
                }
            }

            return count;
        }

        public static void PlayBFS(int startX,int startY,Func<char, char, bool> pre, List<List<bool>> isCheck)
        {
            Queue<tu> q = new Queue<tu>();
            q.Enqueue(new tu(startX, startY)); //x,y,count
            isCheck[startY][startX] = true;

            while (q.Count > 0)
            {
                tu now = q.Peek();

                for (int i = 0; i < 4; i++)
                {
                    int X = now.Item1 + moveX[i];
                    int Y = now.Item2 + moveY[i];

                    if (X < 0 || X >= N || Y < 0 || Y >= N)
                        continue;
                    if (isCheck[Y][X] == true)
                        continue;

                    // 다른 구역일 때.
                    if (pre(list[now.Item2][now.Item1], list[Y][X]))
                        continue;

                    isCheck[Y][X] = true;
                    q.Enqueue(new tu(X, Y));
                }

                q.Dequeue();
            }
        }
    }
}
