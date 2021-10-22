using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Reference Sound Manager
    public SoundManager jump;
    public CharacterController controller;
    public float speed = 8f, jumpHeight = 2.66f, jumpForce = 20, gravity = -20.0f, groundDistance = 0.4f, gravityMod = 4;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public int points = 0;
    public Text coins;
    public bool isGrounded = true, hasDoubleJump, hasBlue, hasYellow, hasWhite;
    public GameObject powerupIndicator;
    private Vector3 direction, gravityNormal, gravityFast;
    public List<GameObject> listOfPowerups;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gravityNormal = Physics.gravity;
        gravityFast = gravityNormal * gravityMod;
        jump = GameObject.FindObjectOfType<SoundManager>();
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
        if (other.gameObject.CompareTag("Pink"))
        {
            Destroy(other.gameObject);
            hasDoubleJump = true;
            powerupIndicator.SetActive(true);
        }

        if (other.gameObject.CompareTag("Blue"))
        {
            Destroy(other.gameObject);
            hasBlue = true;
            powerupIndicator.SetActive(true);
        }

        if (other.gameObject.CompareTag("Yellow"))
        {
            Destroy(other.gameObject);
            hasYellow = true;
            powerupIndicator.SetActive(true);
        }

        if (other.gameObject.CompareTag("White"))
        {
            Destroy(other.gameObject);
            hasWhite = true;
            powerupIndicator.SetActive(true);
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

}