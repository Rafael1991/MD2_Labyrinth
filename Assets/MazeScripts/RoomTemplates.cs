using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

	public GameObject[] AllRooms;

	public List<GameObject> rooms;

	public float waitTime;
	private bool spawnedTreasure;
	public GameObject treasure;
    private bool spwanedStart;

    void Update() {
        //to be sure that all rooms are spawned before lava is spawned
        if (waitTime <= 0 && spawnedTreasure == false) {
            for (int i = 0; i < rooms.Count; i++) {
                if (i == rooms.Count - 1) {

                
                        Instantiate(treasure, rooms[i].transform.position, Quaternion.identity);
                        spawnedTreasure = true;
                    }
                }
            } else {
                waitTime -= Time.deltaTime;
            }
        }
    }
