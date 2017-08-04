using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownUpgrade : MonoBehaviour {

    private Spawner spawner;
    private ObstacleSpawner obstacleSpawner;

    //public float timeToTownUpgrade = 20f;
    // Use this for initialization
    void Start() {
        spawner = FindObjectOfType<Spawner>();
        obstacleSpawner = FindObjectOfType<ObstacleSpawner>();
        //StartCoroutine(Test());
    }

    // Update is called once per frame
    //void Update() {

    //}

    public void UpgradeTown() {
        spawner.SetTileType(TileType.Castle);
        obstacleSpawner.SetTileType(TileType.Castle);
    }

    //IEnumerator Test() {
    //    yield return new WaitForSeconds(timeToTownUpgrade);
    //    spawner.SetTileType(TileType.Castle);
    //    os.SetTileType(TileType.Castle);
    //    //dudeAnimation.SetHit();

    //    //RuntimeAnimatorController dude2 = (RuntimeAnimatorController)Resources.Load("Dude2");
    //    //animator.runtimeAnimatorController = dude2;

    //    //yield return new WaitForSeconds(2f);
    //    //Debug.Log("!");
    //    //animator.runtimeAnimatorController = dude1;
    //    //yield return new WaitForSeconds(2f);
    //    //Debug.Log("!");
    //    //animator.runtimeAnimatorController = dude2;
    //    //yield return new WaitForSeconds(2f);
    //    //Debug.Log("!");
    //    //animator.runtimeAnimatorController = dude3;
    //    //yield return new WaitForSeconds(2f);
    //    //Debug.Log("!");
    //    //animator.runtimeAnimatorController = dude4;
    //    //yield return new WaitForSeconds(2f);
    //    //Debug.Log("!");
    //    //animator.runtimeAnimatorController = dude5;
    //}
}
