using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour
{
	private EnemyManager manager;
	private DroneTrigger trigger;
	
	private Vector3 targetPos;
	private Vector3 randomTarget;  //Around the player
	
	private float height;
	private int range;
	
	public int health;
	public int damage;
	public float speed;
	
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
		Angle = Random.Range(-20,20);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		rigidbody.velocity = Vector3.zero;
		
		targetPos = new Vector3(manager.target.transform.position.x, height, manager.target.transform.position.z);
		transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, height, height),transform.position.z);
			
		if(manager.target != null)
		{
			MoveDrone(transform.position, targetPos, speed * Time.deltaTime);
		}
					//transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
		
		trigger.SetTriggerHeight(transform.position.y);
	}
	
	public void MoveDrone (Vector3 start, Vector3 target, float maxDistDelta) 
	{
       transform.position = Vector3.MoveTowards(start, target, maxDistDelta);
    }
	
	public int Angle { get {return range; } set { range = value; } }
}


