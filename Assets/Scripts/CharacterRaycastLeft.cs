using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRaycastLeft : MonoBehaviour
{
    [SerializeField] characterStats characterStats;
    void Awake()
    {
        transform.position = new Vector3 (transform.parent.position.x -characterStats.characterWidth, transform.parent.position.y, 0f);
    }
}
