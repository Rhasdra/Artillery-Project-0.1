using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField] private float radius = 2f;
    [SerializeField] private float baseDamage = 250f;

    private void Start() 
    {
        transform.localScale = new Vector3(radius*2f, radius*2f, radius*2f);
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
                //get distance to collider
                Vector2 closestPoint = other.ClosestPoint(transform.position);
                float distance = Vector2.Distance(closestPoint , transform.position);
                            
                //calculate damage based on distance
                float damage = baseDamage * (-(distance - radius) / radius);
                // print("Distance: " + distance + "Damage: " + (int)damage);

                //apply damage
                other.GetComponentInChildren<CharacterHealthScript>().TakeDamage((int)damage);
            }

            StartCoroutine("ExplosionCoroutine");
        }
    }

    IEnumerator ExplosionCoroutine()
    {
        yield return new WaitForSeconds(1f);

        Object.Destroy(this.gameObject);
    }
}
