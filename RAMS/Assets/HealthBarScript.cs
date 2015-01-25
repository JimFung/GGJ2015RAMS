using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

	private int maxHealth = 100;
	private int currHealth = 100;

	private float healthBarLength;

	void OnGUI() {
		GUI.Box(new Rect(10, 10, healthBarLength, 20), currHealth + "/" + maxHealth);
	} 

	public void AdjustCurrentHealth(int adj) {
		int tmpHealth = currHealth;
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

		while (tmpHealth != currHealth) {
			healthBarLength = (Screen.width / 2) * (currHealth / (float)maxHealth);	
		}

	}
	
	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
		//AdjustCuttentHealth (0);
	}
}
