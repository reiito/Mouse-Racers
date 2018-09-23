using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer playerCar;

    private void Awake()
    {
        playerCar = GetComponent<SpriteRenderer>();
    }

    public void SetCar(Sprite newCar)
    {
        playerCar.sprite = newCar;
    }
}
