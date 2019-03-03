using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public bool lockX = true;


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3
        (
            lockX ? transform.position.x : player.position.x,
            player.position.y,
            transform.position.z
        );
    }
}
