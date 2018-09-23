using UnityEngine;
using UnityEngine.UI;

public class Debugger : MonoBehaviour
{
    public static void Message(string message)
    {
        Debug.Log("[DEBUG] " + message);
    }

    public static void Error(string message)
    {
        Debug.Log("[ERROR] " + message);
    }

    public static void ButtonPressed(string buttonName)
    {
        Debug.Log("[DEBUG] '" + buttonName + "' pressed.");
    }
}
