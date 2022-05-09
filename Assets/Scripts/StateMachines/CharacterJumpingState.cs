using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJumpingState : IState
{
    CharacterSM _characterSM;
    CharacterManager _characterManager;

    public CharacterJumpingState(CharacterSM characterSM, CharacterManager characterManager)
    {
        _characterSM = characterSM;
        _characterManager = characterManager;
    }


    public void Enter()
    {

    }

    public void Tick()
    {
        _characterManager.CheckIfCanMove();
        if ( _characterManager.canMove )
        {
            //_characterSM.ChangeState(_characterSM.GroundedState);
        }
    }

    public void FixedTick()
    {
        _characterManager.CharacterTilt();
    }

    public void Exit()
    {

    }
}
