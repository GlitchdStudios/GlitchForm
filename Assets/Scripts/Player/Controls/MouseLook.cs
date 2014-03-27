using UnityEngine;


[AddComponentMenu ("Camera-Control/Mouse Look")]

public class MouseLook: MonoBehaviour
{
	enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	RotationAxes axes = RotationAxes.MouseXAndY;
	float sensitivityX = 15;
	float sensitivityY = 15;
	
	float minimumX = -360;
	float maximumX = 360;
	
	float minimumY = -60;
	float maximumY = 60;
	
	float rotationX = 0;
	float rotationY = 0;

	Quaternion xQuaternion;
	Quaternion yQuaternion;

	private Quaternion originalRotation;
	
	void Update () 
	{
		if (axes == RotationAxes.MouseXAndY) 
		{
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			
			rotationX = ClampAngle (rotationX, minimumX, maximumX);
			rotationY = ClampAngle (rotationY, minimumY, maximumY);
			
			xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
			yQuaternion = Quaternion.AngleAxis (rotationY, Vector3.left);
			
			transform.localRotation = originalRotation * xQuaternion * yQuaternion;
		}
		else if (axes == RotationAxes.MouseX) 
		{
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
			rotationX = ClampAngle (rotationX, minimumX, maximumX);
			
			xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
			transform.localRotation = originalRotation * xQuaternion;
		}
		else 
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = ClampAngle (rotationY, minimumY, maximumY);
			
			yQuaternion = Quaternion.AngleAxis (rotationY, Vector3.left);
			transform.localRotation = originalRotation * yQuaternion;
		}
	}
	
	void Start () 
	{
		if (rigidbody)
			rigidbody.freezeRotation = true;
		originalRotation = transform.localRotation;
	}
	
	public static float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360.0f)
			angle += 360.0f;
		if (angle > 360.0f)
			angle -= 360.0f;
		return Mathf.Clamp (angle, min, max);
	}
	
}