using UnityEngine;
using System.Collections;

public class PowerUpHandler : MonoBehaviour {


	[SerializeField] GameObject flower;
	static System.Random rnd = new System.Random();
	// spawning regions

	private float minx = -7.0f;
	private float maxx = 8.0f;
	private float miny = 6.0f;
	private float maxy = 8.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!flower.activeSelf && ChanceToOccur()) {
			flower.transform.position = GetSpawnLocation();
			flower.SetActive(true);
		}
	}


	bool ChanceToOccur(){
		int chance = rnd.Next(1200);
		// chance == 0 for 1 in 30 secs in 60 fps chance of running
		return chance != 0;

	}
	Vector3 GetSpawnLocation() {
	
		return new Vector3(Random.Range(minx, maxx), Random.Range(miny, maxy), 0);
	
	}
}

