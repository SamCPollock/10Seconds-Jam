using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    public Light light;

    public float startingSpeedX;
    public float startingSpeedZ;

    public float speed;

    public bool isGreen = false;

    public GameTimer gameTimer; 



    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = new Vector3(startingSpeedX, 0, startingSpeedZ);
    }

    void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.CompareTag("Player"))
        {
            // hit the player
            if (isGreen)
            {
                gameTimer.ReverseTime(1);
            }
            else
            {
                gameTimer.ReverseTime(-1);

            }

        }

        if (collision.collider.gameObject.CompareTag("Kicker"))
        {
            // got kicked
            isGreen = true;
            speed = speed * 2f;
            light.color = Color.green;
        }
    }
}
