using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    GameManager gameManager;

    SpriteRenderer playerCar;

    float verticalMovement;
    float horizontalMovement;

    private void Awake()
    {
        playerCar = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        //gameManager = GameManager.gameManagerInstance;
    }

    private void Update()
    {
        // store mouse movement
        verticalMovement = Input.GetAxis("Mouse Y") * speed; //forward
        horizontalMovement = Input.GetAxis("Mouse X") * turnSpeed; //turning

        Debugger.Message("v: " + verticalMovement + ", h: " + horizontalMovement);
    }

    private void FixedUpdate()
    {
        // flip axis to suit top down view, invert vertical to go from left to right
        transform.position += new Vector3(-verticalMovement * Time.fixedDeltaTime, horizontalMovement * Time.fixedDeltaTime, 0);

        // TODO: 
        // - have rotation change depending on input from mouse to face the direction the cars is going
        // - when car roation is facing opposite direction, un invert verical movement
    }

    public void SetCar(Sprite newCar)
    {
        playerCar.sprite = newCar;
    }
}
