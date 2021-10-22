using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Source : MonoBehaviour
{

    //NEEDS AN INDICTAOR
    public GameObject pc;

    private PlayerController player;

    public List<GameObject> powerUps;
    public GameObject currentPowerUp; //pickupEffect, blueBlock;
    public float jumpMultiplier = 1.5f;

    private void Awake() //Awake happens before start.
    {
        player = pc.GetComponent<PlayerController>();

        //player = GameObject.FindObjectOfType<PlayerController>(); //public variable player is a short name to access playercontroller script.
        //blueBlock = FindGameObjectWithTag("BLUE BLOCK").GetComponent<BoxCollider>(); //We need to find the solid blue obj's collider.
    }

    void Update()
    {
        transform.Rotate(0, 0, 90 * Time.deltaTime);
        /*if (player.hasDoubleJump)
        {
            player.hasBlue = false;
            player.hasYellow = false;
            player.hasWhite = false;
            //place functionality here:
            player.jumpHeight = 6;
        } */

        if (player.hasBlue)
        {
            player.hasDoubleJump = false;
            player.hasYellow = false;
            player.hasWhite = false;
        }

        if (player.hasYellow)
        {
            player.hasDoubleJump = false;
            player.hasBlue = false;
            player.hasWhite = false;
            //place functionality here:
        }

        if (player.hasWhite)
        {
            player.hasDoubleJump = false;
            player.hasBlue = false;
            player.hasYellow = false;
        }

        IEnumerator doublejump()
        {
            Debug.Log("1");
            yield return new WaitForSeconds(2);
            Debug.Log("2");
            yield return new WaitForSeconds(2);
            Debug.Log("3");
        }
    }
}

//Switch out Solid Yellow Block w/ See Through if player has yellow source.

//Switch out See Through Blue w/ Solid if player has blue source