using UnityEngine;
using System.Collections;

public class changeScene1 : MonoBehaviour {

	[SerializeField] AudioClip select;

	public static bool flag = false;
	public static float startTime = 0;
	public static int sceneValue ;
	public void changeToScene(int scene){
		if (scene == -1) {
			Application.Quit();		
		}
		audio.PlayOneShot(select);
		startTime = Time.time;
		sceneValue = scene;
		flag = true;
	}

}
