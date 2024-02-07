
#include <iostream>
#include <vector>
#include <algorithm>
#include <tuple>
using namespace std;

typedef tuple<int, int,int> edge;

int main()
{
	ios::sync_with_stdio(false);
	cin.tie(NULL);
	cout.tie(NULL);

	int answer = 0;
	
	
	vector<edge> xorArr;
	for (int i = 0; i <= 3; i++)
	{
		for (int j = i; j <= 3; j++)
		{
			xorArr.push_back(make_tuple(i ^ j, i, j)); //i^j 기준으로 정렬하기 위해서
		}
	}
	sort(xorArr.begin(), xorArr.end(),greater<edge>());
	

	//입력받기
	int N;
	cin >> N;
	vector<int> numArr(4, 0);
	for(int i=0;i<N;i++)
	{
		int num;
		cin >> num;
		numArr[num]++;
	}


	for (int i = 0; i < xorArr.size(); i++)
	{
		int plus = get<0>(xorArr[i]);
		int tmp1 = get<1>(xorArr[i]);
		int tmp2 = get<2>(xorArr[i]);
		while (numArr[tmp1] > 0 && numArr[tmp2] > 0)
		{
			answer += plus;
			numArr[tmp1]--; numArr[tmp2]--;
		}
	}


	//출력
	cout << answer;
}