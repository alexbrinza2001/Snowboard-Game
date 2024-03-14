using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed;
    [SerializeField] float baseSpeed;
    Rigidbody2D rigid;
    SurfaceEffector2D effector2D;
    [SerializeField] ParticleSystem snowEffect;
    bool canMove = true;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        effector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (canMove == true) {
            rotatePlayer();
            respondToBoost();
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        snowEffect.Play();
    }

    void OnCollisionExit2D(Collision2D other) {
        snowEffect.Stop();
    }

    void respondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            effector2D.speed = boostSpeed;
        }
        else {
            effector2D.speed = baseSpeed;
        }

    }

    void rotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid.AddTorque(-torqueAmount);
        }
    }

    public void disableControls() {
        canMove = false;
    }

}
