using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Building
{

    public int id;
    // Getting the model for later actions

    void OnEnable()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    


    public int GetId()
    {
        return id;
    }

    public override void TargetStart()
    {
        attackPoint = transform.Find("AttackPoint").transform;
        model.AddTarget(this);
        Killed += model.OnKilled;
    }
}
