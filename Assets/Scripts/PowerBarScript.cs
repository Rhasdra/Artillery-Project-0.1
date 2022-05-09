using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBarScript : MonoBehaviour
{
    [SerializeField] private CharacterPowerScript getPower;

    [SerializeField] private Slider powerBar;

    void Awake()
    {

    }

    void Update()
    {
        powerBar.value = (int)getPower.currentPower;
    }

}
