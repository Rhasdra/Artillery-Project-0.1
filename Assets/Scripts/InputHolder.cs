using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHolder
{
    ///// Movement /////
    public float horizontalValue;

    public bool longJumpDown;
    public bool backFlipJumpDown;

    //// Shooting /////
        //Angle
    public float verticalValue;
    public bool verticalDown;
        //Power
    public float powerValue;
    public bool powerDown;
        //Fire
    public bool fireDown;
        //Shots
    public bool cycleShotsDown;
    public bool t1Down;
    public bool t2Down;
    public bool t3Down;
    public bool skipTurnDown;

    ///// Camera /////
    public float cameraMoveHorizontalValue;
    public float cameraMoveVerticalValue;
    public bool cameraCenterDown;
}
