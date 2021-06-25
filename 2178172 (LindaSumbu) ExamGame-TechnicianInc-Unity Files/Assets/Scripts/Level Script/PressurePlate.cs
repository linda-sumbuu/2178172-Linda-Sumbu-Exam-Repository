using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public MovingPlatformScript movingPlatform;

    public bool isColliding;

    public GameObject pressureLight;

    private void Start()
    {
        isColliding = false;
        pressureLight.gameObject.SetActive(false);
    }

    private void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            movingPlatform.isMoving = true;
            //movingPlatform.Move();
            isColliding = true;
            pressureLight.gameObject.SetActive(true);
        }

        else
        {
            isColliding = false;
           // pressureLight.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Box"))
        {
            movingPlatform.isMoving = true;
            //movingPlatform.Move();
            isColliding = true;
            pressureLight.gameObject.SetActive(true);
        }

        else
        {
            isColliding = false;
            
            //pressureLight.gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        isColliding = false;
        if (isColliding == false)
        {
            movingPlatform.isMoving = false;
            pressureLight.gameObject.SetActive(false);
        }
    }
}
