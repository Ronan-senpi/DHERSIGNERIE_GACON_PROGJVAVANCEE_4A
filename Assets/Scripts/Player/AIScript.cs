using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : PlayerDeplacementScript
{
    [SerializeField]
    private float cooldown;
    [SerializeField]
    DropBombScript dropBomb;

    bool canAttack = false;
    int? rdm;
    int lastRdm = 0;
    private bool canReset = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cooldown(1.5f));

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
}
