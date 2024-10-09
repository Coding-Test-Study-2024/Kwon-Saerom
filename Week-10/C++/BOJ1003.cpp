#include <iostream>
#include <vector>
using namespace std;

typedef pair<int, int> p;
int main1003()
{
	ios::sync_with_stdio(false);
	cin.tie(NULL);
	cout.tie(NULL);

	vector<p> dp;
	dp.push_back(make_pair(1, 0));
	dp.push_back(make_pair(0, 1));

	for (int i = 2; i <= 40; i++)
	{
		p p1 = dp[i - 1];
		p p2 = dp[i - 2];
		dp.push_back(make_pair(p1.first + p2.first, p1.second + p2.second));
	}

	int T;
	cin >> T;
	while (T--)
	{
		int num;
		cin >> num;
		cout << dp[num].first << " " << dp[num].second << endl;
	}
	return 0;
}