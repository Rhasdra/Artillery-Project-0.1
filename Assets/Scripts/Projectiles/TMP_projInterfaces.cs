using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMP_projInterfaces : ProjectileBase
{
    ILaunch _launchBehaviour;
    ITrajectory _trajectoryBehaviour;
    IProjHit _projHitBehaviour;

    Transform _transform = null;
    Rigidbody2D _rb = null;

    [SerializeField] wpnSO wpnSO;
    [SerializeField] GameObject _explosion;

    float _impulse;
    float _power = 0;


    RaycastHit2D raycastHit;
    public float hitAngle;
    public Vector3 hitPosition;
    public float damage;

    private void Awake() 
    {
        _transform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
        _impulse = wpnSO.impulse;

        _launchBehaviour = new LaunchProjectile(_transform, _rb, _impulse);
        _trajectoryBehaviour = new TrajectoryRotateWithParabola(_transform, _rb);
    }

    private void Start() 
    {
        Launch(50f);
    }

    private void Update() 
    {
        Trajectory();
        Raycast();
    }

    private void OnCollisionEnter(Collision other) 
    {
        // var damageable = other.gameObject.GetComponent<IDamageable>();
        // if (damageable == null) return;

        ProjHit(other.gameObject);
    }

    void Raycast()
    {
        raycastHit = Physics2D.Raycast (_rb.position, transform.right, 1f, LayerMask.GetMask("Characters"));

        Debug.DrawRay(_rb.position, transform.right, Color.red);

        //Returns hitAngle=0 on 90degrees full hit
        if(raycastHit)
        {    
        hitAngle = Vector2.Angle(raycastHit.normal, -transform.right);
        hitPosition = raycastHit.point;
        damage = wpnSO.damage * Mathf.Lerp(1f, 0f, hitAngle/90f);
        }
    }

    public override void Launch(float power)
    {
        _launchBehaviour.Launch(power);
    }

    public override void Trajectory()
    {
        _trajectoryBehaviour.Trajectory();
    }
    
    public override void ProjHit(GameObject go)
    {
        _projHitBehaviour.ProjHit(_transform, go, damage);
    }
}
