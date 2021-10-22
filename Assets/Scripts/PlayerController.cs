using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Reference Sound Manager
    public SoundManager jump;
    public CharacterController controller;
    public float speed = 8f, jumpHeight = 2.66f, originalJumpHeight, jumpForce = 20, gravity = -20.0f, groundDistance = 0.4f, gravityMod = 4;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public int points = 0;
    public Text coins;
    public bool isGrounded = true, hasDoubleJump, hasBlue, hasYellow, hasWhite;
    public GameObject powerupIndicator;
    private Vector3 direction, gravityNormal, gravityFast;
    public List<GameObject> listOfPowerups;

    public Text timer;
    private TimerController time;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gravityNormal = Physics.gravity;
        gravityFast = gravityNormal * gravityMod;
        jump = GameObject.FindObjectOfType<SoundManager>();
        originalJumpHeight = jumpHeight;
        time = timer.GetComponent<TimerController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (!isGrounded)
        {
            direction.y += gravity * Time.deltaTime;
        }

        //Move horizontally.
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;

        //Jump.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            direction.y = (jumpHeight * jumpForce);
            Debug.Log("Jumping");
        }
        else
        {
            if (gameObject.CompareTag("Red"))
            {
                isGrounded = true;
                jumpHeight = 0;
                jumpForce = 0;
            }
        }

        //Gravity Modifier.
        if (rb.velocity.y < 0)
        {
            Physics.gravity = gravityMod * gravityFast;
        }

        //Move while airbone.
        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(Vector3.up * forwardInput * speed);

        controller.Move(direction * Time.deltaTime);

        //coins.text = "x : " + points;
    }

    //Obtain Power Up
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered!");

        if (other.gameObject.CompareTag("Pink"))
        {
            other.gameObject.SetActive(false);
            hasDoubleJump = true;
            jumpHeight = 6;
            hasYellow = false;
            powerupIndicator.SetActive(true);
            Debug.Log("Entered Pink!");
        }

        if (other.gameObject.CompareTag("Blue"))
        {
            other.gameObject.SetActive(false);
            hasBlue = true;
            powerupIndicator.SetActive(true);
            jumpHeight = originalJumpHeight;
            Debug.Log(jumpHeight);
        }

        if (other.gameObject.CompareTag("Yellow"))
        {
            other.gameObject.SetActive(false);
            hasYellow = true;
            powerupIndicator.SetActive(true);
            jumpHeight = originalJumpHeight;
            Debug.Log(jumpHeight);
        }

        if (other.gameObject.CompareTag("White"))
        {
            other.gameObject.SetActive(false);
            hasWhite = true;
            powerupIndicator.SetActive(true);
            jumpHeight = originalJumpHeight;
        }
    }

    //Stop the player from jumping up walls w/ ground check collision.
    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Wall"))
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }
    }
    //List of Power Ups.

    //time.EndTimer();

}