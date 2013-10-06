using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour
{
	private EnemyManager manager;
	private DroneTrigger trigger;
	
	private float height;
	public int range;
	
	public int health;
	public int damage;
	public float speed;
	public Vector3 targetPos;
	
	void Awake()
	{
		manager = GameObject.Find("SpawnPoint").GetComponent<EnemyManager>();
		trigger = gameObject.GetComponentInChildren<DroneTrigger>();	
	}
	
	// Use this for initialization
	void Start ()
	{
		health = 20;
		damage = 1;
		speed = 5f;
		
		height = Random.Range(-2,2);
		Range = Random.Range(-20,20);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		rigidbody.velocity = Vector3.zero;
		targetPos = new Vector3(manager.target.transform.position.x, height, manager.target.transform.position.z);
		
		if(manager.target != null)
			transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
		
		trigger.SetTriggerHeight(transform.position.y);
	}
	
	public int Range { get {return range; } set { range = value; } }
}


