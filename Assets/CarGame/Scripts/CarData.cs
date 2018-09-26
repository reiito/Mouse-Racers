using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarData : MonoBehaviour
{
    public int p1CarIndex;
    public int p2CarIndex;

    public CarData(int i1, int i2)
    {
        p1CarIndex = i1;
        p2CarIndex = i2;
    }
}
