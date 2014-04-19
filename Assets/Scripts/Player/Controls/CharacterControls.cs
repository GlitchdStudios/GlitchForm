using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]

public class CharacterControls : MonoBehaviour 
{
	
	public Transform LookTransform;
	public Vector3 Gravity = Vector3.down * Toolbox.generalGravityForce;
	public float RotationRate = 0.1f;
	public float Velocity = 8;
	public float GroundControl = 1.0f;
	public float AirControl = 0.2f;
	public float JumpVelocity = 5;
	public float GroundHeight = 1.1f;
	private bool jump;
	
	void Start() { 
		rigidbody.freezeRotation = true;
		rigidbody.useGravity = false;
	}
	
	void Update() {
		jump = jump || Input.GetButtonDown("Jump");
	}
	
	void FixedUpdate() {
		// Cast a ray towards the ground to see if the Walker is grounded
		bool grounded = Physics.Raycast(transform.position, Gravity.normalized, GroundHeight);
		
		// Rotate the body to stay upright
		Vector3 gravityForward = Vector3.Cross(Gravity, transform.right);

		if(gravityForward == Vector3.zero)
		{
			gravityForward = Gravity;
		}
		Quaternion targetRotation = Quaternion.LookRotation(gravityForward, -Gravity);
		rigidbody.rotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, RotationRate);

		// Add velocity change for movement on the local horizontal plane
		Vector3 forward = Vector3.Cross(transform.up, -LookTransform.right).normalized;
		Vector3 right = Vector3.Cross(transform.up, LookTransform.forward).normalized;
		Vector3 targetVelocity = (forward * Input.GetAxis("Vertical") + right * Input.GetAxis("Horizontal")) * Velocity;
		Vector3 localVelocity = transform.InverseTransformDirection(rigidbody.velocity);
		Vector3 velocityChange = transform.InverseTransformDirection(targetVelocity) - localVelocity;

		// The velocity change is clamped to the control velocity
		// The vertical component is either removed or set to result in the absolute jump velocity
		velocityChange = Vector3.ClampMagnitude(velocityChange, grounded ? GroundControl : AirControl);
		velocityChange.y = jump && grounded ? -localVelocity.y + JumpVelocity : 0;
		velocityChange = transform.TransformDirection(velocityChange);
		rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
		
		// Add gravity
		rigidbody.AddForce(Gravity * rigidbody.mass);
		
		jump = false;
	}
	
}