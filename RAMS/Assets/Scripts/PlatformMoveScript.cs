using UnityEngine;
using System.Collections;

public class PlatformMoveScript : MonoBehaviour {

	[SerializeField] Transform platform;
	[SerializeField] Transform startTransform;
	[SerializeField] Transform endTransform;
	[SerializeField] float platformSpeed;
	//[SerializeField] int stillTimeSeconds;

	Vector3 direction;
	Transform destination;

	void Start() {
		SetDestination (startTransform);
	}

	//define when to run in project settings time
	void FixedUpdate() {
		platform.rigidbody2D.MovePosition (platform.position + direction * platformSpeed * Time.fixedDeltaTime);
		//float nextMove;
		if (Vector3.Distance (platform.position, destination.position) < platformSpeed * Time.fixedDeltaTime) {
		//	nextMove = Time.time + stillTimeSeconds;
			//while(Time.time < nextMove) { continue; }
			SetDestination (destination == startTransform ? endTransform : startTransform);
		}
	}

	void SetDestination(Transform dest) {
		destination = dest;
		direction = (destination.position - platform.position).normalized;
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube (startTransform.position, platform.localScale);

		Gizmos.color = Color.red;
		Gizmos.DrawWireCube (endTransform.position, platform.localScale);
	}
}
