using UnityEngine;
using System.Collections;

public class changeScene : MonoBehaviour {


	public void changeToScene(int scene){
		if (scene == -1) {
			Application.Quit();		
		}
		Application.LoadLevel(scene);
	}
}
