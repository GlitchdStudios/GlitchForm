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
		speed = 5f;
		damage = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(manager.target != null)
			transform.position = Vector3.MoveTowards(transform.position, manager.target.collider.bounds.center, speed * Time.deltaTime);
	}
	
	public void OnTriggerEnter(Collider col)
	{
		CollisionManager.BulletTriggerEnter(col, gameObject);
	}
}


