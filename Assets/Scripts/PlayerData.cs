using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int p1CarIndex;
    public int p2CarIndex;

    public PlayerData(int i1, int i2)
    {
        p1CarIndex = i1;
        p2CarIndex = i2;
    }
}
