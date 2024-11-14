using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingStudy_CS.Week_14
{
    internal class BOJ25343
    {
        static List<List<int>> arr = new List<List<int>>();
        static List<List<int>> bList = new List<List<int>>();

        // 오른쪽, 아래
        static int[] moveX = { 1,0};
        static int[] moveY = { 0,1};

        static int N;
        static int Max = 0;

        public static void Main25343(string[] args)
        {
            // 입력을 받는다.
            N = int.Parse(Console.ReadLine());
            for(int i=0;i<N;i++)
            {
                List<int> tmp = new List<int>();
                string[] input = Console.ReadLine().Split(' ');
                for(int j=0;j<N;j++)
                {
                    tmp.Add(int.Parse(input[j]));
                }
                arr.Add(tmp);
            }

            // 최장증가부분수열 알고리즘 이용하여 푼다.
            // DFS로 깊이우선 탐색
            List<int> b = new List<int>();
            b.Add(arr[0][0]);
            DFS(0,0,b);

            Console.WriteLine(Max);
        }

        static void DFS(int x,int y,List<int> b)
        {
            if (x < 0 || y < 0 || x >= N || y >= N)
                return;

            int removeIndex = 0;
            int beforeValue = 0;
            if (b[b.Count-1] < arr[y][x])
            {
                b.Add(arr[y][x]);
                removeIndex = b.Count - 1;
            }
            else
            {
                int a = BinarySearch(b,arr[y][x]);
                beforeValue = b[a];
                removeIndex = a;

                b[a] = arr[y][x];
            }

            if (x == N - 1 && y == N - 1)
            {
                if (b.Count > Max)
                    Max = b.Count;
                ReturnB(b, removeIndex, beforeValue);
                return;
            }

            for (int i=0;i<moveX.Length;i++)
            {
                DFS(x + moveX[i], y + moveY[i], b);
            }
            ReturnB(b, removeIndex, beforeValue);
        }

        static int BinarySearch(List<int> b,int target)
        {
            int r = b.Count;
            int l = 0;

            while(l<r)
            {
                int m = (r + l) / 2;
                if (b[m] < target)
                    l = m + 1;
                else if (b[m] > target)
                    r = m;
                else
                    return m;
            }

            return r;
        }

        static void ReturnB(List<int> b,int index, int value)
        {
            if (index == b.Count - 1 && value == 0)
                b.RemoveAt(index);
            else
                b[index] = value;
        }
    }
}
