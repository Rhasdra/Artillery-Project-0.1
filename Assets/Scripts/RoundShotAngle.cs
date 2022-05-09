using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundShotAngle : MonoBehaviour
{
    [SerializeField] Transform shootingManager;
    float roundRotation;

    void Update()
    {
        roundRotation = Mathf.Round(shootingManager.rotation.eulerAngles.z);
        transform.localRotation = Quaternion.Euler(0f, 0f, roundRotation + 180);
    }
}
