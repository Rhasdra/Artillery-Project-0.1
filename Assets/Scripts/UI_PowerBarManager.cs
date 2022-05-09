using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PowerBarManager : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Awake() 
    {
        slider = GetComponentInChildren<Slider>();    
    }

    public void UpdatePowerBar(int currentPower)
    {
        slider.value = currentPower;
    }
}
