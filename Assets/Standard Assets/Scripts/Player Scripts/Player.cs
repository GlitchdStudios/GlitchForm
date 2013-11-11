using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public MachineGun machineGun;
	public int health;
	
	//States
	public PlayerState playerState;
	
	// Use this for initialization
	void Start ()
	{
		machineGun = GetComponentInChildren<MachineGun>();
		playerState = GetComponent<PlayerState>();
		health = 100;
		
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
		if(health <= 0)
			Destroy(gameObject);
	}
}

