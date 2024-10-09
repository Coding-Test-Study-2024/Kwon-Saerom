#include <iostream>
#include <vector>
#include <queue>
using namespace std;

int main1927()
{
	ios::sync_with_stdio(false);
	cin.tie(NULL);
	cout.tie(NULL);

	int N;
	cin >> N;
	priority_queue<unsigned int, vector<unsigned int>, greater<unsigned int>> q;
	while (N--)
	{
		unsigned int x;
		cin >> x;
		if (x == 0)
		{
			if (q.empty())
				cout << 0 << "\n";
			else
			{
				cout << q.top() << "\n";
				q.pop();
			}
		}
		else
			q.push(x);
	}
	return 0;
}