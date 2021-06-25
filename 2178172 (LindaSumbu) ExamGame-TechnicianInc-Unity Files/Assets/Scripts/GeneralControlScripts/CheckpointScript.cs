using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private GameMaster GM;

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GM.lastCheckpoinPos = transform.position;
        }
    }
}
