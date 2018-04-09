using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {
	public int health = 1;
	public float invicibility_period = 0.5f;
	float invincible_timer = 0f;
	int initial_layer;
	SpriteRenderer sprite_renderer;

	void Start(){
		initial_layer = gameObject.layer;
		
		//ONLY GETS PARENT OBJECT RENDERER
		sprite_renderer = GetComponent<SpriteRenderer>();
		if(sprite_renderer== null){
			sprite_renderer = transform.GetComponentInChildren<SpriteRenderer>();
			if(sprite_renderer==null){
                Debug.Log("No sprite sprite_renderer");
            }
		}
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == gameObject.layer || col.gameObject.layer == 0) return;
		if(col.gameObject.tag == "Bullet")GameObject.Destroy(col.gameObject);
        Debug.Log("Trigger!");
        health--;

        invincible_timer = invicibility_period;
    }
	void OnTriggerEnter2D () {
		Debug.Log("Trigger!");
		health--;

		invincible_timer = invicibility_period;
	}

	void Update(){
		invincible_timer-=Time.deltaTime;
        if (invincible_timer <= 0) {
			if(sprite_renderer!=null){
				sprite_renderer.enabled = true;
			}
			gameObject.layer = initial_layer;
		}else{
			if(sprite_renderer!=null){
				sprite_renderer.enabled = !sprite_renderer.enabled;
			}
		}

		if(health<=0){
            Die();
		}


    }


	void Die(){
		Camera[] cams = Camera.allCameras;
		CameraController cc;
		if(gameObject.name == "Player1"){
			if(cams[0].tag=="Camera1")cc =cams[0].GetComponent<CameraController>();
			else cc = cams[1].GetComponent<CameraController>();
		}else{
            if (cams[0].tag == "Camera2") cc = cams[0].GetComponent<CameraController>();
            else cc = cams[1].GetComponent<CameraController>();
		} 
			
		cc.enabled = false;

        Destroy(gameObject);
	}
}
