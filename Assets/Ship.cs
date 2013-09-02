using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	public Vector3 forceVector;
	public float rotationSpeed;
	public float rotation;
	
	// Use this for initialization
	void Start () {
		forceVector.x = 1.0f;
		rotationSpeed = 2.0f;
	}
	
	void FixedUpdate() {
		// force thruster
		if(Input.GetAxisRaw ("Vertical") > 0) {
			gameObject.rigidbody.AddRelativeForce(forceVector);
		}
		
		if(Input.GetAxisRaw("Horizontal") > 0) {
			rotation += rotationSpeed;
			Quaternion rot = Quaternion.Euler (new Vector3(0, rotation, 0));
			gameObject.rigidbody.MoveRotation(rot);
		}
		else if(Input.GetAxisRaw("Horizontal") < 0) {
			rotation -= rotationSpeed;
			Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
			gameObject.rigidbody.MoveRotation(rot);
		}	
	}	
	// Update is called once per frame
	void Update () {
		// no op
	}
}
