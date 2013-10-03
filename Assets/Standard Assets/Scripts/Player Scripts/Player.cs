using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	private PlayerMovement playerMovement;
	public int health;
	
	void Awake()
	{
		playerMovement = GetComponent<PlayerMovement>();
	}
	
	// Use this for initialization
	void Start ()
	{
		health = 100;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		playerMovement.Movement();
	}
	
	public void OnTriggerEnter(Collider col)
	{
		CollisionManager.PlayerTriggerEnter(col, gameObject);
	}
	
	public void OnTriggerExit(Collider col)
	{
		CollisionManager.PlayerTriggerExit(col);
	}
}

