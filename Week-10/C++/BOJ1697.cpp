#include <iostream>
#include <vector>
#include <queue>
using namespace std;
typedef pair<int,int> edge;

int N, K;
int BFS()
{
	vector<bool> isVisited(100001,false);
	queue<edge> q;

	q.push(make_pair(N,0));
	isVisited[N] = true;

	int answer = 0;
	while (q.empty() == false)
	{
		edge e = q.front();

		if (e.first == K)
		{
			answer = e.second;
			break;
		}

		int plus[] = { 1,-1,e.first };

		for (int i = 0; i < 3; i++)
		{
			int tmp = e.first + plus[i];

			if (tmp < 0 || tmp >= isVisited.size())
				continue;

			if (isVisited[tmp] == false)
			{
				q.push(make_pair(tmp, e.second + 1));
				isVisited[tmp] = true;
			}
		}

		q.pop();
	}

	return answer;
}

int main1697()
{
	ios::sync_with_stdio(false);
	cin.tie(NULL);
	cout.tie(NULL);

	cin >> N >> K;

	cout << BFS() << "\n";
	return 0;
}