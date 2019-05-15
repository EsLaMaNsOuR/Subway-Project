using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMove : MonoBehaviour {
	
	public float h_move = 0;
	public float runSpeed;
	// Use this for initialization
	void Start () {
		//runSpeed = 7;		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody> ().velocity = new Vector3 (h_move, 0, runSpeed);


	}
}
