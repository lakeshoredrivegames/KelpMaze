﻿using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

	public List<BaseStat> stats = new List<BaseStat>();

	void Start()
	{
		stats.Add(new BaseStat(4, "Power", "Your power level."));
	}

	public void AddStatBonus (List<BaseStat> statBonuses)
	{
		foreach(BaseStat statBonus in statBonuses)
		{
			stats.Find(x=> x.StatName == statBonus.StatName).AddStatBonus(new StatBonus(statBonus.BaseValue));
		} 

	}
	public void RemoveStatBonus (List<BaseStat> statBonuses)
	{
		foreach(BaseStat statBonus in statBonuses)
		{
			stats.Find(x=> x.StatName == statBonus.StatName).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
		} 

	}
}
