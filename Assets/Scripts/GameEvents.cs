using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void MatchStart();
    public static event MatchStart MatchStartEvent;

    private void Start() {  
        MatchStartEvent();
    }

    public delegate void CharacterTakesDamage();
    public static event CharacterTakesDamage CharacterTakesDamageEvent;

}
