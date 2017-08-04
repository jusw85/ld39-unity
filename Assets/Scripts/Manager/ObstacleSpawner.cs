using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    private PoolManager poolManager;

    public float initialDelay = 3.0f;
    public float spawnMinInterval = 1.0f;
    public float spawnMaxInterval = 2.0f;

    public bool runForever = true;
    public int spawnInstances = 1;
    public int numPerSpawn = 1;

    private bool isStarted = false;
    private bool isRunning = false;

    //public float ySpawn = -0.4f;

    public GameObject[] villageObstacles;
    public GameObject[] castleObstacles;
    private float timeToNextSpawn = 0f;

    public bool pause = false;

    private void Start() {
        poolManager = FindObjectOfType<PoolManager>();
        foreach (GameObject o in villageObstacles) {
            poolManager.CreatePool(o, 7);
        }
        foreach (GameObject o in castleObstacles) {
            poolManager.CreatePool(o, 7);
        }
    }

    private void GenerateTimeToNextSpawn() {
        timeToNextSpawn = Random.Range(spawnMinInterval, spawnMaxInterval);
    }

    // Update is called once per frame
    void Update() {
        if (!isStarted) {
            if (!pause)
                initialDelay -= Time.deltaTime;
            if (initialDelay <= 0)
                isStarted = true;
            return;
        } else {
            if (timeToNextSpawn <= 0) {
                SpawnObstacle();
                GenerateTimeToNextSpawn();
            } else {
                if (!pause)
                    timeToNextSpawn -= Time.deltaTime;
            }
        }
        //if (!isRunning && (runForever || spawnInstances > 0)) {
        //StartCoroutine(SpawnCoroutine());
        //}
    }

    IEnumerator SpawnCoroutine() {
        isRunning = true;
        while (runForever || (spawnInstances - numPerSpawn) >= 0) {
            spawnInstances -= Mathf.Clamp(spawnInstances - numPerSpawn, 0, int.MaxValue);
            for (int i = 0; i < numPerSpawn; i++) {
                SpawnObstacle();
            }
            yield return new WaitForSeconds(Random.Range(spawnMinInterval, spawnMaxInterval));
        }
        isRunning = false;
    }

    public void SpawnObstacle() {
        switch (t) {
            case TileType.Castle:
                SpawnCastleObstacle();
                break;
            case TileType.Village:
            default:
                SpawnVillageObstacle();
                break;
        }
        //Instantiate(obstacle, new Vector3(transform.position.x, ySpawn, 0f), Quaternion.identity);
    }

    public void SpawnCastleObstacle() {
        GameObject obj = poolManager.ReuseObject(castleObstacles[Random.Range(0, castleObstacles.Length)], transform.position, Quaternion.identity);
        AdjustPos(obj);
    }

    public void SpawnVillageObstacle() {
        GameObject obj = poolManager.ReuseObject(villageObstacles[Random.Range(0, villageObstacles.Length)], transform.position, Quaternion.identity);
        AdjustPos(obj);
    }

    private void AdjustPos(GameObject obj) {
        Collider2D c = obj.GetComponent<Collider2D>();
        float yoffset = c.offset.y;
        Bounds b = c.bounds;
        Vector3 pos = obj.transform.position;
        Vector3 newpos = new Vector3(pos.x, pos.y + (b.size.y / 2), pos.z);
        obj.transform.position = newpos;
    }

    private TileType t;

    public void SetTileType(TileType t) {
        this.t = t;
    }
}
