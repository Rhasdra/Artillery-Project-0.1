using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Billboard : MonoBehaviour
{
[SerializeField] Transform character;

    void LateUpdate () 
    {
        transform.position = new Vector3(character.position.x , (character.position.y - 1.3f) , character.position.z);
    }
}
