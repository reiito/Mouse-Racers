using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager animationStateMachineInstance;

    UIManager uiManager;
    Manager manager;

    private void Awake()
    {
        animationStateMachineInstance = this;
    }

    private void Start()
    {
        uiManager = UIManager.uiManagerInstance;
        manager = Manager.managerInstance;
    }

    public void StartMenuAnimEnd()
    {
        uiManager.menuObj.SetActive(false);
        manager.gameState = GameState.PLAY;
    }

    public void StartMenuAnimHalf()
    {
        manager.SpawnLevel();
    }

    bool restarted = false;
    public void EndMenuRestartHalf()
    {
        restarted = true;
        manager.SpawnLevel();
    }

    public void EndMenuBackHalf()
    {
        restarted = false;
    }

    public void EndMenuEnd()
    {
        uiManager.endObj.SetActive(false);
        if (restarted)
        {
            manager.gameState = GameState.PLAY;
        }
        else
        {
            manager.gameState = GameState.MENU;
        }
    }
}
