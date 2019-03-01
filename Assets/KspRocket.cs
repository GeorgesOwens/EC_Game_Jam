using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KspRocket : MonoBehaviour
{
    private Rigidbody2D rbd ;
    public float _thrust;

    private void Awake()
    {
        rbd = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rbd.AddForce(new Vector2(1, 1));
        _thrust = 25F;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalThrust = Input.GetAxis("Horizontal") * Time.deltaTime * _thrust;
        var verticalThrust = -Input.GetAxis("Vertical") * Time.deltaTime * _thrust;

        rbd.AddForce(rbd.GetVector(new Vector2()));
    }
}
