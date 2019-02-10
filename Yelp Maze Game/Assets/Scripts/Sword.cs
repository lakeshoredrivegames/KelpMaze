using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sword : MonoBehaviour, IWeapon
{
    private Animator animator;
    public List<BaseStat> Stats { get; set; }

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void PerformAttack()
    {
        animator.SetTrigger("BaseAttack");
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Breakable");
        {
            col.GetComponent<IBreakable>().TakeDamage(Stats[0].GetCalculatedStatValue());
        }
    }

}
