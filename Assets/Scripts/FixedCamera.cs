using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCamera : MonoBehaviour {
    private Transform target;
    private Vector3 offset;
    public float smoothSpeed = 0.15f;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - transform.position; }

    void LateUpdate() {
        Vector3 desiredPosition = transform.position = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); } }
