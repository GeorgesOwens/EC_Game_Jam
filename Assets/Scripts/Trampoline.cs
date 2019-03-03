using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public SpringJoint2D spring;
    [Space]
    [Header("Spring Setting")]
    [Range(0, 10)]
    public float bounceDistance;
    [Range(0.01f, 0.9f)]
    [Tooltip("0 = no expansion; 1 = instant expansion.")]
    public float expansionSpeed = 0.1f;

    private float defaultDistance;
    private bool isTransitioning = false;

    private void Awake()
    {
        defaultDistance = spring.distance;
    }
    
    public void OnCollisionEnter2DChild( Collision2D collision )
    {
        if (isTransitioning) return;

        if (!collision.collider.CompareTag("Player")) return;
        
        StartCoroutine("SetSpringDistance", bounceDistance);
    }

    private IEnumerator SetSpringDistance( float targetDist)
    {
        isTransitioning = true;
        for ( float i = 0; i <= 1; i += expansionSpeed)
        {
            spring.distance = Mathf.Lerp(spring.distance, targetDist, i);
            yield return new WaitForFixedUpdate();
        }
        spring.distance = targetDist;
        isTransitioning = false;
        
        if ( targetDist == bounceDistance )
        {
            StartCoroutine("SetSpringDistance", defaultDistance);
        }
    }

    private void ResetSpring()
    {
        StopAllCoroutines();
        spring.distance = defaultDistance;
    }

    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        other.attachedRigidbody.velocity = new Vector2( other.attachedRigidbody.velocity.x, strength);
    }
    */
}
