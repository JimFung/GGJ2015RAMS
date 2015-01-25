using UnityEngine;
using System.Collections;

public class FlowerPowerup : MonoBehaviour {
	
	void OnCollisionEnter2D (Collision2D hit) {

		var hitLayer = hit.gameObject.layer;

		// 8 terrain, 9 goat, 10 goatpassableterrain layer
		if ( hitLayer ==9 || hitLayer ==10  ){

			hit.gameObject.BroadcastMessage("AdjustCurrentHealth", 20);
			hit.gameObject.BroadcastMessage("PlayPowerUpSound");

			this.gameObject.SetActive(false);
			
		}
		
	}
}
