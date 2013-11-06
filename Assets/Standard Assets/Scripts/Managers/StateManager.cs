using UnityEngine;
using System.Collections;

public class StateManager : Singleton<StateManager>
{
	public GameObject stateDummy;
	public GameObject player;
	
	//Base State Classes
	public PlayerState playerState;
	public EnemyState enemyState;
	
	//States - Player
	public PlayerMoving playerMoving;
	
	//States - Bullet
	public ChainActive chainActive;
	
	//States - Drone
	public Orbiting orbiting;
	public Chained chained;
	public Unchained unchained;
	
	public AbstractState absState;
	
	void Start()
	{
		//Base State Classes
		playerState = player.GetComponent<PlayerState>();
		
		//States - Player
		playerMoving = stateDummy.GetComponentInChildren<PlayerMoving>();
		
		//States - Bullet
		chainActive = stateDummy.GetComponentInChildren<ChainActive>();
		
		//States - Drone
		orbiting = stateDummy.GetComponentInChildren<Orbiting>();
		chained = stateDummy.GetComponentInChildren<Chained>();
		unchained = stateDummy.GetComponentInChildren<Unchained>();
	}
}

