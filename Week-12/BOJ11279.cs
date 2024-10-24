using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CordingStudy_CS.Week_12
{
    internal class BOJ11279
    {
        public static void Main11279(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            
            //입력을 받는다.
            int N = int.Parse(sr.ReadLine());
            PriorityQueue<long, long> pq = new PriorityQueue<long, long>();
            
            while (N-->0)
            {
                long x = long.Parse(sr.ReadLine());
                if(x == 0)
                {
                    if(pq.Count == 0)
                        sw.WriteLine(0);
                    else
                    {
                        sw.WriteLine(pq.Peek());
                        pq.Dequeue();
                    }
                }    
                else if(x > 0)
                    pq.Enqueue(x,-x);
            }
        }
    }
}
