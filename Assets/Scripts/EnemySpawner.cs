using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	// Use this for initialization
	float rate_of_spawn  = 5f;
	float next_enemy = 1;
	float spawn_distance = 12f;

	public int speed_cap = 2;
	public float speed_increase = 0.9f;
	// Update is called once per frame
	void Update () {
		next_enemy-=Time.deltaTime;
		if(next_enemy<=0){
			if(rate_of_spawn>speed_cap)rate_of_spawn*=speed_increase;
			next_enemy = rate_of_spawn;
		Vector3 offset = Random.onUnitSphere;		
		offset.z = 0;
		offset = offset.normalized * spawn_distance;

		Instantiate(enemy,transform.position+offset,Quaternion.identity);
	}
	}
}
