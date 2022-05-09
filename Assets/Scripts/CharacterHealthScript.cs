using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthScript : MonoBehaviour
{
    [SerializeField] private CharacterManager character;
    [SerializeField] private characterStats stats;
    [SerializeField] private CharacterVariablesManager charVars;
    
    [SerializeField] private int currentHP;

    private void Awake() 
    {        
        charVars.maxHP = stats.maxHP;
        currentHP = stats.maxHP;
       
        UpdateHealthValue(currentHP);
    }

    public void UpdateHealthValue(float hpValue)
    {
        charVars.currentHP = hpValue;

        float percentage = hpValue / charVars.maxHP;
        charVars.currentHPPercent = percentage;

        //Debug.Log("UpdateHealthValue");
        //print(charVars.currentHPPercent + "---" + hpValue + "---" + charVars.maxHP);
    }

    public void TakeDamage(float damage)
    {
        currentHP = currentHP - (int)damage;
        //Debug.Log("Took Damage");

        UpdateHealthValue((int)currentHP);
    }

}