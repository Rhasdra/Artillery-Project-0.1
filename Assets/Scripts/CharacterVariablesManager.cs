using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVariablesManager : MonoBehaviour
{
    public float currentHPPercent;
    public float currentHP;
    public float maxHP;

    public int currentPower;
    public float currentAngle;

    public int delay;
    

    [SerializeField] Transform shootingManager;
    [SerializeField] CharacterPowerScript powerBar;
    
    private void Awake() {
        powerBar = FindObjectOfType<CharacterPowerScript>();
    }

    private void Start() {
        TurnsManagerScript.NextMacroTurnEvent += ResetDelay;
    }


    private void Update() 
    {
        currentAngle = (int)(transform.parent.localScale.x * (shootingManager.transform.rotation.eulerAngles.z - 180f));
        currentPower = (int)powerBar.currentPower;
    }

    void ResetDelay()
    {
        delay = 0;
    }
}
