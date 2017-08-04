using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOnContact : MonoBehaviour {

    public bool destroyBlocks;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnTriggerEnter2D(Collider2D collision) {
        GameObject obj = collision.gameObject;
        if (obj.tag.Equals("Player")) {
            //obj.GetComponent<DudeController>().Respawn();
            Time.timeScale = 0f;
        } else {
            if (destroyBlocks) {
                PoolObject o = obj.GetComponent<PoolObject>();
                if (o != null)
                    o.Destroy();
                else
                    Destroy(obj);
            }
        }
    }
}
