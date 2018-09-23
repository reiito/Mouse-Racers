using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSwitcher : MonoBehaviour
{
    public Image playerCarImage;

    MenuManager menuManager;

    int currentCarIndex;
    public int CurrentCarIndex { get { return currentCarIndex; } }

    private void Start()
    {
        menuManager = MenuManager.menuManagerInstance;
        playerCarImage.GetComponent<Image>();
        currentCarIndex = Random.Range(0, menuManager.cars.Length);
        playerCarImage.sprite = menuManager.cars[currentCarIndex];
    }

    public void LeftArrow()
    {
        currentCarIndex--;
        if (menuManager.CheckSame())
        {
            currentCarIndex--;
        }

        if (currentCarIndex <= 0)
        {
            currentCarIndex = menuManager.cars.Length - 1;
        }

        playerCarImage.sprite = menuManager.cars[currentCarIndex];
    }

    public void RightArrow()
    {
        currentCarIndex++;
        if (menuManager.CheckSame())
        {
            currentCarIndex++;
        }

        if (currentCarIndex >= menuManager.cars.Length - 1)
        {
            currentCarIndex = 0;
        }

        playerCarImage.sprite = menuManager.cars[currentCarIndex];
    }
}
