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
		AdjustCurrentHealth (-90);
		GUI.Box(new Rect(x, y, healthBarLength, barHeight), currHealth + "/" + maxHealth);
	}

	public void AdjustCurrentHealth(int adj) {
		Debug.Log ("2");
		int tmpHealth = currHealth;
		currHealth += adj;

		if (currHealth < 0) {
			Debug.Log ("<0");
			currHealth = 0;
		} else {
			Debug.Log (">0");
			while((adj > 0 && tmpHealth < currHealth) || (adj < 0 && tmpHealth > currHealth))
			{
				Debug.Log ("while");
				tmpHealth += (adj > 0) ? adj : -1 * adj;
				healthBarLength = (Screen.width / 2) * (tmpHealth / (float)maxHealth);
			}
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
		Debug.Log ("1");
	}
}
