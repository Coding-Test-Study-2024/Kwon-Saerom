#include <vector>
#include <algorithm>
#include <iostream>
#include <cmath>
using namespace std;

string input;

void Divide(int start, int end, char c)
{
	for (int i = start; i < end; i++)
		input[i] = c;
	if (end - start <= 1)
		return;
	if (c == ' ')
		return;
	int divideSize = (end - start) / 3;
	Divide(start, start + divideSize, '-');
	Divide(start + divideSize, start + 2 * divideSize, ' ');
	Divide(start + 2 * divideSize, end, '-');
}

int main()
{
	while (true)
	{
		int N;
		cin >> N;
		input = "";
		int count = pow(3, N);
		for(int i=0;i<count;i++)
			input += '-';
		Divide(0, count, '-');
		cout << input << endl;
	}

}