using UnityEngine;
using System.Collections;

public class SpawnPointController : MonoBehaviour {

    public GameObject spawnType;

    void Awake() {
        GameObject obj = Instantiate(spawnType, transform.position, Quaternion.identity) as GameObject;
        obj.GetComponent<DudeController>().respawnPoint = transform.position;
    }

}
