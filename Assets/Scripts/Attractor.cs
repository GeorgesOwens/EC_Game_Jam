using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{

    public float range;
    public float attractionForce;

    private Collider2D[] thingsToPull;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if ( thingsToPull == null )
        {
            thingsToPull = new Collider2D[256];
        }

        int numberOfElementsInRange = Physics2D.OverlapCircleNonAlloc(transform.position, range, thingsToPull);

        for ( int i = 0; i < numberOfElementsInRange; i++ )
        {
            var thing = thingsToPull[i];
            if (thing.GetComponent<Rigidbody2D>() != null)
            {
                Pull( thing.GetComponent<Rigidbody2D>() );
            }
            
        }

    }

    private void Pull(Rigidbody2D target)
    {
        transform.LookAt(target.transform);

        Vector2 dir = -transform.forward;
        float dist = Vector2.Distance(transform.position, target.transform.position);

        var pullForce = dir * attractionForce / dist * dist * Time.deltaTime;
        target.AddForce( pullForce );

        Debug.DrawRay(target.transform.position, dir, Color.white);

        transform.rotation = Quaternion.identity;
    }
}
