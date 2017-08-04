using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHit : PoolObject {

    public bool destroyOnHit = false;

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Equals("Player")) {
            DudeController dc = collision.GetComponent<DudeController>();
            dc.GetHit();
            if (destroyOnHit) {
                Destroy();
            }
        }
    }

    public void DisableCollision() {
        Collider2D c = GetComponent<Collider2D>();
        c.enabled = false;
    }
}
