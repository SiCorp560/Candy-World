using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumbombMovement : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "DropArea" && collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FallArea")
        {
            Destroy(this.gameObject);
        }
    }
}
