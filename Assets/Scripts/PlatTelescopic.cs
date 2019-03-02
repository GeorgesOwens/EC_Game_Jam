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
    public Transform minWidth;
    public Transform maxWidth;
    public Transform platform;

    //public AnimationCurve plot = new AnimationCurve();

    private void SetPlatformWidth( float width)
    {
        platform.localScale = new Vector3(width, platform.localScale.y, platform.localScale.z);
        
    }

    private void Start()
    {
        SetPlatformWidth(minWidth.localScale.x);
        minWidth.GetComponent<SpriteRenderer>().enabled = false;
        maxWidth.GetComponent<SpriteRenderer>().enabled = false;

        StartCoroutine("Animate", true);
    }
    
    private IEnumerator Animate( bool expand)
    {
        var targetWidth = expand ? maxWidth.localScale.x : minWidth.localScale.x;
        float increment = speed * 0.001f;

        for ( float i = 0; i <= 1; i += increment)
        {
            SetPlatformWidth(Mathf.Lerp(platform.localScale.x, targetWidth, i));
            //plot.AddKey(Time.realtimeSinceStartup, i);
            yield return null;
        }
        
        SetPlatformWidth(targetWidth);

        StartCoroutine("Animate", !expand);
        yield return null;
    }

}
