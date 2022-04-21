using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    private Vector2 movementInput;
    public float moveSpeed;
    public float rotationSpeed;
    public float kickStrength;

    public bool isRunning;

    public bool isAttacking = false;

    public bool canScore = true;

    [Header("References")]
    public Animator animator;
    public GameObject kickSphere;
    public GameObject pauseCanvas;

    private AudioSource audioSource;

    private void Awake()
    {
        
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        animator.SetBool("isRunning", isRunning);
        if (!isAttacking)
        {
            Vector3 movementVector3 = new Vector3(movementInput.x, 0, movementInput.y);
        transform.Translate(movementVector3 * moveSpeed * Time.deltaTime, Space.World);

    

            Vector3 movementDirection = movementInput;
            //movementDirection.Normalize();

            if (movementDirection != Vector3.zero)
            {
                isRunning = true;
                transform.forward = movementVector3;
                //Quaternion toRotation = Quaternion.LookRotation(movementVector3, Vector3.up);
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            }

            else
            {
                isRunning = false;
            }
        }
    }

    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    void OnSwing()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            kickSphere.SetActive(true);
            animator.SetTrigger("Kicking");
            Invoke("StopAttacking", 1);
        }
    }

    void StopAttacking()
    {
        isAttacking = false;
        kickSphere.SetActive(false);
    }

    void OnPause()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            canScore = false;
            audioSource.Play();
            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(kickStrength, transform.position, 1f);
            Invoke("RestoreCanScore", 0.2f);
        }    

    }
    private void RestoreCanScore()
    {
        canScore = true;
    }
}
