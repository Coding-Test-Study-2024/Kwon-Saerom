//#include <iostream>
//#include <queue>
//#include <algorithm>
//using namespace std;
//
//vector<vector<int>> arr;
//vector<bool> visited;
//void DFS(int v);
//void BFS(int v);
//
//int main123214() {
//	ios::sync_with_stdio(false);
//	cin.tie(NULL);
//	cout.tie(NULL);
//	int N, M, V;
//	cin >> N >> M >> V;
//
//	arr.resize(N + 1);
//	visited = vector<bool>(N + 1, false);
//	for (int i = 0; i < M; i++) {
//		int s, e;
//		cin >> s >> e;
//		arr[s].push_back(e);
//		arr[e].push_back(s);
//	}
//
//
//	for (int i = 1; i < N + 1; i++) {
//		sort(arr[i].begin(), arr[i].end());
//	}
//
//	DFS(V);
//	cout << "\n";
//	visited.clear();
//	visited = vector<bool>(N + 1, false);
//	BFS(V);
//
//
//
//	return 0;
//}
//
//void DFS(int v) {
//	visited[v] = true;
//	cout << v << " ";
//
//	for (int i = 0; i < arr[v].size(); i++) {
//		int num = arr[v][i];
//		if (visited[num] == false) {
//			DFS(num);
//		}
//	}
//}
//
//void BFS(int v) {
//	queue<int> q;
//	q.push(v);
//	visited[v] = true;
//
//	while (!q.empty()) {
//		int current = q.front();
//		cout << current << " ";
//		q.pop();
//		for (int i = 0; i < arr[current].size(); i++) {
//			int num = arr[current][i];
//			if (visited[num] == false) {
//				visited[num] = true;
//				q.push(num);
//			}
//		}
//	}
//}