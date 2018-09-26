using UnityEngine;

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
}
