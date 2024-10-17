using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CordingStudy_CS.Week11_CS
{
    internal class BOJ7662
    {
        public static void Main7662(string[] args)
        {
            // 입력
            int T = int.Parse(Console.ReadLine());
            PriorityQueue<long, long> minQ = new PriorityQueue<long, long>();
            PriorityQueue<long, long> maxQ = new PriorityQueue<long, long>();

            PriorityQueue<long, long> removeMin = new PriorityQueue<long, long>();
            PriorityQueue<long, long> removeMax = new PriorityQueue<long, long>(); 
            
            while(T-- >0)
            {
                int k = int.Parse(Console.ReadLine());
                
                int qSize = 0;
                minQ.Clear();
                maxQ.Clear();
                removeMin.Clear();
                removeMax.Clear();
                while (k-- >0)
                {
                    string[] input = Console.ReadLine().Split(' ');
                    if (input[0] == "I")
                    {
                        long num = long.Parse(input[1]);
                        minQ.Enqueue(num,num);
                        maxQ.Enqueue(num,-num);
                        qSize++;
                    }
                    else
                    {
                        if (qSize == 0)
                            continue;

                        long remove = 0;
                        if (input[1] == "1")
                        {
                            // 지웠던 요소 안지웠으면 지우기
                            while(removeMax.Count > 0)
                            {
                                if (maxQ.Peek() != removeMax.Peek())
                                    break;
                                maxQ.Dequeue();
                                removeMax.Dequeue();
                            }
                            remove = maxQ.Dequeue();
                            removeMin.Enqueue(remove,remove);
                        }
                        else
                        {
                            // 지웠던 요소 안지웠으면 지우기
                            while (removeMin.Count > 0)
                            {
                                if (minQ.Peek() != removeMin.Peek())
                                    break;
                                minQ.Dequeue();
                                removeMin.Dequeue();
                            }
                            remove = minQ.Dequeue();
                            removeMax.Enqueue(remove,-remove);
                        }

                        qSize--;
                    }
                }

                if(qSize == 0)
                    Console.WriteLine("EMPTY");
                else
                {
                    while (removeMin.Count > 0)
                    {
                        if (minQ.Peek() != removeMin.Peek())
                            break;
                        minQ.Dequeue();
                        removeMin.Dequeue();
                    }

                    while (removeMax.Count > 0)
                    {
                        if (maxQ.Peek() != removeMax.Peek())
                            break;
                        maxQ.Dequeue();
                        removeMax.Dequeue();
                    }

                    Console.WriteLine($"{maxQ.Peek()} {minQ.Peek()}");
                }
            }

        }
    }
}
