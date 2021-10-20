using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public CharacterController controller;
    public float speed = 8, jumpForce = 10, gravity = -20;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public int points = 0;
    public Text coins;
    private Vector3 direction;

    void Start()
    {
        
    }

    void Update() {
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;

    bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        direction.y += gravity * Time.deltaTime;
        if (isGrounded) {
            if (Input.GetButtonDown("Jump")) {
                direction.y = jumpForce;
            }
        }

        controller.Move(direction * Time.deltaTime);

        coins.text = "x : " + points;
    }
}