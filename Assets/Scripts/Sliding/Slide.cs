using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slide : MonoBehaviour
{
    [SerializeField] Transform emptySpace = null;
    [SerializeField] public Tile[] tiles;
    [SerializeField] int emptySpaceIndex = 8;
    [SerializeField] int IndexTile = 7;
    [SerializeField] double vectordistance = 1.5;

    public GameObject puzzle;
    public Text time, coin;
    [SerializeField] bool selesai = false;

    public TimeManager timeManager;
    public CoinManager coinManager;
    public GameManager gameManager;
    public SoundManager soundManager;
    public SingleLevelSliding singleLevelSliding;

    // Start is called before the first frame update
    void Start()
    {
        Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        Sliding();

        if (!selesai)
        {
            CekPuzzle();
        }
    }

    void Sliding()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                if (Vector2.Distance(emptySpace.position, hit.transform.position) < vectordistance)
                {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    Tile thisTile = hit.transform.GetComponent<Tile>();
                    emptySpace.position = thisTile.targetPosition;
                    thisTile.targetPosition = lastEmptySpacePosition;
                    int tileIndex = findIndex(thisTile);
                    tiles[emptySpaceIndex] = tiles[tileIndex];
                    tiles[tileIndex] = null;
                    emptySpaceIndex = tileIndex;
                }
                soundManager.PlayJigsaw();
            }
        }
    }


    public void Shuffle()
    {
        int invertion;
        do
        {
            for (int i = 0; i <= IndexTile; i++)
            {
                var lastPos = tiles[i].targetPosition;
                int randomIndex = Random.Range(0, IndexTile);
                tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                tiles[randomIndex].targetPosition = lastPos;
                var tile = tiles[i];
                tiles[i] = tiles[randomIndex];
                tiles[randomIndex] = tile;
            }
            invertion = GetInversions();
            Debug.Log(message: "Puzzle Shuffle");
        } while (invertion % 2 != 0);
    }

    public int findIndex(Tile ts)
    {
        for (int i = 0; i <= tiles.Length; i++)
        {
            if (tiles[i] != null)
            {
                if (tiles[i] == ts)
                {
                    return i;
                }
            }
        }
        return -1;
    }

    int GetInversions()
    {
        int inversionsSum = 0;
        for (int i = 0; i < tiles.Length; i++)
        {
            int thisTileInvertion = 0;
            for (int j = i; j < tiles.Length; j++)
            {
                if (tiles[j] != null)
                {
                    if (tiles[i].number > tiles[j].number)
                    {
                        thisTileInvertion++;
                    }
                }
            }
            inversionsSum += thisTileInvertion;
        }
        return inversionsSum;
    }

    public void CekPuzzle()
    {
        int correctTiles = 0;
        foreach (var a in tiles)
        {
            if (a != null)
            {
                if (a.inRightPlace)
                {
                    correctTiles++;
                }
            }
        }

        if (correctTiles == tiles.Length - 1)
        {
            selesai = true;
            time.text = timeManager.timeText.text;
            Debug.Log("You Win");
        }

        if (selesai)
        {
            timeManager.timeActive = false;
            gameManager.WinCondition();
            gameManager.TimeStarSliding();
            singleLevelSliding.UpdateStar();
            coinManager.UpdateCoin();
            soundManager.PlayGameOver();
            coin.text = coinManager.coinText.text;
        }
    }
}
