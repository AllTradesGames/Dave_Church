using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genrate_Gold : MonoBehaviour {

	public GameObject goldPrefab;
	public float spawnDelay = 0.5f; 
	public Vector2 xboundary;
	public Vector2 yboundary;

	private float lastSpawnTime = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > (lastSpawnTime + spawnDelay)) {
			Instantiate(goldPrefab, new Vector2(Random.Range(xboundary.x, xboundary.y), Random.Range(yboundary.x, yboundary.y)), Quaternion.identity);
			lastSpawnTime = Time.time;
		}
	}
}
