using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerBarDisplayScript : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI textDisplay;
   [SerializeField] private CharacterPowerScript currentPower;
   int roundPower;

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        roundPower = (int)currentPower.currentPower;
        textDisplay.text = roundPower.ToString();
    }
}
