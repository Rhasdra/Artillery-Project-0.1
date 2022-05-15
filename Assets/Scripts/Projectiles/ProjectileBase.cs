using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    public abstract void Launch(float power);
    public abstract void Trajectory();
    // public abstract void ProjHit(GameObject go);
}
