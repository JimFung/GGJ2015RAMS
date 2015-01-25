using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

	public float health;
	public Texture2D texture;
	public Material mat;// = new Material();

	private float x = 10, y = 10;
	private float w = 300, h = 50;

	void Start() {
		health = 100;
	}


	void OnGUI() {
		if (Event.current.type.Equals (EventType.Repaint)) {
			Rect box = new Rect(x,y,w,h);
			Graphics.DrawTexture(box, texture, mat);
		}
	}

	void Update() {
		float wh = (float)(1 - (health / 100));
		if (wh == 0) {
			wh = 0.1f;
		}
		mat.SetFloat ("_Cutoff", wh);
	}
}
