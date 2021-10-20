using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Source : MonoBehaviour {
    public Image collect;
    // Update is called once per frame
    void Update() {
        transform.Rotate(0, 0, 90 * Time.deltaTime); }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            collect.gameObject.SetActive(true);
            Destroy(gameObject); //insert respawn item here after being destroyed for x time
        }
    }
}
