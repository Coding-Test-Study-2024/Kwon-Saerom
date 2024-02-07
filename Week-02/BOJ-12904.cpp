#include <iostream>
#include <vector>
#include <algorithm>
#include <queue>
using namespace std;


int main()
{
	ios::sync_with_stdio(false);
	cin.tie(NULL);
	cout.tie(NULL);

	//입력
	string input;
	cin >> input;
	string input2;
	cin >> input2;

	int result = 1;

	int start = 0;
	int end = input2.length() - 1;
	bool onLeft = false;

	int size = input.length();
	while ((end - start + 1) != size)
	{
		if (onLeft)
		{
			if (input2[start] == 'B')
				onLeft = false;
			start++;
		}
		else
		{
			if (input2[end] == 'B')
				onLeft = true;
			end--;
		}
	}

	if (!onLeft)
	{
		for (int i = start, j = 0; i <= end; i++, j++)
		{
			if (input2[i] != input[j])
			{
				result = 0;
				break;
			}
		}
	}
	else
	{
		for (int i = end, j = 0; i >= start; i--, j++)
		{
			if (input2[i] != input[j])
			{
				result = 0;
				break;
			}
		}
	}

	//출력
	cout << result;

	return 0;
}