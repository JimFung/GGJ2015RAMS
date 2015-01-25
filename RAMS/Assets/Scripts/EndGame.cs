using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	[SerializeField] int secondsBeforeCredits = 30;

	private bool isEndGame = false;
	private float startTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!isEndGame){
			return;
		}

		Debug.Log("waiting to switch to credits");
		if (startTime + secondsBeforeCredits <= Time.time) {
			Application.LoadLevel(2);
			Debug.Log ("switch to credits");
		}
	
	}

	void PrepEndGame(){
		Debug.Log ("at prep end game");
		isEndGame = true;
		startTime = Time.time;
	}
}
