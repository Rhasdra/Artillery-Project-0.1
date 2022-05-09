using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNotMyTurnState : IState
{
    CharacterSM _characterSM;

    public CharacterNotMyTurnState(CharacterSM characterSM)
    {
        _characterSM = characterSM;
    }

    // automatically gets called in the State machine. Allows you to delay flow if desired
    public void Enter()
    {

    }
    // allows simulation of Update() method without a MonoBehaviour attached
    public void Tick()
    {

    }
    // allows simulatin of FixedUpdate() method without a MonoBehaviour attached
    public void FixedTick()
    {

    }
    // automatically gets called in the State machine. Allows you to delay flow if desired
    public void Exit()
    {

    }
}
