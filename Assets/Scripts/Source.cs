using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Source : MonoBehaviour { 
    public GameObject pickupEffect;
    public float jumpMultiplier = 1.4f;

    void Update() {
        transform.Rotate(0, 0, 90 * Time.deltaTime); }

    //private void OnTriggerEnter(Collider other) {
        //if (other.gameObject.CompareTag("Player")) {
            //PickUp(other); } }

    //void PickUp(Collider player)
    //{
        //Pink power up
        //Instantiate(pickupEffect, transform.position, transform.rotation);
        //PlayerController jump = player.GetComponent<jumpHeight>();
        //jump.jumpHeight *= jumpMultiplier;
        //Destroy(gameObject);
    //}
}
