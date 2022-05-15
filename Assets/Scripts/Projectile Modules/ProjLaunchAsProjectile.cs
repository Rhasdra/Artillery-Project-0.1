using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjLaunchAsProjectile : IProjBehaviour
{
    Transform _transform;
    Rigidbody2D _rb;
    float _impulse;

    public ProjLaunchAsProjectile(Transform transform, Rigidbody2D rb , float impulse)
    {
        _transform = transform;
        _rb = rb;
        _impulse = impulse;
    }

    public override void Launch(float power)
    {
        _rb.AddForce(_transform.right * _impulse * (power/100f)); 
    }
}
