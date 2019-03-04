using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    public Timer timer;
    TextMeshProUGUI textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        timer.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (!timer.stopwatch.IsRunning) return;

        textMesh.text = timer.GetTimerValue();
    }
}
