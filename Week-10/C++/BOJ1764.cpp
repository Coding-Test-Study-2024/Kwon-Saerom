#include <iostream>
#include <vector>
#include <set>
#include <algorithm>
using namespace std;

int main1764()
{
	ios::sync_with_stdio(false);
	cin.tie(NULL);
	cout.tie(NULL);

	//입력
	int N, M;
	cin >> N >> M;

	//계산
	set<string> s;
	vector<string> v;
	while (N--)
	{
		string tmp;
		cin >> tmp;
		s.insert(tmp);
	}

	while (M--)
	{
		string tmp;
		cin >> tmp;
		if (s.find(tmp) != s.end())
			v.push_back(tmp);
	}

	cout << v.size() << endl;
	sort(v.begin(), v.end());
	for (string s : v)
		cout << s << endl;

	return 0;
}