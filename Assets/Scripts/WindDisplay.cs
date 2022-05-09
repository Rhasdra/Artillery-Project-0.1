using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WindDisplay : MonoBehaviour
{
    [SerializeField] AreaEffector2D areaEffector;
    [SerializeField] GameObject angleDisplay;
    [SerializeField] WindManager windManager;
    [SerializeField] TextMeshProUGUI powerDisplay;

    private void Start() {
        DisplayWindAngle();
        DisplayWindPower();
    }

    public void DisplayWindAngle()
    {
        angleDisplay.transform.rotation = Quaternion.Euler(0f, 0f, areaEffector.forceAngle);
    }

    public void DisplayWindPower()
    {
        int length = windManager.randomPower;
        string displayText = ("");
        
        for (int i = 0; i < length; i++)
        {
            displayText += "X";
        }

        powerDisplay.text = displayText;
    }
}
