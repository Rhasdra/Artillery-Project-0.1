using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEvents : MonoBehaviour
{
    public float damage;
    [SerializeField] CharacterManager characterManager;

    public delegate void CharacterEndTurn();
    public static event CharacterEndTurn CharacterEndTurnEvent; 

    // private void OnTriggerEnter2D(Collider2D other) 
    // {
    //     damage = other.gameObject.GetComponent<ProjectileManager>().damage;
    // }

    
    private void Awake() 
    {
        // CharacterShootingManager.CharacterFireEvent += EndTurn;
    }

    // void EndTurn()
    // {
    //     CharacterEndTurnEvent.Invoke();
    // }
}
