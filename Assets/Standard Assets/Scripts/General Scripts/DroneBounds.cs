using UnityEngine;
using System.Collections;

public class DroneBounds : ScreenBounds
{
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
		if(transform.position.y > top || transform.position.y < bottom || transform.position.x < left || transform.position.x > right)
		{
			StartCoroutine(droneScr.ResetSpeed());
		}
	}
	
	public override void SetBounds()
	{
		top = worldtoScreen.top + 2f;
		bottom = worldtoScreen.bottom - 2f;
		left = worldtoScreen.left - 2f;
		right = worldtoScreen.right + 2f;

		Debug.Log("Top: " + top);
		Debug.Log("Bottom: " + bottom);
		Debug.Log("Left: " + left);
		Debug.Log("Right: " + right);
	}
}

