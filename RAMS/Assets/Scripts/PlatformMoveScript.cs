using UnityEngine;
using System.Collections;

public class PlatformMoveScript : MonoBehaviour {

	[SerializeField] Rigidbody2D _grassPlatform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		_grassPlatform.AddForce(Vector3.up);

	}

	void FixedUpdate() {

	}
}

