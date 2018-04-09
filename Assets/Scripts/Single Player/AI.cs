using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
	Transform player;
	public float rotation_speed = 90f; //per second
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null){
			GameObject player_object = GameObject.Find("Player1");
			if (player_object != null) player = player_object.transform;
		}
			if(player == null)return;

			Vector3 player_direction = player.position - transform.position;
			player_direction.Normalize();

			float zAngle = Mathf.Atan2(player_direction.y,player_direction.x)* Mathf.Rad2Deg - 90;

			Quaternion rotate_towards = Quaternion.Euler(0,0,zAngle);
			transform.rotation = Quaternion.RotateTowards(transform.rotation,rotate_towards,Time.deltaTime*rotation_speed);

	}
}
