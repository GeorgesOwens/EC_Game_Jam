using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [Range(0, 20)]
    public float strength;

    void OnTriggerEnter2D(Collider2D other)
    {
        other.attachedRigidbody.velocity = new Vector2( other.attachedRigidbody.velocity.x, strength);
    }
}
