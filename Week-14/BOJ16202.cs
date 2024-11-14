using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingStudy_CS.Week_14
{
    using tu = Tuple<int, int>;
    internal class BOJ16202
    {
        static List<List<tu>> g = new List<List<tu>>();
        public static void Main16202(string[] args)
        {
            // 일단 입력받기
            string[] input = Console.ReadLine().Split(' ');
            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);
            int K = int.Parse(input[2]);

            for (int i = 0; i < N; i++)
                g.Add(new List<tu>());
            for(int i=0;i<M;i++)
            {
                string[] input2 = Console.ReadLine().Split(' ');
                int x = int.Parse(input2[0]);
                int y = int.Parse(input2[1]);
                g[x - 1].Add(new tu(y - 1, i + 1));
            }

            //BFS로 방문을 모두 해서 최소인 것들로 갱신.
            //만약 모두 방문이 안되면 0 넣기
            List<int> answer = MST(K);
            for(int i=0;i<answer.Count;i++)
                Console.WriteLine(answer[i]);
        }

        static List<int> MST(int K)
        {
            List<int> answer = new List<int>();
            while(K-->0)
            {
                int num = BFS();
                if(num == 0)
                {
                    while (K-- > 0)
                        answer.Add(0);
                    break;
                }
                answer.Add(num);
            }
            return answer;
        }
        static int BFS()
        {
            Queue<tu> q = new Queue<tu>();

            // 방문 리스트 초기화하기
            List<int> isMin = new List<int>();
            for (int i = 0; i < g.Count; i++)
                isMin.Add(int.MaxValue);

            // BFS 시작
            if (g[0].Count == 0)
            {
                DeleteMin();
                return 0;
            }

            q.Enqueue(new tu(g[0][0].Item1, g[0][0].Item2));
            isMin[g[0][0].Item1] = g[0][0].Item2;

            while(q.Count != 0)
            {
                tu t = q.Peek();
                for(int i = 0; i < g[t.Item1].Count;i++)
                {
                    int dest = g[t.Item1][i].Item1;
                    int weight = g[t.Item1][i].Item2;
                    q.Enqueue(new tu(dest, weight));
                    if (isMin[dest] > weight)
                        isMin[dest] = weight;
                }
            }

            DeleteMin();

            // 모두 더하기
            int sum = 0;
            for (int i = 0; i < isMin.Count; i++)
            {
                if (isMin[i] == int.MaxValue)
                {
                    sum = 0;
                    break;
                }
                sum += isMin[i];
            }
            return sum;
        }

        static void DeleteMin()
        {

        }
    }
}
