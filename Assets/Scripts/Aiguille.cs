﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiguille : MonoBehaviour
{
    [Tooltip("Speed of rotation in degrees per second.")]
    [Range(0, 360)]
    public float speed = 30f;

    private void FixedUpdate()
    {
        transform.Rotate( Vector3.forward, speed * Time.fixedDeltaTime);
    }
}
