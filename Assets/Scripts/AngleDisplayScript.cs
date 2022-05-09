using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AngleDisplayScript : MonoBehaviour
{
    [SerializeField] private CharacterVariablesManager charVars;
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private TurnsManagerScript _turnsManager;

    private void Awake() 
    {
        // if ( charVars != null)
        // {
        // charVars = FindObjectOfType<CharacterVariablesManager>();
        // }
        
        

        TurnsManagerScript.NextTurnEvent += GetCurrentCharAngle;
    }

    // Update is called once per frame
    void Update()
    {
        if (charVars != null)
        {
        textDisplay.text = (charVars.currentAngle.ToString() + "°");
        }
    }

    void GetCurrentCharAngle()
    {   
        // [MUST] move this to awake somehow
        _turnsManager = FindObjectOfType<TurnsManagerScript>();

        print ("Get Current Char Angle Event");
        charVars = _turnsManager.currentCharacter.GetComponentInChildren<CharacterVariablesManager>();
    }
}
