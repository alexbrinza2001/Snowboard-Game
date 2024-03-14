using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    [SerializeField] float delay;
    [SerializeField] ParticleSystem finishLineEffect;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            finishLineEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("reloadScene", delay);
        }
    }

    void reloadScene() {
        SceneManager.LoadScene(0);
    }
}
