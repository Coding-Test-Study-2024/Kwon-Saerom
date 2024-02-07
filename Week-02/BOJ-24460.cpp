#include <iostream>
#include <vector>
#include <algorithm>
#include <tuple>
using namespace std;

int N;
vector<vector<int>> arr;

int Divide(int startH, int endH, int startW, int endW)
{
	if (endH - startH <= 1)
		return arr[startH][startW];

	int halfH = startH + (endH - startH) / 2;
	int halfW = startW + (endW - startW) / 2;
	int num1 = Divide(startH, halfH, startW, halfW);
	int num2 = Divide(startH, halfH, halfW, endW);
	int num3 = Divide(halfH, endH, startW, halfW);
	int num4 = Divide(halfH, endH, halfW, endW);

	vector<int> num = { num1, num2, num3, num4 };
	sort(num.begin(), num.end());
	return num[1];
}


int main()
{
	ios::sync_with_stdio(false);
	cin.tie(NULL);
	cout.tie(NULL);

	//입력 받기
	cin >> N;
	for (int i = 0; i < N; i++)
	{
		vector<int> tmp(N);
		for (int j = 0; j < N; j++)
		{
			cin >> tmp[j];
		}
		arr.push_back(tmp);
	}

	cout << Divide(0, N, 0, N);
	return 0;
}