using UnityEngine;
using System.Collections;

public class SubmitLoop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (changeScene.flag && Time.time - changeScene.startTime >= .8) {
			Debug.Log(changeScene.sceneValue);
			changeScene.flag = false;
			Application.LoadLevel(changeScene.sceneValue);
		}
	}
}
