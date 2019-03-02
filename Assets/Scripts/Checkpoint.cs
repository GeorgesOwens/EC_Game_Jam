using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Transform respawnLocation;
    public bool Passed { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        foreach ( Transform child in transform)
        {
            child.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter2DChild(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (Passed) return;

        CheckpointManager.ActiveCheckpoint = this;

        Passed = true;
    }

}
