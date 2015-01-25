using UnityEngine;
using System.Collections;

public class changeScene : MonoBehaviour {

	[SerializeField] AudioClip select;

	public static bool flag = false;
	public static float startTime = 0;
	public void changeToScene(int scene){
		if (scene == -1) {
			Application.Quit();		
		}
		audio.PlayOneShot(select);
		startTime = Time.time;
		while (!flag) {
			//updates inside SubmitLoop
		}
		flag = false;
		Application.LoadLevel(scene);
	}

}
