using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class RoomSpawner : MonoBehaviour {

	// public int openingDirection;
	// // 1 --> need bottom door
	// // 2 --> need top door
	// // 3 --> need left door
	// // 4 --> need right door

	public const int BoardSize = 12;

	private RoomTemplates templates;
	private int rand;
	public bool spawned = false;

	public float waitTime = 4f;
	private int i,j;


	void Start(){

		Destroy(gameObject, waitTime);
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		Invoke("Spawn", 0.1f);
	}


	void Spawn(){


   		// This constructor initializes the board.
        // for (int x = 0; x < BoardSize; x++) {
        //     for (int y = 0; y < BoardSize; y++) {
				rand = Random.Range(0, templates.AllRooms.Length);
              	Instantiate(templates.AllRooms[rand], transform.position, templates.AllRooms[rand].transform.rotation);
		// 		i+=10;
		// 		j+=10;
            
        // 	}
		// }
			// if(openingDirection == 1){
			// 	// Need to spawn a room with a BOTTOM door.
			// 	rand = Random.Range(0, templates.bottomRooms.Length);
			// 	Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
			// } else if(openingDirection == 2){
			// 	// Need to spawn a room with a TOP door.
			// 	rand = Random.Range(0, templates.topRooms.Length);
			// 	Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
			// } else if(openingDirection == 3){
			// 	// Need to spawn a room with a LEFT door.
			// 	rand = Random.Range(0, templates.leftRooms.Length);
			// 	Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
			// } else if(openingDirection == 4){
			// 	// Need to spawn a room with a RIGHT door.
			// 	rand = Random.Range(0, templates.rightRooms.Length);
			// 	Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
			// }
			
	}

	// void OnTriggerEnter2D(Collider2D other){
	// 	if(other.CompareTag("SpawnPoint")) {
	// 		if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false){
	// 			Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
    //             Destroy(gameObject);
    //         }
            
    //         //because if we destroy it, it won't be there to collide with other spawn 
    //         //points that may appear, and as a result rooms will spawn on top of each other
    //         spawned = true;
	// 	}
	// }
}
