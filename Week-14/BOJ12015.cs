using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingStudy_CS.Week_14
{
    internal class BOJ12015
    {
        public static void Main12015(string[] args)
        {
            // 입력을 받는다
            int N = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ');
            
            List<int> arr = new List<int>();
            for (int i = 0; i < N; i++)
                arr.Add(int.Parse(input[i]));

            // DP : 그 인덱스 포함하여 가장 긴 부분수열 길이
            List<int> dp = new List<int>();
            List<int> by = new List<int>();
            dp.Add(1);
            by.Add(arr[0]);

            for(int i=1;i<arr.Count;i++)
            {
                if (by[by.Count - 1] < arr[i])
                {
                    by.Add(arr[i]);
                    dp.Add(by.Count);
                }
                else
                {
                    int bs = BinarySearch(by, arr[i]);
                    dp.Add(bs + 1);
                    by[bs] = arr[i];
                }
            }

            Console.WriteLine(by.Count);
        }

        static int BinarySearch(List<int> by,int findNum)
        {
            int r = by.Count;
            int l = 0;
            while(l < r)
            {
                int m = (r + l) / 2;
                if (findNum > by[m])
                    l = m + 1;
                else if (findNum < by[m])
                    r = m;
                else
                    return m;
            }

            return r;
        }
    }
}
