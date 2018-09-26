using UnityEngine;
using UnityEngine.UI;

public class CarGameManager : MonoBehaviour
{
    public static CarGameManager gameManagerInstance;

    public Material[] carSprites;

    public CarController[] players = new CarController[2];

    private void Awake()
    {
        gameManagerInstance = this;
        Cursor.visible = false;
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
