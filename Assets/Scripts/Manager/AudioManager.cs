using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private AudioSource sfxAudioSource;
    // Use this for initialization
    void Start() {
        sfxAudioSource = GetComponents<AudioSource>()[1];
    }

    public void PlaySfx(AudioClip clip) {
        sfxAudioSource.PlayOneShot(clip);
    }
}
