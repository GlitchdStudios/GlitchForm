using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour
{
	private DroneTrigger trigger;
	
	private Vector3 targetPos;
	
	private float height;
	private float deviation;
	private int range;
	
	public int health;
	public int damage;
	public float speed;
	
	void Awake()
	{
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
		TargetPlayer();
		
		if(EnemyManager.Instance.target != null)
		{
			MoveDrone(transform.position, targetPos, speed * Time.deltaTime);
		}
		
		trigger.SetTriggerHeight(transform.position.y);
		
		
		Debug.Log (gameObject.name + ": " + targetPos.z);
	}
	
	public void MoveDrone (Vector3 start, Vector3 target, float maxDistDelta) 
	{
       transform.position = Vector3.MoveTowards(start, target, maxDistDelta);
    }
	
	public void TargetPlayer()
	{
		targetPos = new Vector3(EnemyManager.Instance.target.transform.position.x, height, EnemyManager.Instance.target.transform.position.z);
		transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, height, height),transform.position.z);
	}
	
	public int Angle { get {return range; } set { range = value; } }
}


