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
		
		float xPos = Input.GetAxis("Mouse Y") * playerSpeed;
		float zPos = Input.GetAxis("Mouse X") * -playerSpeed;
		
        xPos *= Time.deltaTime;
		zPos *= Time.deltaTime;
		
        transform.Translate(xPos,0,zPos);
	}
}

