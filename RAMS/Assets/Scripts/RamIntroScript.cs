using UnityEngine;
using System.Collections;

public class RamIntroScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		animation ["RamMenuAnimation"].wrapMode = WrapMode.Once;
		animation.Play ("RamMenuAnimation");
	}
}
