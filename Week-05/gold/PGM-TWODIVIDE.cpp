#include <string>
#include <vector>
#include <queue>
using namespace std;

int bfs(vector<vector<int>> wires, int n, int cut)
{
    int count = 0;

    vector<bool> visited(n, false);
    vector<vector<int>> graph(n + 1);

    for (int i = 0; i < wires.size(); i++)
    {
        if (i == cut)
            continue;
        graph[wires[i][0]].push_back(wires[i][1]);
        graph[wires[i][1]].push_back(wires[i][0]);
    }

    queue<int> q;
    visited[1] = true;
    q.push(1);
    count++;

    while (q.size() > 0)
    {
        int num = q.front();
        q.pop();
        for (int i = 0; i < graph[num].size(); i++)
        {
            int tmp = graph[num][i];
            if (!visited[tmp])
            {
                q.push(tmp);
                visited[tmp] = true;
                count++;
            }
        }
    }
    return count;
}

int solution(int n, vector<vector<int>> wires) {
    int answer = 1000;
    //bfs로 다 돌리면서 개수차이 제일 적은거 리턴.
    for (int i = 0; i < n - 1; i++)
    {
        int num = bfs(wires, n, i);
        int cal = (n - num) - num;
        int diff = cal < 0 ? -1 * cal : cal;
        if (answer > diff)
            answer = diff;
    }
    return answer;
}