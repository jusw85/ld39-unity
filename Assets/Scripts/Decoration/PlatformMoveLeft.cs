using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveLeft : MonoBehaviour {

    public float movementSpeed;
    public float multiplier = 1f;
    public bool ignoreSpeedControl = false;

    private void Start() {
        var sc = FindObjectOfType<SpeedControl>();
        movementSpeed = sc.speed;
    }

    void Update() {
        Vector3 displacement = Vector3.left * movementSpeed * multiplier * Time.deltaTime;
        transform.Translate(displacement);
    }
}
