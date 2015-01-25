using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public void changeToScene(int scene){
		Application.LoadLevel (scene);
	}
}
