using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : Checkpoint
{
    void Awake()
    {
        passedColor = baseColor = Color.white;
        order = 90000;
    }

    protected override void OnTriggerEnter2DChild(Collider2D other)
    {
        base.OnTriggerEnter2DChild(other);
        print("Finished!");
    }
}
