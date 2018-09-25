using UnityEngine;
using RawMouseDriver;
using RawInputSharp;

public class PlayerController : MonoBehaviour
{
    [Range(0, 1)]
    public int player;

    public float speed;
    public float turnSpeed;

    GameManager gameManager;

    SpriteRenderer playerCar;

    float verticalMovement;
    float horizontalMovement;
    float scrollMovement;

    //RawMouseDriver.RawMouseDriver mouseDriver;
    //RawMouse mouse;

    private ManyMouse[] manyMouseMice;

    private void Awake()
    {
        playerCar = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        //gameManager = GameManager.gameManagerInstance;
        //mouseDriver = new RawMouseDriver.RawMouseDriver();

        SetUpMice();
    }

    private void Update()
    {
        //mouseDriver.GetMouse(1, ref mouse);

        // store mouse movement
        verticalMovement = manyMouseMice[player].Delta.y * speed; //forward
        horizontalMovement = manyMouseMice[player].Delta.x * turnSpeed; //turning
        //scrollMovement = Input.GetAxis("Mouse ScrollWheel") * turnSpeed;
    }

    private void FixedUpdate()
    {
        // flip axis to suit top down view, invert vertical to go from left to right
        transform.position += transform.right * verticalMovement * Time.fixedDeltaTime;

        transform.Rotate(new Vector3(0, 0, -horizontalMovement * Time.fixedDeltaTime));
        //transform.Rotate(new Vector3(0, 0, scrollMovement * Time.fixedDeltaTime));

        // TODO: 
        // - have rotation change depending on input from mouse to face the direction the cars is going


        // - when car roation is facing opposite direction, un invert verical movement

    }

    public void SetCar(Sprite newCar)
    {
        playerCar.sprite = newCar;
    }

    void SetUpMice()
    {
        int numMice = ManyMouseWrapper.MouseCount;
        if (numMice > 0)
        {
            manyMouseMice = new ManyMouse[numMice];
            for (int i = 0; i < numMice; i++)
            {
                manyMouseMice[i] = ManyMouseWrapper.GetMouseByID(i);
                manyMouseMice[i].EventButtonDown += EventButtonDownJoinGame;
                manyMouseMice[i].EventMouseDisconnected += EventMouseDisconnected;
            }
        }
    }

    private void EventButtonDownJoinGame(ManyMouse mouse, int buttonId)
    {
        if (buttonId == 0)
        {
            mouse.EventButtonDown -= EventButtonDownJoinGame;

            mouse.EventButtonDown += EventButtonDownLeaveGame;//listen for another button down
        }

    }

    private void EventButtonDownLeaveGame(ManyMouse mouse, int buttonId)
    {
        if (buttonId == 1)
        {
            mouse.EventButtonDown -= EventButtonDownLeaveGame;//listen for another button down


            mouse.EventButtonDown += EventButtonDownJoinGame;
        }
    }

    private void EventMouseDisconnected(ManyMouse mouse)
    {
        //keep details of disconnected mouse... then keep looking for it with an init?
        Debug.Log("Mouse Disconnected: " + mouse.DeviceName);
    }
}
