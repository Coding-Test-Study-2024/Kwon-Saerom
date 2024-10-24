using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CordingStudy_CS.Week_12
{
    using tu = Tuple<int, string>;
    using funcTu = Tuple<Func<int, int>, char>;
    internal class BOJ9019
    {
        public static void Main9019(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            
            while (T-->0)
            {
                string[] input = Console.ReadLine().Split(' ');
                int A = int.Parse(input[0]);
                int B = int.Parse(input[1]);
                Console.WriteLine(BFS(A, B));
            }
        }

        public static string BFS(int a,int b)
        {
            funcTu[] funcs = { new funcTu(D,'D'), new funcTu(S, 'S') , new funcTu(L, 'L') , new funcTu(R, 'R') };
            List<bool> isCheck = new List<bool>();
            for (int i = 0; i <= 10000; i++)
                isCheck.Add(false);

            Queue<tu> q = new Queue<tu>();
            q.Enqueue(new tu(a, ""));
            isCheck[a] = true;

            while(q.Count > 0)
            {
                tu item = q.Peek();
                int num = item.Item1;

                //정답시 바로 리턴
                if (num == b)
                    return item.Item2;

                for(int i=0;i<funcs.Length;i++)
                {
                    int tmp = funcs[i].Item1(num);
                    if (tmp >= 0 && tmp <= 10000 && isCheck[tmp] == false)
                    {
                        q.Enqueue(new tu(tmp, item.Item2 + funcs[i].Item2));
                        isCheck[tmp] = true;
                    }
                }
                q.Dequeue();
            }

            return null; //그런 경우가 없다. -> 그런 입력은 주어지지 않는다.
        }

        public static int D(int num){ return (num * 2) % 10000; }
        public static int S(int num){ return num - 1 < 0 ? 9999 : num - 1; }
        public static int L(int num){ return (num % 1000) * 10 + num / 1000; }
        public static int R(int num){ return (num % 10) * 1000 + (num / 10); }

    }
}
