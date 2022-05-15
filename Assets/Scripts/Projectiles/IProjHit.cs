using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjHit
{
    void ProjHit(Transform hitPosition, GameObject goHit, float damage);
}