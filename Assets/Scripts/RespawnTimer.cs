using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTimer : MonoBehaviour {
    //NEEDS AN INDICTAOR
    public PlayerController player;

    public float respawnDelay;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerController>(); //public variable player is a short name to access playercontroller script.
    }

    public void Respawn() {
        StartCoroutine("RespawnCoroutine");
    }

    //Respawn Timer for obj
    IEnumerator RespawnCoroutine()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        //gameObject.transform.position = gameObject.respawnPoint;
        gameObject.SetActive(true);
    }
}
