using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats : MonoBehaviour
{
    [SerializeField]
    int attackDamage;
    [SerializeField]
    int actualHealth;
    [SerializeField]
    int maxHealth;
    [SerializeField]
    float attackSpeed;
    [SerializeField]
     int armor;
    
    [SerializeField]
    int level;
    [SerializeField]
    int exp;

   


    private void Start()
    {
        actualHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        actualHealth -= damage;

        Debug.Log(gameObject.name + " has taken " + damage + " of damage");
        if(actualHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
         Debug.Log(gameObject.name + " died");
    }

    public virtual void LevelUp()
    {
        level++;
        Debug.Log(gameObject.name + " has leveled up ");
    }
}
