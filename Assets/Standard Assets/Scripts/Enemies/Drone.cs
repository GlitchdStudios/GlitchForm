using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour
{
	private EnemyManager manager;
	public int health;
	public int damage;
	public float speed;
	
	void Awake()
	{
		manager = GameObject.Find("SpawnPoint").GetComponent<EnemyManager>();
	}
	
	// Use this for initialization
	void Start ()
	{
		health = 20;
		damage = 1;
		speed = 5f;
		
		CollisionManager.Range = Random.Range(-20,20);
	}
	
	// Update is called once per frame
	void Update ()
	{
		rigidbody.velocity = Vector3.zero;
		
		if(manager.target != null)
			transform.position = Vector3.MoveTowards(transform.position, manager.target.transform.position, speed * Time.deltaTime);
	}
}


