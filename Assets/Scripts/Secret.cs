using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Secret : MonoBehaviour {
    private void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            SceneManager.LoadScene("CarSelect");
        }
    }
}
