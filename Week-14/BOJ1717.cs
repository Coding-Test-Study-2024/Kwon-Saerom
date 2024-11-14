using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingStudy_CS.Week_14
{
    internal class BOJ1717
    {
        static List<int> arr = new List<int>();

        public static void Main1717(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            // 초기화
            for (int i = 0; i <= n; i++)
                arr.Add(i);
            while(m-->0)
            {
                string[] input2 = Console.ReadLine().Split(' ');
                int num = int.Parse(input2[0]);
                int a = int.Parse(input2[1]);
                int b = int.Parse(input2[2]);

                if(num == 0)
                    Union(a, b);
                else
                {
                    int an = Find(a);
                    int bn = Find(b);
                    if(an == bn)
                        Console.WriteLine("YES");
                    else
                        Console.WriteLine("NO");

                }
            }
        }

        static void Union(int a,int b)
        {
            int an = Find(a);
            int bn = Find(b);
            if (an != bn)
                arr[bn] = an;
        }

        static int Find(int num)
        {
            if (num == arr[num])
                return num;
            return arr[num] = Find(arr[num]); ;
        }
    }
}
