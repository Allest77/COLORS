using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    //NEEDS AN INDICTAOR
    public PlayerController player;

    public BoxCollider blueBlock, yellowBlock;
    public Material[] materials;
    public float changeInterval = 0.01f;

    private Renderer rend;

    private void Awake() //Awake happens before start.
    {
        player = GameObject.FindObjectOfType<PlayerController>(); //public variable player is a short name to access playercontroller script.
    }

    void Start()
    {
        blueBlock = GetComponent<BoxCollider>();
        yellowBlock = GetComponent<BoxCollider>();

        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.hasBlue)
        {
            blueBlock.isTrigger = true;
            player.hasDoubleJump = false;
            player.hasYellow = false;
            player.hasWhite = false;
            //place functionality here: Overwrite WOTever current power up you have.
        }

        if (player.hasYellow)
        {
            yellowBlock.isTrigger = true;
            player.hasDoubleJump = false;
            player.hasBlue = false;
            player.hasWhite = false;
            player.jumpHeight = 2.66f;
            Debug.Log("wtf");
            //place functionality here:
        }
    }
}