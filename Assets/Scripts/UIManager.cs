using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManagerInstance;

    public Transform playerTransform;

    public GameObject menuObj;
    public GameObject endObj;

    public Text endText;

    public Animator menuAnim;
    public Animator endAnim;

    Manager manager;
    MouseController player;

    float horizontalMovement;

    private void Awake()
    {
        uiManagerInstance = this;
        menuObj.SetActive(true);
        endObj.SetActive(false);
    }

    private void Start()
    {
        manager = Manager.managerInstance;
        player = MouseController.mouseControllerInstance;
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxis("Mouse X") * player.turnSpeed; //turning
    }

    private void FixedUpdate()
    {
        if (manager.gameState == GameState.MENU)
        {
            playerTransform.Rotate(new Vector3(0, 0, -horizontalMovement * Time.fixedDeltaTime));
        }
    }

    public void EndPopIn(bool won)
    {
        endObj.SetActive(true);
        endAnim.SetTrigger("PopIn");
        if (won)
        {
            endText.text = "Yum";
        }
        else
        {
            endText.text = "Ouch";
        }
    }

    public void QuitButton()
    {
        Utility.QuitGame();
    }

    public void BackButton()
    {
        endAnim.SetTrigger("Back");
        menuObj.SetActive(true);
        menuAnim.SetTrigger("PopIn");
    }

    public void PlayButton()
    {
        menuAnim.SetTrigger("Play");
        Cursor.visible = false;
    }

    public void RestartButton()
    {
        endAnim.SetTrigger("Restart");
    }

    public void StartMenuAnimHalf()
    {
        manager.SpawnLevel();
    }

    public void StartMenuAnimEnd()
    {
        menuObj.SetActive(false);
        manager.gameState = GameState.PLAY;
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
        endObj.SetActive(false);
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
