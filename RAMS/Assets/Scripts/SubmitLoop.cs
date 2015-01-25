using UnityEngine;
using System.Collections;

public class SubmitLoop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ChangeScene.flag && Time.time - ChangeScene.startTime >= .8) {
			ChangeScene.flag = false;
			Application.LoadLevel(ChangeScene.sceneValue);
		}
	}
}
