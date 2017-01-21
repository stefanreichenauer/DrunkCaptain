using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGeneratorSimulator5000 : MonoBehaviour {

	public List<GameObject> wavePrefabs;
	private List<GameObject> generatedWaves;

	public float spawnSpeed = 1000;

	private float nextSpawn = 0;

	public float minWaveSpeed = 1;
	public float maxWaveSpeed = 2;

	private BoxCollider2D spawnBox;

	// Use this for initialization
	void Start () {
		spawnBox = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Time.time > nextSpawn){
			nextSpawn = Time.time + spawnSpeed;
			GameObject wavePrefab = wavePrefabs[Random.Range(0, wavePrefabs.Count)];
			Vector2 min = spawnBox.bounds.min;
			Vector2 dimension = spawnBox.bounds.size;
			Vector2 spawnLoc = min + new Vector2(dimension.x * Random.value, dimension.y * Random.value);
			GameObject wave = Instantiate(wavePrefab, spawnLoc, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
			
			float waveSpeed = Random.Range(minWaveSpeed, maxWaveSpeed);
			Vector2 waveDirection = wave.transform.up * -1;
			wave.GetComponent<Rigidbody2D>().AddForce(waveDirection * waveSpeed, ForceMode2D.Impulse);
		}
	}
}
