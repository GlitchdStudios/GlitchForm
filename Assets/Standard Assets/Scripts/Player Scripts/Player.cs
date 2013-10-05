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
}

