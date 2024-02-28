//
//#include <vector>
//#include <iostream>
//using namespace std;
//
//
//vector<vector<int>> arr;
//vector<bool> visited;
//int result;
//
//void dfs(int n)
//{
//	visited[n] = true;
//	result++;
//	for (int i = 0; i < arr[n].size(); i++)
//	{
//		if (!visited[arr[n][i]])
//			dfs(arr[n][i]);
//	}
//}
//
//int main123()
//{
//	ios::sync_with_stdio(false);
//	cout.tie(NULL);
//	cin.tie(NULL);
//
//
//	//입력
//	int N, M;
//	cin >> N >> M;
//	arr.resize(N + 1);
//	visited = vector<bool>(N + 1, false);
//	while (M--)
//	{
//		int num1, num2;
//		cin >> num1 >> num2;
//		arr[num1].push_back(num2);
//		arr[num2].push_back(num1);
//	}
//
//	result = 0;
//	dfs(1);
//
//	//출력
//	cout << result-1;
//
//	return 0;
//}