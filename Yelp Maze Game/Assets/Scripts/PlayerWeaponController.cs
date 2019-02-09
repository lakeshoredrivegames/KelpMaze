using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

	public GameObject swordArm;
	public GameObject EquippedWeapon { get; set; }

	IWeapon equippedWeapon;
	
	CharacterStats characterStats;
	void Start()
	{
		characterStats = GetComponent<CharacterStats>();
	}

	public void EquipWeapon(Item itemToEquip)
	{
		if (EquippedWeapon != null)
		{
			characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
			Destroy(swordArm.transform.GetChild(0).gameObject);
		}

		EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), 
			swordArm.transform.position, swordArm.transform.rotation);
		equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
		equippedWeapon.Stats = itemToEquip.Stats;
		EquippedWeapon.transform.SetParent(swordArm.transform);
		characterStats.AddStatBonus(itemToEquip.Stats);
		Debug.Log(equippedWeapon.Stats[0]);
	}
	
	public void PerformWeaponAttack()
	{
		equippedWeapon.PerformAttack();
	}
}
