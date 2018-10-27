﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float partsCount;

    public int hitlayer = 8;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject temp = collision.gameObject;
        objValueScript tempObjScript = temp.GetComponent<objValueScript>();
        if (temp.layer == hitlayer)
        {
            //add points to curreny based on value from obj or remove points based on value from obj
            if (temp.tag == "Obstacle" /*&& blocking is true*/)
            {
                //ignore the damage taken and destroy the obstacle and add some JUICINESSS
                //later on give that so it absorb parts animation or lookness
                tempObjScript.destroyObj(gameObject);
            }
            else
            {
                partsCount += tempObjScript.returnValue();
                Destroy(temp);
            }

        }
    }
}
