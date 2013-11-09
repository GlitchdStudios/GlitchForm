using UnityEngine;
using System.Collections;

public class StateManager : Singleton<StateManager>
{
	public GameObject stateDummy;
	public GameObject player;
	public GameObject drone;
	
	//Entity Classes
	public Player playerScr; 
	
	//Base State Classes
	public PlayerState playerState;

	//States - Bullet
	public ChainActive chainActive;
	
	public AbstractState absState;
	
	void Start()
	{
		//Entity Classes
		playerScr = player.GetComponent<Player>();
		
		//Base State Classes
		playerState = player.GetComponent<PlayerState>();
		
		//States - Bullet
		chainActive = stateDummy.GetComponentInChildren<ChainActive>();
	}
}

