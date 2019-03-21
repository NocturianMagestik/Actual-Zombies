﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;
    private int damagedlt;

    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite HalfHeart;
    public Sprite ZeroHeart;



    // Start is called before the first frame update    
    void Start()
    {
        Initialise();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHearts();
        if (health <= 0)
        {
            Debug.Log("DED");
            Destroy(gameObject);
            Application.Quit();
            
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i <= health - 1)
            {
                hearts[i].sprite = FullHeart;

            }
            else if (i >= health)
            {

                hearts[i].sprite = ZeroHeart;
            }
            else
            {
                hearts[i].sprite = HalfHeart;
            }
        }


    }

    void Initialise()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = FullHeart;
            Debug.Log(i);
        }

    }
}
