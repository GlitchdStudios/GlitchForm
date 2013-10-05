using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	private float speed;
	
	void Start()
	{
		speed  = 3f;
	}
	
	public void Movement()
	{
		Screen.showCursor = false;
		Screen.lockCursor = true;
		
		float xPos = Input.GetAxis("Mouse Y") * speed;
		float zPos = Input.GetAxis("Mouse X") * -speed;
		
        xPos *= Time.deltaTime;
		zPos *= Time.deltaTime;
		
        transform.Translate(xPos,0,zPos);
	}
}

