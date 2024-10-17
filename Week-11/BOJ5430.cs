using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CordingStudy_CS.Week11_CS
{
    internal class BOJ5430
    {
        public static void Main5430(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int T = int.Parse(Console.ReadLine());
            while(T-- > 0)
            {
                // 입력
                string func = Console.ReadLine();
                int N = int.Parse(Console.ReadLine());
                string[] inputArr = Console.ReadLine().Trim('[', ']').Split(',');

                // 시작
                int startIndex = 0;
                int endIndex = inputArr.Length;
                bool isReverse = false;
                bool isError = false;

                // 함수 적용
                for(int i=0;i<func.Length;i++)
                {
                    if (func[i] == 'R')
                        isReverse = !isReverse;
                    else
                    {
                        //TODO : isReverse에 따라 인덱스 조정.
                        if(isReverse == false)
                            startIndex++;
                        else
                            endIndex--;

                        N--;

                        if(N < 0)
                        {
                            isError = true;
                            break;
                        }
                    }
                }

                // 출력
                sb.Clear();

                if(isError)
                    Console.WriteLine("error");
                else
                {
                    sb.Append('[');
                    if (isReverse == false)
                    {
                        for(int i=startIndex;i<endIndex;i++)
                        {
                            sb.Append(inputArr[i]);
                            if (i != endIndex-1)
                                sb.Append(',');
                        }
                    }
                    else
                    {
                        for (int i = endIndex-1; i >= startIndex; i--)
                        {
                            sb.Append(inputArr[i]);
                            if (i != startIndex)
                                sb.Append(',');
                        }
                    }
                    sb.Append(']');
                    Console.WriteLine(sb.ToString());
                }
            }
        }
    }
}
