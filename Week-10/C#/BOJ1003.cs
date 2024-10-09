
namespace CordingStudy_CS.Week10_CS
{
    internal class BOJ1003
    {
        public static void Main1003(string[] args)
        {
            List<Tuple<int, int>> dp = new List<Tuple<int, int>>();
            dp.Add(new Tuple<int, int>(1, 0)); //0의 개수, 1의개수
            dp.Add(new Tuple<int, int>(0, 1)); //0의 개수, 1의개수

            for(int i=2;i<=40;i++)
            {
                Tuple<int,int> t1 = dp[i - 1];
                Tuple<int,int> t2 = dp[i - 2];
                dp.Add(new Tuple<int, int>(t1.Item1 + t2.Item2, t1.Item2 + t2.Item2));
            }

            int T = int.Parse(Console.ReadLine());
            while(T-- != 0)
            {
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine($"{dp[num].Item1} {dp[num].Item2}");
            }
        }
    }
}
