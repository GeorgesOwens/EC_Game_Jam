using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendule : MonoBehaviour
{
    
    [Header("Animation Settings")]
    [Range(0, 5)]
    public float speed = 1;
    [Range(0,1)]
    public float amplitude = 0.33f;

    private Animator animController;

    private void Awake()
    {
        animController = GetComponent<Animator>();    
    }

    private void Update()
    {
        animController.speed = speed;

        animController.SetFloat("SwingAmplitude", amplitude);
    }
}
