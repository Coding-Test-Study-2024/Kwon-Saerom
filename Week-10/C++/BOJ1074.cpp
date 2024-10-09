#include <iostream>
#include <vector>
#include <cmath>
using namespace std;

int search(int N,int r,int c)
{
	int k; // 어떤면에 있는지(0~3)
	int minusR = 0, minusC = 0;

	int powResult = pow(2, N - 1);
	//0,1
	if (powResult > r)
	{
		if (powResult > c)
			k = 0;
		else
		{
			k = 1;
			minusC = powResult;
		}
	}
	else //2,3
	{
		if (powResult > c)
			k = 2;
		else
		{
			k = 3;
			minusC = powResult;
		}
		minusR = powResult;
	}

	int tmp = pow(powResult, 2) * k;

	if (N == 1)
		return k;

	return tmp + search(N - 1, r - minusR, c - minusC);
}

int main1074()
{
	ios::sync_with_stdio(false);
	cin.tie(NULL);
	cout.tie(NULL);

	int N, r, c;
	cin >> N >> r >> c;

	cout << search(N, r, c) << endl;

	return 0;
}