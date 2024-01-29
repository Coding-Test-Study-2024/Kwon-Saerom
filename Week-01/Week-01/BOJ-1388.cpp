#include <vector>
#include <iostream>
using namespace std;

string input;


int main()
{
	ios::sync_with_stdio(false);
	cin.tie(NULL);
	cout.tie(NULL);

	//입력
	int N, M;
	cin >> N >> M;
	vector<vector<char>> inputArr;
	vector<vector<bool>> isVisited;
	for (int i = 0; i < N; i++)
	{
		vector<char> tmp(M);
		for (int j = 0; j < M; j++)
		{
			cin >> tmp[j];
		}
		inputArr.push_back(tmp);
		isVisited.push_back(vector<bool> (M, false));
	}

	int answer = 0;
	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < M; j++)
		{
			if (!isVisited[i][j])
			{
				answer++;
				int tmpI = i;
				while (tmpI < N && inputArr[tmpI][j] == '|')
				{
					isVisited[tmpI][j] = true;
					tmpI++;
				}

				while (j < M && inputArr[i][j] == '-')
				{
					isVisited[i][j] = true;
					j++;
				}
				j--;
			}
		}
	}

	cout << answer << endl;
	
}