using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatClass : MonoBehaviour {

	public List<OrigStat> stats = new List<OrigStat>();

	void Start()
	{
		stats.Add(new OrigStat(4, "Power", "Your power level."));
		stats[0].AddStatBonus(new StatBonus(5));
		Debug.Log(stats[0].GetCalculatedStatValue());
	}
}
