using UnityEngine;
using System.Collections;

public class Ability : MonoBehaviour
{
	protected Player playerScr;
	
	public GameObject player;
	
	void Start() 
	{
		playerScr = player.GetComponent<Player>();
	}
	
	//public Ability ObtainedAbility(Ability abilityPickup) { return abilityPickup; } //Use this function to pass the obtained ability from the ability pickup
}

