using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public CharacterController controller;
    public float speed = 8f, jumpHeight = 5f, jumpForce = 20, gravity = -20.0f, groundDistance = 0.4f, gravityMod = 4;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public int points = 0;
    public Text coins;
    public bool isGrounded = true, hasPowerup = false;
    public GameObject powerupIndicator;
    private Vector3 direction, gravityNormal, gravityFast;

    Rigidbody rb;

    void Start() { 
        rb = GetComponent<Rigidbody>();
        gravityNormal = Physics.gravity;
        gravityFast = gravityNormal * gravityMod; }

    void Update() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (!isGrounded) {
            direction.y += gravity * Time.deltaTime; }
        
        //Move horizontally.
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;

        //Jump.
        if(Input.GetButtonDown("Jump") && isGrounded) {
            direction.y = (jumpHeight * jumpForce); }

        //Gravity Modifier.
        if(rb.velocity.y < 0) {
            Physics.gravity = gravityMod * gravityFast; }

        //Move while airbone.
        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(Vector3.up * forwardInput * speed);

        controller.Move(direction * Time.deltaTime);

        //coins.text = "x : " + points;
    }

    //Obtain Power Up
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Powerup")) {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true); } }

    //List of Power Ups
}