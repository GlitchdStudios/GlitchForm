using UnityEngine;
using System.Collections;

public class PlayerBounds : MonoBehaviour
{
	private WorldtoScreen worldtoScreen;
	
	private float top;
	private float bottom;
	private float left;
	private float right;
		
	void Awake()
	{
		worldtoScreen = Camera.main.GetComponent<WorldtoScreen>();
	}
	
	// Use this for initialization
	void Start ()
	{
		SetBounds();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Boundary();
		
		Debug.Log("Top: " + top);
		Debug.Log("Bottom: " + bottom);
		Debug.Log("Left: " + left);
		Debug.Log("Right: " + right);
	}
	
	public void Boundary()
	{
		transform.position = new Vector3( 	Mathf.Clamp(transform.position.x, bottom, top),
									  		transform.position.y,
									  		Mathf.Clamp(transform.position.z, right, left));									 
	}
	
	public void SetBounds()
	{
		top = worldtoScreen.top - collider.bounds.extents.x;
		bottom = worldtoScreen.bottom + collider.bounds.extents.x;
		left = worldtoScreen.left - collider.bounds.extents.z;
		right = worldtoScreen.right + collider.bounds.extents.z;
	}
}

