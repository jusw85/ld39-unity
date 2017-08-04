using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherFire : MonoBehaviour {

    private PoolManager poolManager;
    public GameObject arrow;
    // Use this for initialization
    void Start() {
        poolManager = FindObjectOfType<PoolManager>();
        poolManager.CreatePool(arrow, 20);
    }

    public void FireArrow() {
        poolManager.ReuseObject(arrow, transform.position, Quaternion.identity);
    }
}
