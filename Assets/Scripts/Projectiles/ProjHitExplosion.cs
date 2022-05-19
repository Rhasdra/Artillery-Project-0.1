using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjHitExplosion : IProjHit
{
    Transform _transform;
    GameObject _go;
    GameObject _explosion;

    public ProjHitExplosion(GameObject explosion)
    {
        _explosion = explosion;
    }


    public void ProjHit(Transform hitPosition, GameObject goHit, float damage)
    {
        var damageable = goHit.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);

            // var explosion = Instantiate(_explosion, hitPosition.position, hitPosition.rotation);
            // explosion.GetComponent<ExplosionScript>().Explode(damageable.isCharacter());
        }

    }
}
