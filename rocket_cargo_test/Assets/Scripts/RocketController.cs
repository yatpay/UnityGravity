using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour {

	public float thrust = 10.0f;
	public float rcs_thrust = 1.0f;

	// Update is called once per frame
	void FixedUpdate () {
		float rotate = Input.GetAxis("Horizontal") * -rcs_thrust;

		bool engine_on = Input.GetKey("space");

		bool reset = Input.GetKey("r");

		float added_thrust = 0.0f;
		if (engine_on)
		{
			added_thrust = thrust;
		}

		Vector3 movement = new Vector3(0.0f, added_thrust, 0.0f);
		rigidbody.AddRelativeForce (movement * Time.deltaTime);

		rigidbody.AddRelativeTorque(0.0f, 0.0f, rotate * Time.deltaTime);

		if(reset)
		{
			transform.position = new Vector3(0.0f, 2.8f, 0.0f);
			rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);

		}

	}
}
