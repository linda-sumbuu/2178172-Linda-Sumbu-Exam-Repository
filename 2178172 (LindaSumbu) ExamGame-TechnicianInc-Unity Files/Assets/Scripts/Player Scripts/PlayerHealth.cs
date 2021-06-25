using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    public int hammerNum;

    public Image[] hammers;
    public Sprite fullHammer;
    public Sprite emptyHeart;


    private void Start()
    {

    }

    private void Update()
    {
        for (int i = 0; i < hammers.Length; i++)
        {

            if (health > hammerNum)
            {
                health = hammerNum;
            }
            if (i < health)
            {
                hammers[i].sprite = fullHammer;

            }
            else
            {
                hammers[i].sprite = emptyHeart;

            }
            if (i < hammerNum)
            {
                hammers[i].enabled = true;
            }
            else
            {
                hammers[i].enabled = false;

            }
        }
    }
}
