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
	if (end - start <= 1) //만약 end와 start가 1개 차이면 return함.
		return;
	if (c == ' ') // ' ' 면 '-'를 그릴필요가 없으니 return 함.
		return;
	int divideSize = (end - start) / 3; // 3 나눈 크기
	Divide(start, start + divideSize, '-');  // 시작부터 1/3칸은 '-'로
	Divide(start + divideSize, start + 2 * divideSize, ' '); // 1/3칸부터 2/3칸 까지는 ' '로
	Divide(start + 2 * divideSize, end, '-'); // 2/3칸부터 끝까지는 '-'로 대체하기
}

int main()
{
	while (true)
	{
		//입력받기
		int N;
		cin >> N;
		input = "";
		int count = pow(3, N);
		
		//초기 3^N개의 문자열
		for(int i=0;i<count;i++)
			input += '-';
		Divide(0, count, '-'); //나누기 시작
		cout << input << endl; //출력
	}

}
