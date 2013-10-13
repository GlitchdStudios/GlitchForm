using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour
{
	private DroneTrigger droneTrigger;
	private DroneCol droneCol;
	private PlayerTrigger playerTrigger;
	private Vector3 targetPos;
	private Vector3 targetDir;
	private int range;
	
	public float height;
	public int health;
	public int damage;
	public float speed;
	public bool fleetUp;
	private float deviationX;
	private float deviationZ;
	
	void Awake()
	{
		droneTrigger = gameObject.GetComponentInChildren<DroneTrigger>();	
		droneCol = gameObject.GetComponentInChildren<DroneCol>();
		playerTrigger = EnemyManager.Instance.target.GetComponentInChildren<PlayerTrigger>();
	}
	
	// Use this for initialization
	void Start ()
	{
		health = 20;
		damage = 1;
		speed = 5f;
		
		Angle = Random.Range(-20,20);
		
		deviationX = Random.Range(-(playerTrigger.collider as SphereCollider).radius, (playerTrigger.collider as SphereCollider).radius);
		deviationZ = Random.Range(-(playerTrigger.collider as SphereCollider).radius, (playerTrigger.collider as SphereCollider).radius);
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
		
//		Debug.Log("DeviationX " + deviationX);
//		
//		Debug.Log("DeviationZ " + deviationZ);
		
		Debug.Log("Height " + height);
		
	}
	
	public void MoveDrone (Vector3 start, Vector3 target, float maxDistDelta) 
	{
		transform.LookAt(target);
		
		//transform.Translate(transform.forward * maxDistDelta);
		
		transform.position = Vector3.MoveTowards(start, target, maxDistDelta);
    }
	
	public void TargetPlayer()
	{	
		targetPos = new Vector3(EnemyManager.Instance.target.transform.position.x + deviationX, height, EnemyManager.Instance.target.transform.position.z + deviationZ);
		transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,height, height),transform.position.z);
	}
	
	public int Angle { get {return range; } set { range = value; } }
}


