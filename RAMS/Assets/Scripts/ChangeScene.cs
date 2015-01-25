using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	[SerializeField] int scene;

	public void changeScene(){
		Application.LoadLevel (scene);
	}
}
