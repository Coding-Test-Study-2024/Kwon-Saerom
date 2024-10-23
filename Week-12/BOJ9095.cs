using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CordingStudy_CS.Week_12
{
    internal class BOJ9095
    {
        // DP 
        public static void Main9095(string[] args)
        {
            // dp를 만든다.(인덱스가 n)
            List<int> dp = new List<int>();
            dp.Add(0);
            dp.Add(1);
            dp.Add(2);//2는 1+1, 2 두가지.
            dp.Add(4);//3은 1+1+1,1+2,2+1,3
            for(int i=4;i<11;i++)
            {
                int answer = dp[i - 1];
                answer += dp[i - 2];
                answer += dp[i - 3];
                dp.Add(answer);
            }

            //문제를 푼다.
            int T = int.Parse(Console.ReadLine());
            while(T-->0)
            {
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(dp[n]);
            }
        }
    }
}
