#include <iostream>
#include <vector>
#include <queue>

using namespace std;
int main()
{
	priority_queue<int, vector<int>, greater<int>> pq;

	int N;
	cin >> N;
	while (N--)
	{
		int num;
		cin >> num;
		pq.push(num);
	}

	int answer = 0;
	while (pq.size() != 1)
	{
		int first = pq.top();
		pq.pop();
		int second = pq.top();
		pq.pop();
		answer += first + second;
		pq.push(first + second);
	}

	cout << answer;
	return 0;
}