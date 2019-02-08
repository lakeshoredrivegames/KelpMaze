using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigStat 
{													 // Class that every stat is based on.
	public List<StatBonus> BaseAdditives { get; set; }
	public int BaseValue { get; set; }					// Initial value of stats.
	public string StatName { get; set; }					// Name of the stat.
	public string StatDescription {get; set;}			// Description of stat.
	public int FinalValue { get; set; }					// Final value after buffs and debuffs have been added.

	public OrigStat(int baseValue, string statName, string statDescription)
	{
		this.BaseAdditives = new List<StatBonus>();
		this.BaseValue = baseValue;
		this.StatName = statName;
		this.StatDescription = statDescription;
	}

	public void AddStatBonus(StatBonus statBonus)
	{
		this.BaseAdditives.Add(statBonus);
	}

	public void RemoveStatBonus(StatBonus statBonus)
	{
		this.BaseAdditives.Remove(BaseAdditives.Find(x=> x.BonusValue == statBonus.BonusValue));
	}

	public int GetCalculatedStatValue()
	{
		this.FinalValue = 0;
		this.BaseAdditives.ForEach(x => this.FinalValue += x.BonusValue);
		FinalValue += BaseValue;
		return FinalValue;
	}

 
}
