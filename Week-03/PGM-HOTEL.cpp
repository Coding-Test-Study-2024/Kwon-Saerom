#include <string>
#include <vector>
#include <queue>
#include <algorithm>
using namespace std;

int intBookReturn(string str, bool isEnd)
{
    int result = 0;
    for (char c : str)
    {
        if ('0' <= c && c <= '9')
        {
            result *= 10;
            result += c - '0';
        }
    }
    if (isEnd)
    {
        result += 10;
        if (result % 100 >= 60) //시간
        {
            result += 100;
            result -= 60;
        }
    }
    return result;
}

int solution(vector<vector<string>> book_time) {
    int answer = 0;
    vector<pair<int, int>> time;
    //저장
    for (vector<string> book : book_time)
        time.push_back(make_pair(intBookReturn(book[0], false), intBookReturn(book[1], true)));
    sort(time.begin(), time.end());

    //시작
    priority_queue<int, vector<int>, greater<int>> pq;
    pq.push(time[0].second);
    answer++;
    for (int i = 1; i < time.size(); i++)
    {
        int tmp = pq.top();
        if (time[i].first >= tmp)
        {
            pq.pop();
        }
        else
        {
            answer++;
        }
        pq.push(time[i].second);
    }

    return answer;
}