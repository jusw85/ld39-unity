using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControl : MonoBehaviour {

    public float speed;

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void ChangeSpeed() {
        PlatformMoveLeft[] pmls = FindObjectsOfType<PlatformMoveLeft>();
        foreach (PlatformMoveLeft pml in pmls) {
            if (!pml.ignoreSpeedControl)
                pml.movementSpeed = speed;
        }
    }

    public void OnValidate() {
        ChangeSpeed();
    }
}
