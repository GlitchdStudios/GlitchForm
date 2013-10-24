using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour
{
	private DroneTrigger droneTrigger;
	private PlayerTrigger playerTrigger;
	private Vector3 targetDir;
	private int range;
	private float deviationX;
	private float deviationZ;
	
	public float height;
	public int health;
	public int damage;
	public float speed;
	public bool fleetUp;
	public bool damagePlayer;
	public bool m_targetPlayer; 
	public Vector3 targetPos;
	
	
	void Awake()
	{
		droneTrigger = gameObject.GetComponentInChildren<DroneTrigger>();	
		
		if(EnemyManager.Instance.target != null) 
			playerTrigger = EnemyManager.Instance.target.GetComponentInChildren<PlayerTrigger>();
	}
	
	// Use this for initialization
	void Start ()
	{
		health = 20;
		damage = 1;
		speed = 5f;
		m_targetPlayer = true;
		
		Angle = Random.Range(-20,20);
		
		if(EnemyManager.Instance.target != null) 
			deviationX = Random.Range(-(playerTrigger.collider as SphereCollider).radius, (playerTrigger.collider as SphereCollider).radius);
			deviationZ = Random.Range(-(playerTrigger.collider as SphereCollider).radius, (playerTrigger.collider as SphereCollider).radius);
	}
	
	// Update is called once per frame
	void Update ()
	{			
		TargetPlayer();
		
		if(EnemyManager.Instance.target != null)
		{
			MoveDrone(transform.position, targetPos, speed * Time.deltaTime);
		}
		
		droneTrigger.SetTriggerHeight(transform.position.y);
		
		CheckDroneStatus();
		
		//Debug.Log("Height " + height);
	}
	
	public void MoveDrone (Vector3 start, Vector3 target, float maxDistDelta) 
	{	
		transform.position = Vector3.MoveTowards(start, target, maxDistDelta);	
    }
	
	public void TargetBullet(float x, float z, bool targetPlayer)
	{
		m_targetPlayer = targetPlayer;
		
		if(EnemyManager.Instance.target != null)
		{	
			if(!m_targetPlayer)
			{
				targetPos = new Vector3(x, height, z);
				transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,height, height),transform.position.z);
			}
		}
		
	}
	
	public void TargetPlayer()
	{
		if(EnemyManager.Instance.target != null)
		{
			if(m_targetPlayer)
			{
				targetPos = new Vector3(EnemyManager.Instance.target.transform.position.x + deviationX, height, EnemyManager.Instance.target.transform.position.z + deviationZ);
				transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,height, height),transform.position.z);
			}
		}
		
	}
	
	private void CheckDroneStatus()
	{
		if(health <= 0)
			Destroy(gameObject);
	}
	public int Angle { get {return range; } set { range = value; } }
}


