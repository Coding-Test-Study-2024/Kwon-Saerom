using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CordingStudy_CS.Week11_CS
{
    internal class BOJ5525
    {
        static int N;
        static int M;
        static string S;
        public static void Main5525(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            M = int.Parse(Console.ReadLine());
            S = Console.ReadLine();

            int count = 0;
            for(int i=0;i<M;i++)
            {
                if (S[i] == 'I')
                    if (IsIO(i) == true)
                        count++;
            }
            Console.WriteLine(count);
        }

        public static bool IsIO(int startIndex)
        {
            int endIndex = startIndex + 2 * N + 1;
            
            if (endIndex > M)
                return false;

            int tmp = 0;
            char bc = 'I';
            for (int i = startIndex + 1; i < endIndex; i++)
            {
                if (bc == 'O' && S[i] == 'I')
                {
                    if (tmp == N)
                        return true;
                }
                else if (bc == 'I' && S[i] == 'O')
                {
                    tmp++;
                }
                else
                    return false;
                bc = S[i];
            }
            return false;
        }
    }
}
