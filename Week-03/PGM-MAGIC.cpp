#include <string>
#include <vector>

using namespace std;

int solution(int storey) {
    int answer = 0;
    //5를 기준으로
    while (storey > 0)
    {
        int tmp = storey % 10;
        if (tmp > 5 || (tmp == 5 && (storey / 10) % 10 >= 5))
        {
            answer += 10 - tmp;
            storey += 10;
        }
        else
        {
            answer += tmp;
        }
        storey /= 10;
    }
    return answer;
}