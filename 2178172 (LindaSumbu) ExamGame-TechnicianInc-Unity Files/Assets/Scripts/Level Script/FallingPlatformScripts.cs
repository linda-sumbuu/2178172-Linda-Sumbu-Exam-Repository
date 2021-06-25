using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformScripts : MonoBehaviour
{
    Rigidbody2D RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Invoke("DropPlatform", 0.5f);
            Destroy(gameObject, 0.8f);
        }
    }

    private void DropPlatform()
    {
        RB.isKinematic = false;
    }
}
