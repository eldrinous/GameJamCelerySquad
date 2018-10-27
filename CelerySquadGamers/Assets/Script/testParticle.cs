﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testParticle : MonoBehaviour {

	private ParticleSystem pSys;
	public GameObject bird;
	private Vector3 birdPos;

	// Use this for initialization
	void Start () 
	{
		pSys = GetComponent<ParticleSystem>();
		pSys.Emit(5);
	}
	
	// Update is called once per frame
	void Update () 
	{
		ParticleSystem.Particle[] particles = new ParticleSystem.Particle[pSys.particleCount];
		birdPos = bird.transform.position;

		pSys.GetParticles(particles);

			for (int i = 0; i < particles.Length; i++)
        	{
				if (particles[i].totalVelocity.y < 0)
				{
					Vector3 diff = birdPos - particles[i].position;

					if (diff.magnitude > 5)
					{
						diff.Normalize();					
						particles[i].velocity += diff;
					}
					else
					{
						Debug.Log("SLOW");
						diff.Normalize();
						float num = 0.9f;
						particles[i].velocity = new Vector3((particles[i].velocity.x+diff.x)*num, (particles[i].velocity.y+diff.y)*num, (particles[i].velocity.z+diff.z)*num);
					}
				}
        	}

        pSys.SetParticles(particles, particles.Length);
	}
}
