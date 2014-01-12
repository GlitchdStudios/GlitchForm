using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	private float playerSpeed;
	private Transform thisTransform;

	void Start()
	{
		playerSpeed  = 3f;
		thisTransform = transform;
	}
	
	public void Movement()
	{
		Screen.showCursor = false;
		Screen.lockCursor = true;
		
		float xPos = Input.GetAxis("Mouse X") * playerSpeed;
		float yPos = Input.GetAxis("Mouse Y") * playerSpeed;
		
        xPos *= Time.deltaTime;
		yPos *= Time.deltaTime;
		
        thisTransform.Translate(xPos,yPos, 0);
	}
}

