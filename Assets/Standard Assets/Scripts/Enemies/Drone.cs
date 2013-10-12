using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour
{
	private DroneTrigger droneTrigger;
	private DroneCol droneCol;
	
	private Vector3 targetPos;
	private Vector3 targetDir;
	
	private float height;
	private float deviation;
	private int range;
	
	public int health;
	public int damage;
	public float speed;
	
	void Awake()
	{
		droneTrigger = gameObject.GetComponentInChildren<DroneTrigger>();	
		droneCol = gameObject.GetComponentInChildren<DroneCol>();
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
		TargetPlayer();
		
		//rigidbody.velocity = Vector3.zero;
		
		if(EnemyManager.Instance.target != null)
		{
			MoveDrone(transform.position, targetPos, speed * Time.deltaTime);
		}
		
		droneTrigger.SetTriggerHeight(transform.position.y);
		droneCol.SetTriggerHeight(transform.position.y);
		
	}
	
	public void MoveDrone (Vector3 start, Vector3 target, float maxDistDelta) 
	{
		transform.LookAt(target);
		
		transform.position = Vector3.MoveTowards(start, target, maxDistDelta);
    }
	
	public void TargetPlayer()
	{
		targetPos = new Vector3(EnemyManager.Instance.target.transform.position.x, height, EnemyManager.Instance.target.transform.position.z);
		transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, height, height),transform.position.z);
	}
	
	public int Angle { get {return range; } set { range = value; } }
}


