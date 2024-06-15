#include <iostream>
#include<random>
#include<string>
#include<sstream>

// ��ǥ�� �����ϴ� ����ü : �̷ο� ���� 2���� �������� ĳ���� ������ �� ����ϸ� ��
struct Coord
{
	int y;
	int x;

	Coord(const int y = 0, const int x = 0) : y(y), x(x) {}
};

constexpr const int H = 3;    // �̷��� ����
constexpr const int W = 4;    // �̷��� �ʺ�
constexpr const END_TURN = 4; // ���� ���� �� 

class MazeState
{
private:
	int points[H][W] = {};    // �ٴ��� ������ 1~9 �� �ϳ�
	int turn = 0;             // ���� ��
public:
	Coord character = Coord();
	int gameScore = 0; 

	MazeState(){}

	// h * w ũ���� �̷� ����
	MazeState(const int seed)
	{
		// ������ ������ ���� ������ �ʱ�ȭ
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

	// ���� ���� ����
	bool isDone() const
	{
		return this->turn == END_TURN;
	}
};

int main()
{

	return 0;
}