using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject endMenu;


    private void Awake()
    {
        startMenu.SetActive(true);
        endMenu.SetActive(false);
    }

    private void Start()
    {
        
    }
}
