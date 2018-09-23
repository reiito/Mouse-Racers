using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;

    public Sprite[] carSprites;

    public PlayerController[] players = new PlayerController[2];

    private void Awake()
    {
        gameManagerInstance = this;
    }

    private void Start()
    {
        players[0].SetCar(carSprites[PlayerPrefs.GetInt("p1CarIndex")]);
        players[1].SetCar(carSprites[PlayerPrefs.GetInt("p2CarIndex")]);
    }

    private void Update()
    {
        Utility.QuitGame("escape");
    }
}
