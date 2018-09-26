using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public static MouseController mouseControllerInstance;

    public float speed;
    public float turnSpeed;

    Manager manager;

    float verticalMovement;
    float horizontalMovement;

    int collectedCheese;
    public int CollectedCheese { get { return collectedCheese; } set { collectedCheese = value; } }

    private void Awake()
    {
        mouseControllerInstance = this;
    }

    private void Start()
    {
        manager = Manager.managerInstance;
    }

    private void Update()
    {
        // store mouse movement
        verticalMovement = Input.GetAxis("Mouse Y") * speed; //forward
        horizontalMovement = Input.GetAxis("Mouse X") * turnSpeed; //turning
    }

    private void FixedUpdate()
    {
        if (manager.gameState == GameState.PLAY)
        {
            transform.position += -transform.up * verticalMovement * Time.fixedDeltaTime;
            transform.Rotate(new Vector3(0, 0, -horizontalMovement * Time.fixedDeltaTime));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            if (manager.gameState == GameState.PLAY)
            {
                manager.GameOver(false);
            }
        }
        else if (collision.gameObject.tag == "Cheese")
        {
            manager.PickedUpCheese(collision.gameObject);
            collectedCheese++;
            Debug.Log(collectedCheese / 2 + "/" + manager.numSpawnedCheese);
        }
        else if (collision.gameObject.tag == "End" && collectedCheese / 2 >= manager.numSpawnedCheese)
        {
            manager.GameOver(true);
        }
    }
}
