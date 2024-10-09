#include <iostream>
#include <vector>
#include <queue>
using namespace std;

//오른쪽, 아래, 왼쪽,위
int arrX[] = { 1,0,-1,0 };
int arrY[] = { 0,1,0,-1 };

void bfs(vector<vector<int>> &arr,int startX,int startY)
{
	queue<pair<int, int>> q;

	// 방문은 0으로 표시.
	q.push(make_pair(startY, startX));
	arr[startY][startX] = 0;
	
	while (q.empty() == false)
	{
		pair<int, int> tmp = q.front();
		for (int i = 0; i < 4; i++)
		{
			int Y = tmp.first + arrY[i];
			int X = tmp.second + arrX[i];

			if (Y >= arr.size() || X >= arr[0].size())
				continue;
			if (arr[Y][X] == 1)
			{
				q.push(make_pair(Y, X));
				arr[Y][X] = 0;
			}
		}
		q.pop();
	}
}

int main1012()
{
	ios::sync_with_stdio(false);
	cin.tie(NULL);
	cout.tie(NULL);

	int T;
	cin >> T;

	while (T--)
	{
		//1. 초기화
		int m, n, k;
		cin >> m >> n >> k;
		vector<vector<int>> arr(n, vector<int>(m, 0));

		//2. 데이터 넣기
		while (k--)
		{
			int x, y;
			cin >> x >> y;
			arr[y][x] = 1;
		}

		//3. 계산
		int count = 0;
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < m; j++)
			{
				if (arr[i][j] == 1)
				{
					count++;
					bfs(arr, j, i);
				}
			}
		}

		cout << count << endl;
	}

	return 0;
}