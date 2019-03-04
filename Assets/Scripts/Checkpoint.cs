using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Range(0, 30)]
    [HideInInspector]
    public int order = -1;
    public Transform respawnLocation;
    public bool Passed { get; private set; }

    [Space]
    [Header("Flag Settings")]
    public SpriteRenderer flag;
    public Color baseColor;
    public Color passedColor;

    // Start is called before the first frame update
    void Start()
    {
        if ( order == -1 )
            order = (int) Mathf.Round(transform.position.y);

        foreach ( Transform child in transform)
        {
            if ( child.GetComponent<SpriteRenderer>() )
                child.GetComponent<SpriteRenderer>().enabled = false;
        }

        flag.color = baseColor;
    }

    protected virtual void OnTriggerEnter2DChild(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (Passed) return;

        if (CheckpointManager.ActiveCheckpoint.order > order) return;

        CheckpointManager.ActiveCheckpoint = this;

        Passed = true;
        flag.color = passedColor;

    }

}
