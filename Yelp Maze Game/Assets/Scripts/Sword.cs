using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sword : MonoBehaviour, iWeapon
{
    public List<BaseStat> Stats { get; set; }

    public void PerformAttack()
    {
        Debug.Log("Sword attack!");
    }
}
