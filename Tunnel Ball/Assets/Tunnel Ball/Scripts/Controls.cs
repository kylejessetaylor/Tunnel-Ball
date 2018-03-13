﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

	//Smooth Rotation
	public float rotationSpeed = 10;
	private Quaternion targetRotation;

	//Player's corpse spawn
	private GameObject corpse;
    private GameObject player;

	void Start () {
		targetRotation = transform.rotation;
		corpse = GameObject.FindGameObjectWithTag ("Corpse");
        //Finds Player
        player = GameObject.FindGameObjectWithTag("Player");

    }

	// Update is called once per frame
	void Update () {
		tunnelRotation ();
		PlayerCorpse ();
	}

	//Controls
	private void tunnelRotation () {
        ///Right Turn ---------------------------------------------------------------
		if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {
				targetRotation *= Quaternion.AngleAxis (45, Vector3.back);
			}
        ///Left Turn ----------------------------------------------------------------
		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) {
				targetRotation *= Quaternion.AngleAxis (45, Vector3.forward);
			}

        //Smooth Rotation
		transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
	}

    //Turn Functions
    public void TurnRight()
    {
        //Sets new targetRotation
        targetRotation *= Quaternion.AngleAxis(45, Vector3.back);
    }

    public void TurnLeft()
    {
        //Sets new targetRotation
        targetRotation *= Quaternion.AngleAxis(45, Vector3.forward);
    }

    //Turns on Player Corpse when death trigger activates
    private void PlayerCorpse () {
		if (player == null) {
            //Stops multiple shards spawning
            bool shardSpawned = false;

            if (shardSpawned == false) {
                //Spawns Shards
                corpse.transform.GetChild(0).gameObject.SetActive(true);

                shardSpawned = true;
            }
        }
	}
}
