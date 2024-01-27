#include <vector>
#include <algorithm>
#include <iostream>

using namespace std;
vector<int> chicken;
int N, k;


int main()
{
	//입력받기
	cin >> N;
	for (int i = 0; i < N; i++)
	{
		int num;
		cin >> num;
		chicken.push_back(num);
	}
	cin >> k;

	int divide = 2;
	int num = N / divide;
	while (num != k / 2)
	{
		for (int i = 0; i < num; i++)
		{
			sort(chicken.begin()+i*divide, chicken.begin()+(i+1)*divide);
		}
		divide <<= 1;
		num = N / divide;
	}


	//정답 출력
	for (int i = 0; i < N; i++)
	{
		cout<<chicken[i]<<" ";
	}
	return 0;
}