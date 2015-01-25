using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

	[SerializeField] string position = "Left";
	private int maxHealth = 100;
	private int currHealth = 100;

	private int barHeight = 20;
	private int topPadding = 10;
	private int x, y;

	private float healthBarLength;

	void OnGUI() {
		GUI.Box(new Rect(x, y, healthBarLength, barHeight), currHealth + "/" + maxHealth);
	}

	public void AdjustCurrentHealth(int adj) {
		//int tmpHealth = currHealth;
		currHealth += adj;

		if (currHealth < 0) {
			currHealth = 0;

//			while(newHealth != currHealth)
//			{
//				newHealth -= 5;
//				healthBarLength = (Screen.width / 2) * (newHealth / (float)maxHealth);
//			}
		}

		if (currHealth > maxHealth) {
			currHealth = maxHealth;
		}

//		while (tmpHealth != currHealth) {
			healthBarLength = (Screen.width / 2) * (currHealth / (float)maxHealth);	
//		}
	}
	
	// Use this for initialization
	void Start () {
		x = 10; y = topPadding;
		healthBarLength = Screen.width / 2 - 2 * topPadding;

		if (position.ToLower ().Equals ("right")) {
			x = (int)(Screen.width - healthBarLength) - x;
		}
	}
}
