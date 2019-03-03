using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ RequireComponent( typeof(Rigidbody2D) ) ]
public class Movable : MonoBehaviour
{

    public float thrust = 20f;
    public float angularThrust = 10f;
    public float initialVelocity = 20f;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb2d.velocity = transform.up * initialVelocity;
        
    }

    private void Update()
    {

        if ( Input.GetKeyDown("backspace") )
        {
            Respawn();
        }

        if ( Input.GetKeyDown("escape") )
        {
            SceneSwitcher.SwitchToMainMenu();
        }

    }

    private void FixedUpdate()
    {
        var torque = Input.GetAxis("Horizontal") * angularThrust * -1f;

        if (Input.GetAxis("Horizontal") != 0)
        {
            rb2d.angularVelocity = torque;
        }
        
    }

    private void Respawn()
    {
        transform.rotation = Quaternion.identity;
        rb2d.velocity = Vector2.zero;
        rb2d.angularVelocity = 0f;

        CheckpointManager.MoveToActiveCheckpoint( this.transform );
    }
}
