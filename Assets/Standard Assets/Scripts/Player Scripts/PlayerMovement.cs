using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	private float playerSpeed;
	
	void Start()
	{
		playerSpeed  = 3f;
	}
	
	public void Movement()
	{
		Screen.showCursor = false;
		Screen.lockCursor = true;
		
		float xPos = Input.GetAxis("Mouse X") * playerSpeed;
		float yPos = Input.GetAxis("Mouse Y") * playerSpeed;
		
        xPos *= Time.deltaTime;
		yPos *= Time.deltaTime;
		
        transform.Translate(xPos,yPos, 0);
	}
}

