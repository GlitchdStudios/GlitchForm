using UnityEngine;
using System.Collections;

public class StateManager : Singleton<StateManager>
{
	public GameObject stateDummy;
	public GameObject player;
	public GameObject drone;
	
	//Entity Classes
	public Player playerScr; 
	
	public Damaged damaged;
	
	void Start()
	{
		//Entity Classes
		playerScr = player.GetComponent<Player>();	
		
		damaged = stateDummy.GetComponent<Damaged>();
	}
}

