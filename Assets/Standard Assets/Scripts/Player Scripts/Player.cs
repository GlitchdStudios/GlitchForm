using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public PlayerMovement playerMovement;
	public MachineGun machineGun;
	public int health;
	
	// Use this for initialization
	void Start ()
	{
		playerMovement = GetComponent<PlayerMovement>();
		machineGun = GetComponentInChildren<MachineGun>();
		health = 100;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		StateManager.Instance.playerState.CurPlayerState = StateManager.Instance.playerMoving;
		StateManager.Instance.playerState.ActivateState();
		CheckStatus();
	}
	
	private void CheckStatus()
	{
		if(health <= 0)
			Destroy(gameObject);
	}
}

