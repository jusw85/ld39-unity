using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeUpgrade : MonoBehaviour {

    private Animator animator;
    //private DudeAnimation dudeAnimation;
    private RuntimeAnimatorController dude1, dude2, dude3, dude4, dude5;

    void Start() {
        DudeController dude = FindObjectOfType<DudeController>();
        animator = dude.GetComponentInChildren<Animator>();
        //dudeAnimation = GetComponentInChildren<DudeAnimation>();
        dude1 = (RuntimeAnimatorController)Resources.Load("Dude1");
        dude2 = (RuntimeAnimatorController)Resources.Load("Dude2");
        dude3 = (RuntimeAnimatorController)Resources.Load("Dude3");
        dude4 = (RuntimeAnimatorController)Resources.Load("Dude4");
        dude5 = (RuntimeAnimatorController)Resources.Load("Dude5");
        //StartCoroutine(Test());

    }

    // Update is called once per frame
    void Update() {
    }

    public void SetState(int state) {
        switch (state) {
            case 1:
                animator.runtimeAnimatorController = dude1;
                break;
            case 2:
                animator.runtimeAnimatorController = dude2;
                break;
            case 3:
                animator.runtimeAnimatorController = dude3;
                break;
            case 4:
                animator.runtimeAnimatorController = dude4;
                break;
            case 5:
            default:
                animator.runtimeAnimatorController = dude5;
                break;
        }
    }

    //IEnumerator Test() {
    //    yield return new WaitForSeconds(2f);
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
