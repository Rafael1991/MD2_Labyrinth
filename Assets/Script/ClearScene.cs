using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScene : MonoBehaviour{

	private Renderer rend;

	public void Update(){

        if (Input.GetButtonDown("Space")){

            clearScene();
        }
    }

   	public void clearScene(){
   		foreach (var roomobj in FindObjectsOFType(typeof(GameObject)) as GameObject[]){
   			if (roomobj.name == "LB(clone)"){
   				rend = roomobj.GetComponent<Renderer>()
   				rend.enabled = false;
   				//Destroy(roomobj);
   			}
   			else if (roomobj.name == "RB(clone)"){
   				rend = roomobj.GetComponent<Renderer>()
   				rend.enabled = false;
   				//Destroy(roomobj);
   			}
   		}
   	}
}