using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiguille : MonoBehaviour
{
    [Header("Animation Settings")]
    [Range(0, 5)]
    public float speed = 1f;
    public bool clockwise = false;
    public bool ticking = false;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("Direction", (clockwise ? -1 : 1));
        animator.speed = speed;
        animator.SetFloat("TickOrNot", (ticking ? 1 : 0));
    }
}
