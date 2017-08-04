using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressControl : MonoBehaviour {

    public Slider slider;
    private float sliderVal = 0f;
    public float timeToEnd = 30f;
    private float timer = 0f;

    private TownUpgrade tu;
    private DudeUpgrade du;
    private bool townUpgraded = false;
    private DudeController dude;
    private EndingControl ec;

    private SpeedControl sc;

    // Use this for initialization
    void Start() {
        tu = GetComponent<TownUpgrade>();
        du = GetComponent<DudeUpgrade>();
        slider.value = sliderVal;
        sc = FindObjectOfType<SpeedControl>();
        ChangeSpeed(startSpeed);
        dude = FindObjectOfType<DudeController>();

        ec = GetComponent<EndingControl>();
    }

    private void ChangeSpeed(float newspeed) {
        sc.speed = newspeed;
        sc.ChangeSpeed();
    }

    public float startSpeed = 6f;
    public float endSpeed = 10f;

    private bool isEndingPlaying = false;
    // Update is called once per frame
    void Update() {
        if (isEndingPlaying)
            return;
        if (timer >= timeToEnd && !dude.isGettingHit) {
            isEndingPlaying = true;
            if (slider.value >= 0.95) {
                ec.PlayEnding(true);
            } else {
                ec.PlayEnding(false);
            }

        } else {
            timer = Mathf.Clamp(timer + Time.deltaTime, 0f, timeToEnd);
            slider.value = Mathf.Clamp(slider.value + (Time.deltaTime / timeToEnd), 0f, 1f);

            if (!townUpgraded && timer >= (0.6f * timeToEnd)) {
                townUpgraded = true;
                tu.UpgradeTown();
            }

            if (!dude.isGettingHit)
                ChangeSpeed(Mathf.Lerp(startSpeed, endSpeed, timer / timeToEnd));

            if (slider.value <= 0.2f) {
                du.SetState(1);
            } else if (slider.value <= 0.4f) {
                du.SetState(2);
            } else if (slider.value <= 0.6f) {
                du.SetState(3);
            } else if (slider.value <= 0.8f) {
                du.SetState(4);
            } else if (slider.value <= 1.0f) {
                du.SetState(5);
            }
        }
    }
}
