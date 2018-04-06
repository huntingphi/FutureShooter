using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
	public int no_lives = 4;
	public GameObject player_prefab;
	GameObject player_instance;
	float respawn_timer = 1f;
	// Use this for initialization
	void Start () {
		Spawn();
	}
	
	// Update is called once per frame
	void Update () {
		if(no_lives >0 &&player_instance==null){
			respawn_timer -= Time.deltaTime;
			if(respawn_timer<=0){
				Spawn();
			}
		}
		
	}

	void Spawn(){
            no_lives--;
        respawn_timer = 1f;
        player_instance = (GameObject)Instantiate(player_prefab, transform.position, Quaternion.identity);
		player_instance.name = "Player1";

    }


	void OnGUI(){
        if (no_lives > 0||player_instance != null) GUI.Label(new Rect(0,0,100,50),"Lives left: "+no_lives);
        else GUI.Label(new Rect(Screen.width/2-50, Screen.height/2-25, 100, 50),"Game over bru");
	}
}
