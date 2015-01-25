using UnityEngine;
using System.Collections;

public class FlowerPowerup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D hit) {

		var hitLayer = hit.gameObject.layer;
		// 8 terrain, 9 goat, 10 goatpassableterrain layer
		if ( hitLayer ==9 || hitLayer ==10  ){
			
			

			
			hit.gameObject.BroadcastMessage("AdjustCurrentHealth", 20);
			this.gameObject.SetActive(false);
			
		}
		
	}
}
