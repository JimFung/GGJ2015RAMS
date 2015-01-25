using UnityEngine;
using System.Collections;

public class ButtonSounds : MonoBehaviour {

	[SerializeField] AudioClip down;
	[SerializeField] AudioClip up;
	[SerializeField] AudioClip select;

	public void playSound(){

		if (Input.GetKey("down")) {
			Debug.Log("down");
			audio.PlayOneShot(down);		
		}
		if (Input.GetKey ("up")) {
			Debug.Log("up");
			audio.PlayOneShot(up);
		}
		if (Input.GetKey ("enter") || Input.GetKey ("return")) {
			Debug.Log("select");
			audio.PlayOneShot(select);
		}
	}
}
