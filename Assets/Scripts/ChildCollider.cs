using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Collider2D ) )]
public class ChildCollider : MonoBehaviour
{
    private Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.parent.SendMessage("OnTriggerEnter2DChild", collision, SendMessageOptions.DontRequireReceiver);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        transform.parent.SendMessage("OnTriggerStay2DChild", collision, SendMessageOptions.DontRequireReceiver);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent.SendMessage("OnTriggerExit2DChild", collision, SendMessageOptions.DontRequireReceiver);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.parent.SendMessage("OnCollisionEnter2DChild", collision, SendMessageOptions.DontRequireReceiver);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        transform.parent.SendMessage("OnCollisionStay2DChild", collision, SendMessageOptions.DontRequireReceiver);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.parent.SendMessage("OnCollisionExit2DChild", collision, SendMessageOptions.DontRequireReceiver);
    }

}
