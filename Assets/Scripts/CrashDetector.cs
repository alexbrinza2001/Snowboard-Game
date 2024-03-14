using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{   
    [SerializeField] float delay;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool canCrash = true;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground" && canCrash == true) {
            canCrash = false;
            FindObjectOfType<PlayerController>().disableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("reloadScene", delay);
        }
    }

    void reloadScene() {
        SceneManager.LoadScene(0);
    }
}
