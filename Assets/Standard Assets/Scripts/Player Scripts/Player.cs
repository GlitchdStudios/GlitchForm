using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public PlayerMovement playerMovement;
	public MachineGun machineGun;
	public PlayerState playerState;
	public int health;
	
	// Use this for initialization
	void Start ()
	{
		playerMovement = GetComponent<PlayerMovement>();
		machineGun = GetComponentInChildren<MachineGun>();
		playerState = new PlayerState();
		health = 100;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		playerMovement.Movement();
		CheckStatus();
	}
	
	private void CheckStatus()
	{
		if(health <= 0)
			Destroy(gameObject);
	}
}

