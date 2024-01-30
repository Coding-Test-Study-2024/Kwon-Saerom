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
	vector<vector<bool>> isVisited; //얘는 검사 했는지 안했는지 보는 2차원 배열
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

	int answer = 0; //정답을 카운트 할 변수 
	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < M; j++)
		{
			if (!isVisited[i][j]) //만약 방문하지 않았으면 카운트 대상임!
			{
				answer++; //타일 수 카운트
				int tmpI = i; // '|'일 경우 세로 방향으로 카운트할려고
				while (tmpI < N && inputArr[tmpI][j] == '|') //인덱스를 안 넘어가고, '|'가 반복될때까지
				{
					isVisited[tmpI][j] = true; //방문 기록
					tmpI++; //세로 방향으로 계속 검사
				}

				while (j < M && inputArr[i][j] == '-') //인덱스를 안 넘어가고, - 가 반복될때까지
				{
					isVisited[i][j] = true;
					j++;
				}
				j--; //한번 더 j++되어있으니 j--해준다.
			}
		}
	}

	//정답 출력
	cout << answer << endl;
	
}
