

namespace CordingStudy_CS.Week10_CS
{
    internal class BOJ1764
    {
        public static void Main1764(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);

            HashSet<string> hs = new HashSet<string>();
            List<string> v = new List<string>();

            while(N-->0)
            {
                string tmp = Console.ReadLine();
                hs.Add(tmp);
            }

            while(M-->0)
            {
                string tmp = Console.ReadLine();
                if (hs.Add(tmp) == false)
                    v.Add(tmp);
            }

            Console.WriteLine(v.Count);
            
            v.Sort();
            foreach(string s in v)
                Console.WriteLine(s);
        }
    }
}
