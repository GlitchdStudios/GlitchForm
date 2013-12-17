using UnityEngine;
using System.Collections;

public class StateManager : Singleton<StateManager>
{
	public GameObject stateDummy;
	public GameObject player;
	public GameObject drone;
	
	public Vector3 targetPos;

	public Player playerScr; 

	//Universal States
	public Damaged damaged;
	public Dead dead;
	
	void Start()
	{
		//Entity Classes
		playerScr = player.GetComponent<Player>();	
		
		damaged = stateDummy.GetComponent<Damaged>();
		dead = stateDummy.GetComponent<Dead>();
	}
}

