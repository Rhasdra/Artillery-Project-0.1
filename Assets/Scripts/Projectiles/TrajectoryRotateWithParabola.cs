using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRotateWithParabola : ITrajectory
{
    Rigidbody2D _rb;
    Transform _transform;

    public TrajectoryRotateWithParabola(Transform transform, Rigidbody2D rb)
    {
        _rb = rb;
        _transform = transform;
    }

    public void Trajectory()
    {
        float projectileAngle;

        //Glitches if updates on the first frame where the velocity is 0??
        if (_rb.velocity.y != 0f)
        {
        projectileAngle = Mathf.Atan2(_rb.velocity.y , _rb.velocity.x) * Mathf.Rad2Deg;

        _transform.localRotation = Quaternion.AngleAxis(projectileAngle, _transform.forward);
        }
    }
}
