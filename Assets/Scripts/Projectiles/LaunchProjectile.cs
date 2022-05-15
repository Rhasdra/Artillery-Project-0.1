using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : ILaunch
{   
    Transform _transform;
    Rigidbody2D _rb;
    float _impulse;

    public LaunchProjectile(Transform transform, Rigidbody2D rb , float impulse)
    {
        _transform = transform;
        _rb = rb;
        _impulse = impulse;
    }

    public void Launch(float power)
    {
        _rb.AddForce(_transform.right * _impulse * (power/100f)); 
    }
}
