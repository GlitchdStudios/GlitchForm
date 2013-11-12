using UnityEngine;
using System.Collections;

public class Player : BaseEntity
{
	public MachineGun machineGun;
	
	//States
	public PlayerState playerState;
	
	// Use this for initialization
	void Start ()
	{
		machineGun = GetComponentInChildren<MachineGun>();
		playerState = GetComponent<PlayerState>();
		baseHealth = 100;
		
		playerState.CurPlayerState = playerState.playerMoving;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		playerState.ActivateState();
		
		CheckStatus();
	}
	
	private void CheckStatus()
	{
		if(baseHealth <= 0)
			Destroy(gameObject);
	}
}

