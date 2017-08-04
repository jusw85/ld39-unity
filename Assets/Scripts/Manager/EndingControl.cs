using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EndingControl : MonoBehaviour {
    private ObstacleSpawner os;
    private Animator a;
    private DudeController dc;
    private SpeedControl sc;

    void Start() {
        os = FindObjectOfType<ObstacleSpawner>();
        dc = FindObjectOfType<DudeController>();
        a = GetComponent<Animator>();
        sc = FindObjectOfType<SpeedControl>();
    }

    //private bool isPlayingEnding = false;
    // Update is called once per frame
    void Update() {
        //if (isPlayingEnding) {
        //    sc.speed = Mathf.Lerp(sc.speed, 0f, 5f);
        //    sc.ChangeSpeed();
        //}
    }

    private ObstacleHit[] obstacles;

    private bool isGoodEnding = true;

    public void PlayEnding(bool isGoodEnding) {
        this.isGoodEnding = isGoodEnding;
        //isPlayingEnding = true;
        os.pause = true;
        dc.isGettingHit = true;
        obstacles = FindObjectsOfType<ObstacleHit>();
        foreach (ObstacleHit h in obstacles) {
            h.DisableCollision();
        }
        DOTween
            .To(() => sc.speed, x => TweenSpeed(x), 0f, 10.0f)
            .OnComplete(StopMoving)
            .Play();

        //a.SetTrigger("playEnding");
    }

    public void TweenSpeed(float x) {
        sc.speed = x;
        sc.ChangeSpeed();
    }

    public void DisableSlider() {
        Transform t = FindObjectOfType<Slider>().gameObject.transform;
        Image a = t.Find("Background").GetComponent<Image>();
        Image b = t.Find("GameObject/Fill Area/Fill").GetComponent<Image>();
        DOTween
            .To(() => a.color, x => a.color = x, Color.clear, 1.0f).Play();
        DOTween
            .To(() => b.color, x => b.color = x, Color.clear, 1.0f).Play();
    }

    public void StopMoving() {
        dc.forceIdleAnimation = true;
        DeleteObs();
        //Transform t = Camera.main.transform;
        //t.DOMove(new Vector3(5, 2.43f, -10f), 2f).OnComplete(DeleteObs);
    }

    public void DeleteObs() {
        obstacles = FindObjectsOfType<ObstacleHit>();
        foreach (ObstacleHit h in obstacles) {
            h.Destroy();
        }
        if (isGoodEnding)
            a.SetTrigger("playEnding");
        else
            a.SetTrigger("playEnding2");
    }


    public void DudeDie() {
        dc.GetHit(true);
    }

    public AudioClip slashSfx;
    public AudioClip crashSfx;
    public void PlaySlash() {
        AudioManager a = FindObjectOfType<AudioManager>();
        a.PlaySfx(slashSfx);
    }

    public void PlayCrash() {
        AudioManager a = FindObjectOfType<AudioManager>();
        a.PlaySfx(crashSfx);
    }


}
