using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : PlayerDeplacementScript
{
    [SerializeField]
    private float attackCooldown;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    DropBombScript dropBomb;

    bool canAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cooldown(1.5f));

    }

    // Update is called once per frame
    protected override void Update()
    {
        if (!canAttack)
            return;

        Vector3 direction = Vector3.zero;
        switch (Random.Range(1, 7))
        {
            case 1:
                if (dropBomb.CanDropSecondaryBomb())
                {
                    dropBomb.DropSecondaryBomb();
                }
                break;
            case 2:
                if (dropBomb.CanDropMainBomb())
                {
                    dropBomb.DropMainBomb();
                }
                break;
            case 3:
                direction.z++;
                break;
            case 4:
                direction.z--;
                break;
            case 5:
                direction.x--;
                break;
            case 6:
                direction.x++;
                break;
            default:
                break;
        }

        if (!stunned)
            gameObject.transform.position += direction * Time.deltaTime * Speed;

        //agent.SetDestination(target.transform.position);

        //if (agent.remainingDistance != Mathf.Infinity && agent.remainingDistance <= agent.stoppingDistance && canAttack)
        //{
        //    canAttack = false;
        //    if (dropBomb.CanDropSecondaryBomb() && Random.Range(0, 2) == 1)
        //    {
        //        dropBomb.DropSecondaryBomb();
        //    }
        //    else
        //    {
        //        dropBomb.DropMainBomb();
        //    }
        //    StartCoroutine(Cooldown(attackCooldown));
        //}
    }
    IEnumerator Cooldown(float attackCooldown)
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    protected override IEnumerator Stun(float StunDuration)
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(StunDuration);
        agent.isStopped = false;
    }
}
