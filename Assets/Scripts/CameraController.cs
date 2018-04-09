using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject my_target;
	public bool follow;
	string target;
	// Update is called once per frame

	void Start(){
		target = my_target.name;
	}
	void Update () {
		if(GameObject.Find(target)==null){
			Debug.Log("Target not found: "+target);
		}
		else{

        GameObject player_object = GameObject.Find(target);
            if (follow&&player_object!=null)
            {
                // player_object = GameObject.Find(my_target.name);
				// Debug.Log(GameObject.Find(my_target.name));
                if(player_object == null){
				}else{
                my_target = player_object;
				}
				
				if (my_target != null)
                {
                    Vector3 new_position = my_target.transform.position;
                    new_position.z = transform.position.z;
                    transform.position = new_position;
                }
            }
		}		
	}
}
