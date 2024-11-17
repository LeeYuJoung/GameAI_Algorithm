using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Chapter03.03 빔탐색
// 수정
public class Chapter03_03_BeamSearch : MonoBehaviour
{
    // 좌표 저장 구조체
    public struct Coord
    {
        public int x;
        public int y;
    }
    public Coord character = new Coord();

    public GameObject[] numPrefabs;
    public GameObject player;

    // 오른쪽, 왼쪽, 아래쪽, 위쪽으로 이동하는 이동방향 x와 y축 값
    public int[] dx = new int[4] { 1, -1, 0, 0 };
    public int[] dy = new int[4] { 0, 0, 1, -1 };

    public const int H = 3;        // 미로의 높이 (y축)
    public const int W = 4;        // 미로의 너비 (x축)
    public const int END_TURN = 4; // 게임 종료의 턴

    public int[,] points = new[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };  // 바닥의 점수는 1~9 중 하나
    public int turn = 0;          // 현재 턴
    public int gameScore = 0;      // 게임에서 획득한 점수

    void Start()
    {
        CreateMaze(10);
    }

    // h * w 크기의 미로를 생성
    public void CreateMaze(int seed)
    {
        // 플레이어 랜덤 난수 생성 (3*4 게임판 위 랜덤한 위치에 플레이어 초기 설정)
        character.x = Random.Range(0, 4);
        character.y = Random.Range(0, 3);
        player.transform.position = new Vector3(character.x, character.y, 0.0f);

        // 게임판 구성용 난수 랜덤 생성
        for (int y = 0; y < H; y++)
        {
            for (int x = 0; x < W; x++)
            {
                if (y == character.y && x == character.x)
                {
                    continue;
                }

                points[y, x] = Random.Range(1, seed);
                Instantiate(numPrefabs[points[y, x] - 1], new Vector3(x, y, 0.0f), Quaternion.identity);
            }
        }
    }

    // 게임 상황을 표시하면서 AI에 플레이
    public void Play()
    {
        if (!IsDone())
        {
            Advance(BeamSearch_AI());
        }
    }

    // 지정한 action으로 게임을 1턴 진행
    public void Advance(int action)
    {
        character.x += dx[action];
        character.y += dy[action];
        int point = points[character.y, character.x];

        if (point > 0)
        {
            gameScore += point;
            points[character.y, character.x] = 0;
            point = 0;
        }

        turn++;
        player.transform.position = new Vector3(character.x, character.y, 0.0f);

        // 현재 Turn & Point Text에 표시
        UIManager.Instance().TextUpdate(turn, gameScore);
    }

    #region Random_AI
    // 무작위로 행동을 결정하는 AI
    public int RandomActionAI()
    {
        int actions = 0;

        while (true)
        {
            int action = Random.Range(0, 4);
            int ty = character.y + dy[action];
            int tx = character.x + dx[action];

            if (ty >= 0 && ty < H && tx >= 0 && tx < W)
            {
                actions = action;
                return actions;
            }
        }
    }
    #endregion

    #region BeamSearch
    public int BeamSearch_AI()
    {
        int beamWidth = 0;
        int beamDepth = 0;

        return 0;
    }
    #endregion

    // 게임 종료
    public bool IsDone()
    {
        return turn == END_TURN;
    }
}
