﻿using UnityEngine;

public class Utility : MonoBehaviour
{

    public static void QuitGame(string exitKey)
    {
        if (Input.GetKeyDown(exitKey))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
        }
    }
}
