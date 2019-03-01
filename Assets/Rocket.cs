using Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    public float _thrustForce;
    public Vector2 _direction;

    private int bounds;
    //private Rigidbody2D rigidbody;

    private void Awake()
    {
        //rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        bounds = 5;
        _thrustForce = 0.2F;
    }

    // Update is called once per frame
    void Update()
    {

        ApplyThrust();

        if (RocketOutOfBounds())
        {
            StopAllMovementTowardsWall(GetNextToWall());
        }
        
        //rigidbody.AddForce(new Vector2(horizontalPosition, verticalPosition));
        
        transform.Translate(_direction.x, _direction.y, 0);
    }

    private void StopAllMovementTowardsWall(NextToWall nextToWall)
    {
        if (nextToWall.HasFlag(NextToWall.Down))
        {
            _direction.x = Math.Abs(_direction.x);
        }

        if (nextToWall.HasFlag(NextToWall.Up))
        {
            _direction.x = -Math.Abs(_direction.x);
        }

        if (nextToWall.HasFlag(NextToWall.Left))
        {
            _direction.y = Math.Abs(_direction.y);
        }

        if (nextToWall.HasFlag(NextToWall.Right))
        {
            _direction.y = -Math.Abs(_direction.y);
        }
    }

    private NextToWall GetNextToWall()
    {
        NextToWall nextToWall = NextToWall.none;

        if(transform.position.x > bounds)
        {
            nextToWall |= NextToWall.Up;
        }

        if (transform.position.x < -bounds)
        {
            nextToWall |= NextToWall.Down;
        }

        if (transform.position.y > bounds)
        {
            nextToWall |= NextToWall.Right;
        }

        if (transform.position.y < -bounds)
        {
            nextToWall |= NextToWall.Left;
        }

        if(nextToWall.HasFlag(NextToWall.Down) 
            || nextToWall.HasFlag(NextToWall.Up) 
            || nextToWall.HasFlag(NextToWall.Left) 
            || nextToWall.HasFlag(NextToWall.Right))
        {
            return nextToWall;
        }
        
        return NextToWall.Nothing;
    }

    private bool RocketOutOfBounds()
    {
        if (OutOfBounds(transform.position.x) || OutOfBounds(transform.position.y))
        {
            return true;
        }

        return false;
    }

    private bool OutOfBounds(float x)
    {
        if(Math.Abs(x) > bounds)
        {
            return true;
        }

        return false;
    }

    private void ApplyThrust()
    {
        var horizontalThrust = Input.GetAxis("Horizontal") * Time.deltaTime * _thrustForce;
        var verticalThrust = -Input.GetAxis("Vertical") * Time.deltaTime * _thrustForce;

        _direction.x += horizontalThrust;
        _direction.y += verticalThrust;
    }
}
