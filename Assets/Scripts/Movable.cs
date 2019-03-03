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

        var forwardMovement = new Vector2(0, Input.GetAxis("Vertical") * Time.deltaTime * thrust);
        rb2d.AddRelativeForce( forwardMovement );

        //Debug.Log(rb2d.angularVelocity);
        //angularThrust *= rb2d.angularVelocity / 2;
        var torque = Input.GetAxis("Horizontal") * Time.deltaTime * angularThrust * -1f;

        if (Input.GetAxis("Horizontal") != 0)
        {
            rb2d.angularVelocity = torque;
        }
        // torque : [-0.16, 0.16]

    }

    private void Respawn()
    {
        transform.rotation = Quaternion.identity;
        rb2d.velocity = Vector2.zero;
        rb2d.angularVelocity = 0f;

        CheckpointManager.MoveToActiveCheckpoint( this.transform );
    }
}
