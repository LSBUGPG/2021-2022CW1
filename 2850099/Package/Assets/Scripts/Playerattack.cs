using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerattack : MonoBehaviour
{
    private float Cooldown;
    public float StartCooldown;
    public LayerMask whatisEnemies;
    public Transform attackPos;
    public float attackRange;
    public int damage; 
    private void Update()
    {
        if (Cooldown<=0)
            //then you'd be allowed to attack because the cooldown is at 0 
        {
            StartCooldown = Cooldown;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Collider2D[] enemiestoDamage = Physics2D.OverlapCircleAll(attackPos.position,attackRange,whatisEnemies);
            for (int i = 0; i < enemiestoDamage.Length; i++)
            {
                enemiestoDamage[i].GetComponent<Enemy>().TakeDamage(damage); 
            }
        }
        else
        {
            Cooldown -= Time.deltaTime; 
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);

    }
}
