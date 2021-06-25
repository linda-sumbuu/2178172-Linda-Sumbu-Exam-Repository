using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    private Vector3 posA;

    private Vector3 posB;

    private Vector3 nextPos;

    public bool isMoving;

    public PressurePlate pressurePlate;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;

    private void Start()
    {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nextPos = posB;
        isMoving = false;
    }
    void Update()
    {
        if(isMoving == true)
        {
            Move();
        }
       
    }

    public void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPos, speed * Time.deltaTime);

        if (Vector3.Distance(childTransform.localPosition, nextPos) <= 0.1)
        {
            ChangePos();
        }
    }

    private void ChangePos()
    {
        nextPos = nextPos != posA ? posA : posB;
    }
}
