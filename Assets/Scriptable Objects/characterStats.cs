using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character")]
public class characterStats : ScriptableObject
{

public string characterName;
public int maxHP = 3000;
public int characterType;

public float characterWidth = 1f;
public float movementSpeed = 5f;
public float longJumpForce = 5f;
public float backFlipJumpForceX = 15f;
public float backFlipJumpForceY = 15f;

public float angleChangeSpeed = 20f;
public float sweetSpotAngleMin;
public float sweetSpotAngleMax;

}
