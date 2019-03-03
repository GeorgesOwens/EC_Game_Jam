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

    // Start is called before the first frame update
    void Start()
    {
        if ( order == -1 )
            order = (int) Mathf.Round(transform.position.y);

        foreach ( Transform child in transform)
        {
            child.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter2DChild(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (Passed) return;

        if (CheckpointManager.ActiveCheckpoint.order > order) return;

        CheckpointManager.ActiveCheckpoint = this;

        Passed = true;
    }

}
