#include <iostream>
#include<random>
#include<string>
#include<sstream>

// 좌표를 저장하는 구조체 : 미로와 같은 2차원 공간에서 캐릭터 조작할 때 사용하면 편리
struct Coord
{
	int y;
	int x;

	Coord(const int y = 0, const int x = 0) : y(y), x(x) {}
};

constexpr const int H = 3;    // 미로의 높이
constexpr const int W = 4;    // 미로의 너비
constexpr const END_TURN = 4; // 게임 종료 턴 

class MazeState
{
private:
	int points[H][W] = {};    // 바닥의 점수는 1~9 중 하나
	int turn = 0;             // 현재 턴
public:
	Coord character = Coord();
	int gameScore = 0; 

	MazeState(){}

	// h * w 크기의 미로 생성
	MazeState(const int seed)
	{
		// 게임판 구성용 난수 생성기 초기화
		auto mt_for_construct = std::mt19937(seed);
		this->character.y = mt_for_construct() % H;
		this->character.x = mt_for_construct() % W;

		for (int y = 0; y < H; y++)
		{
			for (int x = 0; x < W; x++)
			{
				if (y == character.y && x == character.x)
				{
					continue;
				}
				this->points[y][x] = mt_for_construct() % 10;
			}
		}
	}

	// 게임 종료 판정
	bool isDone() const
	{
		return this->turn == END_TURN;
	}
};

int main()
{

	return 0;
}