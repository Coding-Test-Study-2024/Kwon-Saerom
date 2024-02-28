#include <string>
#include <vector>
#include <algorithm>
#include <queue>
using namespace std;

vector<int> moveX = { 0,0,-1,1 }; //상,하,좌,우
vector<int> moveY = { -1,1,0,0 };
vector<string> graph;
vector<vector<bool>> visited;

int bfs(int i, int j)
{
    int count = 0;

    queue<pair<int, int>> q;

    visited[i][j] = true;
    if (graph[i][j] == 'X')
        return 0;
    q.push(make_pair(i, j));
    count += graph[i][j] - '0';

    while (q.size() > 0)
    {
        pair<int, int> p = q.front();
        q.pop();

        for (int t = 0; t < 4; t++)
        {
            int x = moveX[t] + p.first;
            int y = moveY[t] + p.second;

            if (x < 0 || y < 0 || x >= graph.size() || y >= graph[x].length() || graph[x][y] == 'X')
                continue;

            if (!visited[x][y])
            {
                visited[x][y] = true;
                q.push(make_pair(x, y));
                count += graph[x][y] - '0';
            }
        }
    }
    return count;
}


vector<int> solution(vector<string> maps) {
    vector<int> answer;
    //초기화
    for (int i = 0; i < maps.size(); i++)
    {
        vector<bool> tmp(maps[i].length(), false);
        visited.push_back(tmp);
    }
    graph = maps;

    //풀이
    for (int i = 0; i < graph.size(); i++)
    {
        for (int j = 0; j < graph[i].length(); j++)
        {
            if (!visited[i][j])
            {
                int num = bfs(i, j);
                if (num != 0)
                    answer.push_back(num);
            }
        }
    }
    sort(answer.begin(), answer.end());
    if (answer.size() == 0)
        answer.push_back(-1);
    return answer;
}