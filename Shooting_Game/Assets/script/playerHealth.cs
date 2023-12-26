using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public Slider sliderHealth;
    private int Health;
    const int max_Health= 100;

    private void Start()
    {
        Health = max_Health;
    }
    public void DecreaseHealth(int mountHealht)
    {
        Health -= mountHealht;
        sliderHealth.value = Health;
        if (Health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("you are die!");
        }

    }



}
