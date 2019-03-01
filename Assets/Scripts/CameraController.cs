using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3
        (
            transform.position.x,
            player.position.y,
            transform.position.z
        );
    }
}
