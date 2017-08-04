using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformNextSpawn : PoolObject {

    private Spawner spawner;
    private Collider2D collider2d;
    private float spawnXThreshold;

    public bool nextSpawned = false;
    public bool isGrass = false;
    public bool isMountain = false;

    private void Awake() {
        collider2d = GetComponent<Collider2D>();
    }

    void Start() {
        spawner = FindObjectOfType<Spawner>();
        spawnXThreshold = spawner.transform.position.x;
    }

    // Update is called once per frame
    void Update() {
        if (nextSpawned)
            return;
        Bounds b = collider2d.bounds;
        Vector2 r = new Vector2(b.max.x, transform.position.y);
        if (r.x <= spawnXThreshold) {
            nextSpawned = true;
            if (isGrass) {
                spawner.SpawnGrass(r);
            } else if (isMountain) {
                spawner.SpawnMountain(r);
            } else {
                spawner.SpawnPlatform(r);
            }
        }
    }


    public override void OnObjectReuse() {
        nextSpawned = false;
    }

}
