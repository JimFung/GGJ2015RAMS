using UnityEngine;
using System.Collections;

public class changeScene : MonoBehaviour {


	public void changeToScene(int scene){
		Application.LoadLevel(scene);
	}
}
