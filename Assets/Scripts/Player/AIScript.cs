using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : PlayerDeplacementScript
{
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    DropBombScript dropBomb;

    bool canAttack = false;
    int? rdm;
    int lastRdm = 0;
    private bool canReset = true;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("IA", 0) == 0)
            Destroy(gameObject);
        StartCoroutine(Cooldown(1.5f));

    }

    // Update is called once per frame
    protected override void Update()
    {
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

    private void FixedUpdate()
    {
        if (!canAttack)
            return;

        Vector3 direction = Vector3.zero;
        if (rdm == null)
        {
            do
            {
                rdm = Random.Range(1, 7);
            } while (rdm == lastRdm);
            
        }
        switch (rdm)
        {
            case 1:
                if (dropBomb.CanDropSecondaryBomb() && dropBomb.IsEmptyLocation())
                {
                    dropBomb.DropSecondaryBomb();
                }
                StartResetRdm(0.2f);
                break;
            case 2:
                if (dropBomb.CanDropMainBomb() && dropBomb.IsEmptyLocation())
                {
                    dropBomb.DropMainBomb();
                }
                StartResetRdm(0.2f);
                break;
            case 3:
                direction.z++;
                StartResetRdm(cooldown);
                break;
            case 4:
                direction.z--;
                StartResetRdm(cooldown);
                break;
            case 5:
                direction.x--;
                StartResetRdm(cooldown);
                break;
            case 6:
                direction.x++;
                StartResetRdm(cooldown);

                break;
            default:
                break;
        }
        lastRdm = rdm.HasValue ? rdm.Value : 0;
        if (!stunned)
            gameObject.transform.position += direction * Time.deltaTime * Speed;

    }

    void StartResetRdm(float cool)
    {
        if (canReset)
        {
            canReset = false;
            StartCoroutine(resetRdm(cool));
        }
    }
    IEnumerator resetRdm(float cool)
    {
        yield return new WaitForSeconds(cool);
        canReset = true;
        rdm = null;
    }
    IEnumerator Cooldown(float attackCooldown)
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    IEnumerator Stun(float StunDuration)
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(StunDuration);
        agent.isStopped = false;
    }
}
