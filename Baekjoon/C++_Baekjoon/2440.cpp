# https://www.acmicpc.net/problem/2440
#include <iostream>

int main()
{
	int nIndex{};

	// 컴파일 에러로 인해 scanf로 제출 함
	scanf_s("%d", &nIndex);
	
	while (nIndex > 0)
	{
		int nStar{};
		while (nStar < nIndex)
		{
			printf("*");
			nStar++;
		}
	
		if(nIndex > 1)
			printf("\n");
		nIndex--;
	}
}
