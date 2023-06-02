using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entity : Target
{
    NavMeshAgent agent;
    [SerializeField] public bool canAttackFloor;
    [SerializeField] public bool canAttackAir;
    [SerializeField] public bool canAttackEntities;

    [SerializeField] public bool isInvisble;

    // Damage per second
    [SerializeField]  int damageOnEntites;
    [SerializeField]  int damageOnBuildings;

    // Timing of damage
    [SerializeField] float intervall;

    [SerializeField] float attackRange;

    public void SetDestination(Vector3 destination)
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destination);
    }
    public void Attack(Target target)
    {
        if (Vector3.Distance(transform.position, target.transform.position) > attackRange) return;

        IEnumerator DoDamage()
        {
            if (target is Entity) target.TakeDamage(damageOnEntites);
            
            // Later:towers

            yield return new WaitForSeconds(intervall);

            if (Vector3.Distance(transform.position, target.transform.position)> attackRange) StopCoroutine(DoDamage());
        }

        StartCoroutine(DoDamage());
    }
    private void Update()
    {
    }
}
