using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarMenuManager : MonoBehaviour
{
    public static CarMenuManager menuManagerInstance;

    public Material[] cars;

    public CarSwitcher[] selectedCars = new CarSwitcher[2];

    private void Awake()
    {
        menuManagerInstance = this;
    }

    public void Play()
    {
        CarPersistance.SaveData(selectedCars[0].CurrentCarIndex, selectedCars[1].CurrentCarIndex);
        SceneManager.LoadScene("Main");
    }

    public bool CheckSame()
    {
        if (selectedCars[0].CurrentCarIndex == selectedCars[1].CurrentCarIndex)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
