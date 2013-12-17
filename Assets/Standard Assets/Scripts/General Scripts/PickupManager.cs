using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum AbilityTypes { Chain = 0 };

public class PickupManager : Singleton<PickupManager>
{
	public Chain chainScr;
	public GameObject chainObj;
	public List<Ability> abilityCollection = new List<Ability>();
	
	void Start()
	{
		AddAbilitiestoList();
	}
	
	public void AddAbilitiestoList()
	{
		chainScr = chainObj.GetComponent<Chain>();
		
		abilityCollection.Add(chainScr);
	}
}

