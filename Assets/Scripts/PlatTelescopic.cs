using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatTelescopic : MonoBehaviour
{
    [Space]
    [Header("Cycle")]
    [Range(0, 10)]
    [Tooltip("Speed of one cycle")]
    public float speed;
    [Space]
    [Header("Object References")]
    public SpriteRenderer minWidth;
    public SpriteRenderer maxWidth;
    public SpriteRenderer platform;

    private BoxCollider2D platformCollider;

    private void Awake()
    {
        platformCollider = platform.GetComponent<BoxCollider2D>();
    }

    private void SetPlatformWidth( float width)
    {
        var size = new Vector2(width, platform.size.y);
        platform.size = size;
        platformCollider.size = size;
    }

    private void Start()
    {
        SetPlatformWidth(minWidth.size.x);
        minWidth.GetComponent<SpriteRenderer>().enabled = false;
        maxWidth.GetComponent<SpriteRenderer>().enabled = false;

        StartCoroutine("Animate", true);
    }
    
    private IEnumerator Animate( bool expand)
    {
        var targetWidth = expand ? maxWidth.size.x : minWidth.size.x;
        float increment = speed * 0.001f;

        for ( float i = 0; i <= 1; i += increment)
        {
            SetPlatformWidth(Mathf.Lerp(platform.size.x, targetWidth, i));
            yield return null;
        }
        
        SetPlatformWidth(targetWidth);

        StartCoroutine("Animate", !expand);
        yield return null;
    }

}
