using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	private enum Layers {Player = 8, Bullet, Drone, DroneCol, DroneTrigger, PlayerCol, PlayerTrigger };
	
	void Awake()
	{
		//Physics.IgnoreLayerCollision((int)Layers.Player, (int)Layers.Bullet);
	}
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

