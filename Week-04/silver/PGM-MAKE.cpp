#include <string>
#include <vector>

using namespace std;

vector<int> solution(vector<int> progresses, vector<int> speeds) {
    vector<int> answer;

    int size = progresses.size();
    int i = 0;

    while (i < size)
    {
        int count = 0;
        int num = 0;
        num = (100 - progresses[i]) / speeds[i];
        if (progresses[i] + speeds[i] * num < 100)
        {
            num++;
        }

        for (int j = i; j < size; j++)
        {
            progresses[j] += speeds[j] * num;
            if (i == j && progresses[j] >= 100)
            {
                count++;
                i++;
            }
        }

        if (count != 0)
        {
            answer.push_back(count);
        }
    }

    return answer;
}