using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType {
    Village, Castle
}

public class Spawner : MonoBehaviour {

    private PoolManager poolManager;
    public GameObject[] spawnVillagePlatform;
    public GameObject[] spawnCastlePlatform;
    public GameObject[] spawnGrass;
    public GameObject[] spawnMountain;

    public float initialDelay = 3.0f;
    public float spawnMin = 1.0f;
    public float spawnMax = 2.0f;

    public bool runForever = true;
    public int spawnInstances = 1;
    public int numPerSpawn = 1;

    private bool isStarted = false;
    private bool isRunning = false;

    private void Start() {
        poolManager = FindObjectOfType<PoolManager>();
        poolManager.CreatePool(spawnGrass[0], 3);
        poolManager.CreatePool(spawnMountain[0], 3);
        foreach (GameObject o in spawnVillagePlatform) {
            poolManager.CreatePool(o, 7);
        }
        foreach (GameObject o in spawnCastlePlatform) {
            poolManager.CreatePool(o, 7);
        }
    }

    // Update is called once per frame
    void Update() {
        //if (!isStarted) {
        //    initialDelay -= Time.deltaTime;
        //    if (initialDelay <= 0)
        //        isStarted = true;
        //    return;
        //}
        //if (!isRunning && (runForever || spawnInstances > 0)) {
        //    StartCoroutine(SpawnCoroutine());
        //}
    }

    IEnumerator SpawnCoroutine() {
        isRunning = true;
        while (runForever || (spawnInstances - numPerSpawn) >= 0) {
            spawnInstances -= numPerSpawn;
            for (int i = 0; i < numPerSpawn; i++) {
                SpawnPlatform(transform.position);
            }
            yield return new WaitForSeconds(Random.Range(spawnMin, spawnMax));
        }
        isRunning = false;
    }

    public void SpawnPlatform(Vector2 r) {
        switch (t) {
            case TileType.Castle:
                SpawnCastlePlatform(r);
                break;
            case TileType.Village:
            default:
                SpawnVillagePlatform(r);
                break;
        }
        //GameObject obj = poolManager.ReuseObject(spawnVillagePlatform[Random.Range(0, spawnVillagePlatform.Length)], new Vector3(r.x, r.y, 0f), Quaternion.identity);
        //AdjustPos(obj);
    }

    public void SpawnVillagePlatform(Vector2 r) {
        GameObject obj = poolManager.ReuseObject(spawnVillagePlatform[Random.Range(0, spawnVillagePlatform.Length)], new Vector3(r.x, r.y, 0f), Quaternion.identity);
        AdjustPos(obj);
    }

    public void SpawnCastlePlatform(Vector2 r) {
        GameObject obj = poolManager.ReuseObject(spawnCastlePlatform[Random.Range(0, spawnCastlePlatform.Length)], new Vector3(r.x, r.y, 0f), Quaternion.identity);
        AdjustPos(obj);
    }

    public void SpawnGrass(Vector2 r) {
        GameObject obj = poolManager.ReuseObject(spawnGrass[0], new Vector3(r.x, r.y, 0f), Quaternion.identity);
        AdjustPos(obj);
    }
    public void SpawnMountain(Vector2 r) {
        GameObject obj = poolManager.ReuseObject(spawnMountain[0], new Vector3(r.x, r.y, 0f), Quaternion.identity);
        AdjustPos(obj);
    }

    private void AdjustPos(GameObject obj) {
        Collider2D c = obj.GetComponent<Collider2D>();
        Bounds b = c.bounds;
        Vector3 pos = obj.transform.position;
        Vector3 newpos = new Vector3(pos.x + (b.size.x / 2.0f), pos.y, pos.z);
        obj.transform.position = newpos;
    }

    private TileType t;

    public void SetTileType(TileType t) {
        this.t = t;
    }
}
