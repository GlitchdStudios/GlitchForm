using UnityEngine;
using System.Collections;

public class ScreenBounds : MonoBehaviour
{
	private WorldtoScreen worldtoScreen;
	
	private float top;
	private float bottom;
	private float left;
	private float right;
		
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
		transform.position = new Vector3( 	Mathf.Clamp(transform.position.x, bottom, top),
									  		transform.position.y,
									  		Mathf.Clamp(transform.position.z, right, left));									 
	}
	
	public virtual void SetBounds()
	{
		top = worldtoScreen.top - mesh.bounds.extents.x;
		bottom = worldtoScreen.bottom + mesh.bounds.extents.x;
		left = worldtoScreen.left - mesh.bounds.extents.z;
		right = worldtoScreen.right + mesh.bounds.extents.z;
	}
}

