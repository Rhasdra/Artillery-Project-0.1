using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTeam", menuName = "Gameplay/Team")]
public class TeamSO : ScriptableObject
{
    public new string name;
    public Color color;
    public GameObject[] characters;
}
