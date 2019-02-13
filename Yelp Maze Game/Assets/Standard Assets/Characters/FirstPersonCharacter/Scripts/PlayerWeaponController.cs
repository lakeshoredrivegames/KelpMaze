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
			Destroy(EquippedWeapon.gameObject);
		}

		EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug));
		equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
		equippedWeapon.Stats = itemToEquip.Stats;
		EquippedWeapon.transform.SetParent(swordArm.transform, false);
		characterStats.AddStatBonus(itemToEquip.Stats);
		Debug.Log(itemToEquip.Stats);
	}
	
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
			PerformWeaponAttack();
	}
	public void PerformWeaponAttack()
	{
		equippedWeapon.PerformAttack();
	}
}
