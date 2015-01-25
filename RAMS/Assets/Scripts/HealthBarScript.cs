using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {
	
	[SerializeField] string position = "Left";
	private int maxHealth = 100;
	private int currHealth = 100;
	private Color color;
	
	private int barHeight = 20;
	private int topPadding = 10;
	private int x, y;
	
	private float healthBarLength;
	private float minHealthBarLength;
	
	void OnGUI() {
		GUI.backgroundColor = Color.green;
		if (healthBarLength > minHealthBarLength) {
			GUI.Button (new Rect (x, y, healthBarLength, barHeight), "");
		}
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
		if (healthBarLength < minHealthBarLength) {
			healthBarLength = minHealthBarLength;
		}
		//		}
		
		if (currHealth <= 0) {
			
			Debug.Log("Boardcasting to switch to  end game");
			BroadcastMessage("StopAttacking");
			BroadcastMessage("BeginFadeOut");
			
			
		}
	}
	
	// Use this for initialization
	void Start () {
		x = 10; y = topPadding;
		healthBarLength = Screen.width / 2 - 2 * topPadding;
		minHealthBarLength = (float)(healthBarLength * 0.1);
		if (position.ToLower ().Equals ("right")) {
			x = (int)(Screen.width - healthBarLength) - x;
		}
	}
}
