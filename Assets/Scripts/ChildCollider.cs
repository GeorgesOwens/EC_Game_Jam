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
        if (!col.isTrigger) return;

        transform.parent.SendMessage("OnTriggerEnter2DChild", collision, SendMessageOptions.DontRequireReceiver);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!col.isTrigger) return;

        transform.parent.SendMessage("OnTriggerStay2DChild", collision, SendMessageOptions.DontRequireReceiver);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!col.isTrigger) return;

        transform.parent.SendMessage("OnTriggerExit2DChild", collision, SendMessageOptions.DontRequireReceiver);
    }

}
