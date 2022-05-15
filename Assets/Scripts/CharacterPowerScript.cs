using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPowerScript : MonoBehaviour
{
    [SerializeField] private InputManagerSO input;
    [SerializeField] private Slider powerBar;
    
    public float currentPower;
    
    [SerializeField] private float acceleration;
    [SerializeField] private float holdTimer;
    [SerializeField] private float holdTimerDefault = 0.2f;

    private void Awake() 
    {
        holdTimer = holdTimerDefault;
    }
    
    private void Update() 
    {
        AdjustPower(input.powerValue , input.powerDown);
    }

    private void AdjustPower(float input, bool keyDown)
    {
        if(keyDown)
        {
            currentPower += input * (1f - (currentPower % 1));
        }

        if (input != 0)
        {
            holdTimer -= Time.deltaTime;
            
            if(holdTimer < 0f)
            {
            currentPower += input * 0.01f * acceleration;
            acceleration = Mathf.Clamp(acceleration + (acceleration * Time.deltaTime) , 3f, 25f);
            }
        }else
        {
            acceleration = 1f;
            holdTimer = holdTimerDefault;
            AdjustPowerViaPowerBar();
        }

        currentPower = Mathf.Clamp(currentPower, 0f, 100f);
    }

        
        public void AdjustPowerViaPowerBar()
        {
            if(input.powerValue == 0f)
            {
                currentPower = powerBar.value;
            }
        }
}
