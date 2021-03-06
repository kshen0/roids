﻿using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour { 
	public Vector3 thrust; 
	public Quaternion heading; 
	// Use this for initialization 
	void Start () { 
		// travel straight in the X-axis 
		thrust.x = 400.0f; 
		// do not passively decelerate 
		gameObject.rigidbody.drag = 0; 
		// set the direction it will travel in 
		gameObject.rigidbody.MoveRotation(heading); 
		// apply thrust once, no need to apply it again since 
		// it will not decelerate 
		gameObject.rigidbody.AddRelativeForce(thrust); 
	} 
	// Update is called once per frame 
	void Update () { 
		//Physics engine handles movement, empty for now. 
	} 
	
	void OnCollisionEnter(Collision collision) {
		Collider collider = collision.collider;
		
		if(collider.CompareTag("Asteroids")) {
			Asteroid roid = collider.gameObject.GetComponent<Asteroid>();
			roid.Die();
			Destroy(gameObject);
		}
		else {
			Debug.Log("Collided with " + collider.tag);
		}
	}
} 