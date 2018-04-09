using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float max_speed = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;

		Vector3 velocity = new Vector3(0,max_speed * Time.deltaTime, 0);
		pos+= transform.rotation*velocity;
		transform.position  =pos;
	}
}
