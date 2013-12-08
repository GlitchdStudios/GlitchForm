using UnityEngine;
using System.Collections;

public class ScreenBounds : MonoBehaviour
{
	public WorldtoScreen worldtoScreen;
	
	public float top;
	public float bottom;
	public float left;
	public float right;
		
	public Mesh mesh;
	
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
	}

	public virtual void Boundary()
	{
		transform.position = new Vector3( 	Mathf.Clamp(transform.position.x, left, right),
		                                 	Mathf.Clamp(transform.position.y, bottom, top),
								  			transform.position.z);									 
	}
	
	public virtual void SetBounds()
	{
		top = worldtoScreen.top - renderer.bounds.extents.y;
		bottom = worldtoScreen.bottom + renderer.bounds.extents.y;
		left = worldtoScreen.left + renderer.bounds.extents.x;
		right = worldtoScreen.right - renderer.bounds.extents.x;
	}
}

