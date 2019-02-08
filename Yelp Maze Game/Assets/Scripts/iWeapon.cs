using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iWeapon {
	List<BaseStat> Stats { get; set; }
	void PerformAttack();
}
