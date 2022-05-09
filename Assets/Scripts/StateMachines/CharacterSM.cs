using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSM : StateMachine
{
    public CharacterManager characterManager;

    public CharacterNotMyTurnState NotMyTurnState { get; private set; }
    public CharacterGroundedState GroundedState { get; private set; }
    public CharacterJumpingState JumpingState { get; private set; }

    private void Awake() 
    {
        NotMyTurnState = new CharacterNotMyTurnState(this);
        GroundedState = new CharacterGroundedState(this, characterManager);
        JumpingState = new CharacterJumpingState(this, characterManager);
    }

    private void Start() 
    {
        ChangeState(GroundedState);
    }
}
