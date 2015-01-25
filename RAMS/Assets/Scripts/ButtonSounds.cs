using UnityEngine;
using System.Collections;

public class ButtonSounds : MonoBehaviour {

	[SerializeField] AudioClip down;
	[SerializeField] AudioClip up;


	public void playSound(){

		if (Input.GetKey("down")) {
			audio.PlayOneShot(down);		
		}
		if (Input.GetKey ("up")) {
			audio.PlayOneShot(up);
		}
		//sound effect to play "submit" sound is in changeScene.cs
	}
}
