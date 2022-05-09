using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGroundedState : IState
{
    CharacterSM _characterSM;
    CharacterManager _characterManager;

    public CharacterGroundedState(CharacterSM characterSM, CharacterManager characterManager)
    {
        _characterSM = characterSM;
        _characterManager = characterManager;
    }


    public void Enter()
    {
        _characterManager.CharacterTilt();
    }

    public void Tick()
    {

    }

    public void FixedTick()
    {

    }

    public void Exit()
    {

    }
}
