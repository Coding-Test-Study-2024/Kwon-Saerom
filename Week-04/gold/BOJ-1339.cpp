
#include <iostream>
#include <vector>
#include <string>
#include <algorithm>
using namespace std;

//int main123()
//{
//	ios::sync_with_stdio(NULL);
//	cin.tie();
//	cout.tie();
//
//	int N;
//	cin >> N;
//
//	//�Է�
//	int maxSize = 0;
//	vector<string> arr(N);
//	vector<long long> alpha = vector<long long>('Z' - 'A' + 1, -1); //�󵵼� ����
//	for (int i = 0; i < N; i++)
//	{
//		cin >> arr[i];
//		int tmp = 1;
//
//		alpha[arr[i]] = 0;
//		for (int j = arr[i].length() - 1; j >= 0; j--)
//		{
//			alpha[arr[i][j] - 'A'] += 1 * tmp;
//			tmp *= 10;
//		}
//	}
//
//	//�ִ밪���� ���ʴ�� ���ĺ� �����ϱ�
//	int mappingNum = 9;
//	vector<int> isMapping('Z'-'A'+1, -1);
//	while(true)
//	{
//		int maxIndex = -1;
//		int max = -1;
//		for (int j = 0; j < alpha.size(); j++)
//		{
//			if (max < alpha[j])
//			{
//				maxIndex = j;
//				max = alpha[j];
//				alpha[j] = -1;
//			}
//		}
//		if (max == -1)
//			break;
//		isMapping[maxIndex] = mappingNum--;
//	}
//
//	//�����ϱ�
//	for (int i=0;i<arr.size();i++)
//	{
//		for(int j=0;j<arr[i].length();j++)
//		{
//			arr[i][j] = isMapping[arr[i][j] - 'A']+'0';
//		}
//	}
//
//
//	//���
//	long long answer = 0;
//	for (string num : arr)
//		answer += stoll(num);
//	cout << answer;
//
//
//	return 0;
//}