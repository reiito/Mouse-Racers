using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPersistance : MonoBehaviour
{
    public static void SaveData(int i1, int i2)
    {
        PlayerPrefs.SetInt("p1CarIndex", i1);
        PlayerPrefs.SetInt("p2CarIndex", i2);
    }

    public static PlayerData LoadData()
    {
        int p1Car = PlayerPrefs.GetInt("p1CarIndex");
        int p2Car = PlayerPrefs.GetInt("p2CarIndex");

        return new PlayerData(p1Car, p2Car);
    }
}
