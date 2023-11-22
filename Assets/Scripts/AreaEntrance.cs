using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AreaEntrance : MonoBehaviour {

    public string areaJointPoint;

	// Use this for initialization
	void Start () {
        //si té el mateix nom que el que guarda el Player, el teletransportem a aquest punt
        if (areaJointPoint == PlayerController.instance.areaJointPoint){            
            PlayerController.instance.transform.position = transform.position;
        }
	}
}
