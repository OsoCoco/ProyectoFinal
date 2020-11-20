using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    [SerializeField] float range;

    [SerializeField] LayerMask mask;
    [SerializeField] Rigidbody projectile;

    float interval = 0f;
    [SerializeField] float attackSpeed;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Update()
    {
        Attack();
    }
    
    void Attack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range, mask);   

        if(hitColliders.Length !=  0 )
        {
            
            if(attackSpeed <= interval)
            {
                Rigidbody instance = Instantiate(projectile, transform.position, Quaternion.identity);
                instance.AddForce(Vector3.up * 100);
                interval = 0;
            }

            interval += Time.deltaTime;
        }
    }
}
