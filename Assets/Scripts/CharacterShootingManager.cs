using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShootingManager : MonoBehaviour
{
    [SerializeField] private InputManagerSO input;
    [SerializeField] private CharacterManager characterManager;
    [SerializeField] private CharacterVariablesManager charVars;
    [SerializeField] private characterStats characterStats;
    [SerializeField] private Transform shotSpawnPoint;
    [SerializeField] private Transform character;

    public float currentAngle;

    [SerializeField] private float acceleration;
    [SerializeField] private float holdTimerDefault = 0.2f;
    [SerializeField] private float holdTimer;

    [SerializeField] private GameObject projectileT1;

    ///// EVENTS /////
    public delegate void CharacterFire();
    public static event CharacterFire CharacterFireEvent; 
    
    private void Awake() 
    {
        
    }

    void Start()
    {
        currentAngle = 180 + 50;
        transform.localRotation = Quaternion.Euler(0f, 0f, 230f);
        holdTimer = holdTimerDefault;
    }

    private void Update() 
    {
        if(characterManager.isMyTurn == true)
        {
            AdjustAngle (input.verticalValue, input.verticalDown);

                if (input.fireDown)
            {
                FireT1();
            }
        }
    }

    public void AdjustAngle(float input, bool keyDown)
    {
        if(keyDown)
        {
            currentAngle += input * ( 1 - (currentAngle % 1) );
        }

        if (input != 0)
        {
            holdTimer -= Time.deltaTime;
            
            if(holdTimer < 0f)
            {
            currentAngle += input * 0.05f * acceleration;
            acceleration = Mathf.Clamp(acceleration + (acceleration * Time.deltaTime * 1.5f) , 0, 20f);
            }
        }else
        {
            acceleration = 1f;
            holdTimer = holdTimerDefault;
        }

        currentAngle = Mathf.Clamp(currentAngle, 90f, 270f);
        transform.localRotation = Quaternion.Euler (0f, 0f, (int)currentAngle);
    }

    private void FireT1()
    {
        if(projectileT1 != null){
            //Angle adjust to accomodate the SpawnForce of the projectiles when the character flips
            Quaternion spawnRotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + 180f);
            Quaternion flippedSpawnRotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z);
            
            charVars.delay += (int)(Random.Range(0,25));
           
            if(character.localScale.x == -1f)
            {
                Instantiate(projectileT1, shotSpawnPoint.position, flippedSpawnRotation);
            }else{
                Instantiate(projectileT1, shotSpawnPoint.position, spawnRotation);
            } 

            CharacterFireEvent?.Invoke();
            characterManager.CharacterEndTurnMethod();
        }
    } 
}
