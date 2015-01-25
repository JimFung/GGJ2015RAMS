using UnityEngine;
using System.Collections;

public class SubmitLoop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - changeScene.startTime >= 3) {
			changeScene.flag = true;
		}
	}
}
