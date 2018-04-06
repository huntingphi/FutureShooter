using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform my_target;
	public bool follow;
	// Update is called once per frame
	void Update () {
		if(follow){
		if (my_target != null){
			Vector3 new_position = my_target.position;
			new_position.z = transform.position.z;
			transform.position = new_position;
		}
		}
	}
}
