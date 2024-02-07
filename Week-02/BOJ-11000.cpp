#include <iostream>
#include <vector>
#include <algorithm>
#include <queue>
using namespace std;

typedef pair<int, int> edge;

int main()
{
	ios::sync_with_stdio(false);
	cin.tie(NULL);
	cout.tie(NULL);

	//입력
	int N;
	cin >> N;
	vector<edge> arr;
	for (int i = 0; i < N; i++)
	{
		int num1, num2;
		cin >> num1 >> num2;
		arr.push_back(make_pair(num1, num2)); //끝시간 기준으로 정렬
	}
	sort(arr.begin(), arr.end());


	//우선순위큐 사용
	priority_queue<int, vector<int>, greater<int>> pq;
	int count = 1;
	pq.push(arr[0].second);

	for (int i = 1; i < N; i++)
	{

		if (pq.top() <= arr[i].first)
		{
			pq.pop();
		}
		else
		{
			count++;
		}
		pq.push(arr[i].second);

	}

	cout << count << endl;
	return 0;

}