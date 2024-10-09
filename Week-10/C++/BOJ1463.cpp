#include <iostream>
#include <algorithm>
#include <vector>
using namespace std;

int main1463()
{
	ios::sync_with_stdio(false);
	cin.tie(NULL);
	cout.tie(NULL);

	int N;
	cin >> N;
	
	vector<int> arr(N+1, 0);
	for (int i = 2; i <= N; i++)
	{
		//초기화
		int num1, num2, num3;
		num1 = num2 = num3 = N;

		//계산
		if (i % 3 == 0)
			num1 = arr[i / 3] + 1;
		if (i % 2 == 0)
			num2 = arr[i / 2] + 1;
		num3 = arr[i - 1] + 1;

		//최솟값을 저장
		arr[i] = num1 < num2 ? num1 : num2;
		arr[i] = arr[i] < num3 ? arr[i] : num3;
	}

	cout << arr[N] << endl;
	return 0;
}