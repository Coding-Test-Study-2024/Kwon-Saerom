#include <iostream>
#include <vector>
#include <queue>
using namespace std;

struct Node
{
public:
	int value; //값
	int traDis; //온 거리(걸린 시간)
	int remainDis; //남은 거리
	int total;

	Node(int v, int t,int N)
	{
		value = v;
		traDis = t;
		remainDis = N - v < 0 ? (N - v) * -1 : N - v;
		total = traDis + remainDis;
	}
	Node()
	{

	}
};

struct compare
{
	bool operator()(const Node& n1, const Node& n2)
	{
		return n1.total > n2.total;
	}
};

int main1697()
{
	ios::sync_with_stdio(false);
	cin.tie(NULL);
	cout.tie(NULL);

	int N, K;
	cin >> N >> K;

	priority_queue<Node, vector<Node>, compare> q;
	int answer = K+1;

	int tmp = N;
	int count = 0;
	while (true)
	{
		count++;
		tmp = tmp << 1;
		if (tmp == 0)
		{
			tmp++;
		}
		if (tmp > K)
		{
			q.push(Node(tmp >> 1, count - 1, K));
			break;
		}
	}

	Node node;
	while (q.empty() == false)
	{
		node = q.top();
		q.pop();

		if (node.traDis >= answer)
			continue;

		cout << node.traDis << " -> value : " << node.value << " -> remainDis : " << node.remainDis << endl;
		if (node.value == K) //도착
		{
			if (answer > node.traDis)
				answer = node.traDis;
			continue;
		}

		q.push(Node(node.value - 1, node.traDis + 1, K));
		q.push(Node(node.value + 1, node.traDis + 1, K));
		q.push(Node(node.value << 1, node.traDis + 1, K));
	}
	cout << answer << endl;

	return 0;
}