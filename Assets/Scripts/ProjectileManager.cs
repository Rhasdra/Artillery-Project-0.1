using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform spawner;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private wpnSO wpnSO;

    [SerializeField] private CharacterPowerScript power;   

    [SerializeField] private GameObject explosion;

    
    RaycastHit2D raycastHit;
    public float hitAngle;
    public Vector3 hitPosition;
    public float damage;
    
    private void Awake() 
    {
        power = FindObjectOfType<CharacterPowerScript>();
        rigidBody.mass = wpnSO.weight;
        
        GetImpulse();
    }

    private void FixedUpdate() 
    {
        RotateWithParabola();
        Raycast();
    }


  void GetImpulse()
    {
        rigidBody.AddForce(transform.right * wpnSO.impulse * (power.currentPower/100f));        
    }

    void RotateWithParabola()
    {
        float projectileAngle;

        //Glitches if updates on the first frame where the velocity is 0??
        if (rigidBody.velocity.y != 0f)
        {
        projectileAngle = Mathf.Atan2(rigidBody.velocity.y , rigidBody.velocity.x) * Mathf.Rad2Deg;

        transform.localRotation = Quaternion.AngleAxis(projectileAngle,transform.forward);
        }
    }    

    void Raycast()
    {
        raycastHit = Physics2D.Raycast (rigidBody.position, transform.right, 1f, LayerMask.GetMask("Characters"));

        Debug.DrawRay(rigidBody.position, transform.right, Color.red);

        //Returns hitAngle=0 on 90degrees full hit
        if(raycastHit)
        {    
        hitAngle = Vector2.Angle(raycastHit.normal, -transform.right);
        hitPosition = raycastHit.point;
        damage = wpnSO.damage * Mathf.Lerp(1f, 0f, hitAngle/90f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        int windLayer = LayerMask.NameToLayer("Wind");
        int characterLayer = LayerMask.NameToLayer("Characters");
        int terrainLayer = LayerMask.NameToLayer("Terrain");
        
        if(other.gameObject.layer != windLayer) 
        {
            if(other.gameObject.layer == characterLayer)
            {
                other.GetComponentInChildren<CharacterHealthScript>().TakeDamage(damage);
            }
           
            Instantiate(explosion, spawner.transform.position, transform.rotation);
            
            Object.Destroy(this.gameObject);
        }
    }

}
