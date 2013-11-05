using UnityEngine;
using System.Collections;

public class StateManager : Singleton<StateManager>
{
	public GameObject stateDummy;
	
	public Orbiting orbiting;
	public ChainActive chainActive;
	
	public AbstractState absState;
	
	void Start()
	{
		orbiting = stateDummy.GetComponentInChildren<Orbiting>();
		chainActive = stateDummy.GetComponentInChildren<ChainActive>();
	}
}

