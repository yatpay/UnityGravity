using UnityEngine;
using System.Collections.Generic;

public class Gravity : MonoBehaviour {
	
	public static float range = 6.0f;
	
	void FixedUpdate()
	{
		Collider[] cols = Physics.OverlapSphere(transform.position, range);
		List<Rigidbody> rbs = new List<Rigidbody>();
		
		foreach(Collider c in cols)
		{
			if (c.gameObject.tag == "planet")
			{
				continue;
			}
			Rigidbody rb = c.attachedRigidbody;
			if (rb != null && rb != rigidbody && !rbs.Contains(rb))
			{
				rbs.Add(rb);
				Vector3 offset = transform.position - c.transform.position;
				rb.AddForce( offset / offset.sqrMagnitude * rigidbody.mass);
			}
		}
	}
}
