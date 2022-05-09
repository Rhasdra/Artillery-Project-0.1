using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_CharacterUI : MonoBehaviour
{
    public CharacterManager character;
    public TeamSO characterTeam;
    public CharacterVariablesManager charVars;
    
    [SerializeField] Slider hpBar;
    [SerializeField] TextMeshProUGUI debugInfo;
    [SerializeField] Image fillColor;

    [SerializeField] float offset = 1.3f;

    [SerializeField] bool showDebug;

    private void OnEnable() 
    {
        if (character != null)
        {
            characterTeam = character.GetComponent<CharacterManager>().characterTeam;
            charVars = character.GetComponentInChildren<CharacterVariablesManager>();
            fillColor.color = characterTeam.color;
        }
    }

        void LateUpdate () 
    {
        transform.position = new Vector3(character.transform.position.x, (character.transform.position.y - offset) , 0f);
    }
    
    private void Update() 
    {
        hpBar.value = charVars.currentHPPercent;
        
        if (showDebug)
        {
        UpdateDebugInfo();
        }
    }

    private void UpdateDebugInfo()
    {
        debugInfo.text = ("Delay: " + charVars.delay.ToString() + "\n");
        debugInfo.text += ("HP: " + charVars.currentHP.ToString() + "\n");
    }

}
