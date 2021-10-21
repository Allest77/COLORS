using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveJump : MonoBehaviour {
    //HOW TO REFERENCE PLAYER CONTROLLER SCRIPT.
    GameObject.Find("Player").GetComponent<PlayerController>;
    PlayerController playercontroller;
    playerController = GetComponent<PlayerController>();

    GetComponent<PlayerController>().jumpHeight = 5f;
    playerController.jumpHeight()

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Deactivates Jump.
    private void OnTriggerEnter()
    {
        other.gameObject.GetComponent(playerController).enabled = false;
    }
}
