using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MENU, PLAY, END
}

[System.Serializable]
public struct MinMax
{
    public int min;
    public int max;
}

[System.Serializable]
public struct Walls
{
    public GameObject wallObj;
    public Transform[] spawnPoints;
}

public class Manager : MonoBehaviour
{
    public static Manager managerInstance;

    public GameObject[] cheesePrefabs;
    public GameObject[] trapPrefabs;

    public PolygonCollider2D spawnBounds;

    public GameState gameState;

    public Walls[] walls;
    public MinMax cheeseSpawnAmount;
    public MinMax trapSpawnAmount;

    MouseController player;
    UIManager uiManager;

    List<GameObject> spawnedCheese;
    List<GameObject> spawnedTraps;

    public int numSpawnedCheese;

    private void Awake()
    {
        managerInstance = this;

        spawnedCheese = new List<GameObject>();
        spawnedTraps = new List<GameObject>();
    }

    private void Start()
    {
        player = MouseController.mouseControllerInstance;

        uiManager = UIManager.uiManagerInstance;
    }


    public void SpawnLevel()
    {
        player.CollectedCheese = 0;

        ClearLevel();

        SpawnPlayer();
        SpawnCheese();
        SpawnTraps();
    }

    void ClearLevel()
    {
        if (spawnedCheese.Capacity > 0)
        {
            spawnedCheese.Clear();
        }

        if (spawnedTraps.Capacity > 0)
        {
            spawnedTraps.Clear();
        }

        GameObject[] existingCheese = GameObject.FindGameObjectsWithTag("Cheese");
        for (int i = 0; i < existingCheese.Length; i++)
        {
            Destroy(existingCheese[i]);
        }

        GameObject[] existingTraps = GameObject.FindGameObjectsWithTag("Trap");
        for (int i = 0; i < existingTraps.Length; i++)
        {
            Destroy(existingTraps[i]);
        }
    }

    void SpawnPlayer()
    {
        int randomWall = Random.Range(0, walls.Length);
        walls[randomWall].wallObj.SetActive(true);
        int randomPosition = Random.Range(0, walls[randomWall].spawnPoints.Length);
        walls[randomWall].spawnPoints[randomPosition].gameObject.SetActive(true);
        player.transform.position = walls[randomWall].spawnPoints[randomPosition].position;
        player.transform.rotation = walls[randomWall].spawnPoints[randomPosition].rotation;
        for (int i = 0; i < walls[randomWall].spawnPoints.Length; i++)
        {
            if (i != randomPosition)
            {
                walls[randomWall].spawnPoints[i].gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < walls.Length; i++)
        {
            if (i != randomWall)
            {
                walls[i].wallObj.SetActive(false);
            }
        }
    }

    void SpawnCheese()
    {
        int randomAmt = Random.Range(cheeseSpawnAmount.min, cheeseSpawnAmount.max);
        float radius = 10f;
        int i = 0;
        while (i < randomAmt)
        {
            Vector2 spawnPos = RandomSpawnPosition(spawnBounds);

            if (!Physics.CheckSphere(spawnPos, radius))
            {
                int randInt = Random.Range(0, 2);
                spawnedCheese.Add(Instantiate(cheesePrefabs[randInt], RandomSpawnPosition(spawnBounds), Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)), transform));
                i++;
            }
        }

        numSpawnedCheese = randomAmt;
    }

    void SpawnTraps()
    {
        int randomAmt = Random.Range(trapSpawnAmount.min, trapSpawnAmount.max);
        float radius = 10f;
        int i = 0;
        while (i != randomAmt)
        {
            Vector2 spawnPos = RandomSpawnPosition(spawnBounds);

            if (!Physics.CheckSphere(spawnPos, radius))
            {
                int randInt = Random.Range(0, 2);
                spawnedTraps.Add(Instantiate(trapPrefabs[randInt], spawnPos, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)), transform));
                i++;
            }
        }
    }

    public Vector2 RandomSpawnPosition(PolygonCollider2D bounds)
    {
        float randomX = Random.Range(bounds.points[2].x, bounds.points[0].x);
        float randomY = Random.Range(bounds.points[2].y, bounds.points[0].y);
        return new Vector2(randomX, randomY);
    }

    public void PickedUpCheese(GameObject cheeseObj)
    {
        spawnedCheese.Remove(cheeseObj);
        Destroy(cheeseObj);
    }

    public void GameOver(bool won)
    {
        gameState = GameState.END;
        Cursor.visible = true;
        uiManager.EndPopIn(won);
    }
}
