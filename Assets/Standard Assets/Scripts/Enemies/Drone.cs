using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour
{
	private EnemyManager manager;
	private int health;
	public int damage;
	private float speed;
	
	void Awake()
	{
		manager = GameObject.Find("SpawnPoint").GetComponent<EnemyManager>();
		damage = 1;
	}
	
	// Use this for initialization
	void Start ()
	{
		health = 20;
		speed = 5f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(manager.target != null)
			transform.position = Vector3.MoveTowards(transform.position, manager.target.transform.position, speed * Time.deltaTime);
	}
}

