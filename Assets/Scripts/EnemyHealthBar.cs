﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    
    public Image fill;
    // Start is called before the first frame update
    public void SetHealth(int health)
    {
        slider.value = health;
        
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

      
    }
}
