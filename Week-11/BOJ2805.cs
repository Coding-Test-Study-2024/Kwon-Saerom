using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CordingStudy_CS.Week11_CS
{
    internal class BOJ2805
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            long N = int.Parse(input[0]); //1~100만
            long M = int.Parse(input[1]); //1~20억
            long H = 0; //답은 0~10억

            List<long> list = new List<long>();
            string[] nums = Console.ReadLine().Split(' ');
            for(int i=0;i<N;i++)
            {
                list.Add(long.Parse(nums[i]));
            }

            //정렬한 후, 중간지점을 파악한다.
            list.Sort();

            int start = 0;
            int end = list.Count;
            int mid = (end - start) / 2;
            H = list[mid];

            while(true)
            {
                //나머지 부분 구함
                long r = 0;
                for (int i = mid; i < list.Count; i++)
                {
                    long m = list[i] - H;
                    if(m > 0)
                        r += m;
                }

                if (r < M) // 나무 더 필요함. H 낮아짐
                {
                    if (start + 1 >= end)
                    {
                        H -= (M - r) % (N - mid) == 0 ? (M - r) / (N - mid) : (M - r) / (N - mid) + 1;
                        break;
                    }
                    else
                    {
                        end = mid;
                    }
                }
                else if (r > M) // 높이 높아저야함.
                {
                    if (start + 1 >= end)
                    {
                        mid++;
                        H += (r - M) % (N - mid) == 0 ? (r - M) / (N - mid) : (r - M) / (N - mid);
                        break;
                    }
                    else
                    {
                        start = mid;
                    }
                }
                else // 같아짐
                    break;

                mid = (end + start) / 2;
                H = list[mid];
            }

            Console.WriteLine(H);
        }
    }
}
