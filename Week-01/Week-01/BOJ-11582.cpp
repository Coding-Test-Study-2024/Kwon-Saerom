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
	//계속 나누다가 num이 k일 경우까지만 처리하고 그 다음부턴 종료.
	while (num != k / 2)
	{
		for (int i = 0; i < num; i++) // N/divide만큼 반복된다.
		{	
			sort(chicken.begin()+i*divide, chicken.begin()+(i+1)*divide); //나누는 사람 수 만큼 구간별로 정렬한다.
		}
		divide <<= 1; //divide를 2배한다.(비트연산자 사용)

		
		num = N / divide; //num 을 나눠서 갱신.
	}


	//출력
	for (int i = 0; i < N; i++)
	{
		cout<<chicken[i]<<" ";
	}
	return 0;
}
