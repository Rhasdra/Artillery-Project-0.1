using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapon")]
public class wpnSO : ScriptableObject
{

public new string name;
public float impulse = 30f;
public float gravity = 1f;
public float weight = 2f;
public float damage = 500f;
public float radius = 1f;
public int numberOfProjectiles = 1;
public float timeBetweenShots;

public int rechargeTurns = 0;

public int delay;

}
