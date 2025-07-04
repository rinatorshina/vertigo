using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    //bool variable that determines whether the player is moving as well as rotating
    public bool allowMovement = false;
    //float variable that is our wobble interval***

    //float variable that times how long it has been since the last wobble***

    public float wobbleInterval = 1.0f;

    public float wobbleTimer = 0f;

    public float wobbleAmount = 100f;

    public Rigidbody rigidBody;

    public float accelerometerRotSensitivity = 50f;

    public float accelerometerMoveSensitivity = 10f;

    private int direction;

    private void Start()
    {
        direction = Random.Range(-1, 1);
        if (direction == 0)
        {
            direction = 1;
        }
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        InputSystem.EnableDevice(Accelerometer.current);
    }

    private void OnDisable()
    {
        InputSystem.DisableDevice(Accelerometer.current);
    }

    void Update()
    {
        wobbleTimer += Time.deltaTime;

        if (wobbleTimer > wobbleInterval)
        {
            direction = Random.Range(-1, 1);
            if (direction == 0)
            {
                direction = 1;
            }


            wobbleTimer = 0f;
        }

        rigidBody.angularVelocity = new Vector3(0f, 0f, wobbleAmount * direction * Time.deltaTime);


        if (Accelerometer.current != null)
        {
            Vector3 acceleration = Accelerometer.current.acceleration.ReadValue();

            //Below is for correcting the player's rotation with the accelerometer

            //set velocity to the player's rigidbody using the acceleration input
            //Breaking this down a bit more:
            //Use the x value from the acceleration, and apply this to the z axis of the rigidbody velocity in order to rotate left and right

            rigidBody.angularVelocity += new Vector3(0f, 0f, -acceleration.x * Time.deltaTime * accelerometerRotSensitivity);

            //If the player is supposed to be moving as well as rotating:

            //Use the x value from the acceleration
            //Add force to the player's rigidbody on the x axis (this will move the player left or right)
            if (allowMovement == true)
            {
                rigidBody.linearVelocity += new Vector3(acceleration.x * Time.deltaTime * accelerometerMoveSensitivity, 0f, 0f);
            }
        }

    }



}
