using UnityEngine;
using System.Collections;

public class DroneBounds : ScreenBounds
{
	private WorldtoScreen worldtoScreen;
	
	private float top;
	private float bottom;
	private float left;
	private float right;
	private Drone droneScr;
	
	void Awake()
	{
		worldtoScreen = Camera.main.GetComponent<WorldtoScreen>();
	}
	
	// Use this for initialization
	void Start ()
	{
		droneScr = GetComponent<Drone>();
		SetBounds();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Boundary();
	}
	
	public override void Boundary()
	{
		if(transform.position.x > top || transform.position.x < bottom || transform.position.z > left || transform.position.z < right)
		{
			StartCoroutine(droneScr.ResetSpeed());
		}
	}
	
	public override void SetBounds()
	{
		top = worldtoScreen.top;
		bottom = worldtoScreen.bottom;
		left = worldtoScreen.left;
		right = worldtoScreen.right;
	}
}

