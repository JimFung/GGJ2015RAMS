using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {

	[SerializeField] SpriteRenderer sr;
	[SerializeField] float alphaDecay = 0.01f;
	[SerializeField] GameObject gameListener ;
	bool isEndGame = false;
	float alphaLevel = 1.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (!isEndGame) {
			return;

		
		}
		Debug.Log ("Now lowering alpha");
		sr.color = new Color (1f,1f,1f,alphaLevel);
		alphaLevel -= alphaDecay;
		if (alphaLevel <= 0) {
			gameListener.SendMessage( "PrepEndGame");
			this.gameObject.SetActive(false);
		}
	}

	void BeginFadeOut(){
		isEndGame = true;
	}
}
