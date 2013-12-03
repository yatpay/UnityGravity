using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour {

	public float thrust = 10.0f;
	public float rcs_thrust = 1.0f;

	// Update is called once per frame
	void FixedUpdate () {
		// gather input
		float rotate = Input.GetAxis("Horizontal") * -rcs_thrust;
		bool engine_on = Input.GetKey("space");
		bool reset = Input.GetKey("r");

		// handle thrust input
		float added_thrust = 0.0f;
		if (engine_on)
		{
			added_thrust = thrust;
		}

		Vector3 movement = new Vector3(0.0f, added_thrust, 0.0f);
		rigidbody.AddRelativeForce(movement * Time.deltaTime);

		// handle rotation input
		Vector3 rotateAngle = new Vector3(0.0f, 0.0f, rotate);
		Quaternion deltaRotation = Quaternion.Euler(rotateAngle * Time.deltaTime);
		rigidbody.MoveRotation(
			rigidbody.rotation * deltaRotation
		);

		if(reset)
		{
			transform.position = new Vector3(0.0f, 2.8f, 0.0f);
			rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
			Quaternion resetRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f) * Time.deltaTime);
			rigidbody.MoveRotation(resetRotation);
		}

	}
}
