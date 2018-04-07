using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFade : MonoBehaviour {
	public Texture2D fade_out_texture;
	public float fade_speed = 0.8f;

	public int draw_depth = -1000;
	private float alpha = 1f; //Fully opaque

	private int fade_dir = -1; //Direction of fade where -1 is in and 1 is out
	// Use this for initialization
	void OnGui(){
		//Fade out/in

		alpha+=fade_dir*fade_speed*Time.deltaTime;
		//Clamp to a value between 0 and 1 as alpha is only between 0 and 1

		//Change alpha of our gui

		GUI.color = new Color(GUI.color.r,GUI.color.g,GUI.color.b,alpha);
		GUI.depth = draw_depth; //Ensure black texture renders on top
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),fade_out_texture);

		alpha = Mathf.Clamp01(alpha);
	}

	//Set fade direction
	public float StartFade(int direction){
		fade_dir = direction;
		return fade_speed;
	}

	void OnLevelLoaded(){
		StartFade(-1);
	}
}
