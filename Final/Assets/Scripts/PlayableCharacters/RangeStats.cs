using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeStats : Stats
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(2);
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            LevelUp();
        }
        
        
    }


    public override void Die()
    {
        base.Die();

        gameObject.SetActive(false);
    }
}
