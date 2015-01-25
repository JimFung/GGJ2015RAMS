using UnityEngine;
using System.Collections;

public class FlipClouds : MonoBehaviour {

	public void randomizeCloud(){
		this.gameObject.transform.localScale = new Vector3 ((-1 * this.gameObject.transform.localScale.x), this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
		//layer = 2 : behind mountain
		//layer = 5 : infront of mountain
		if((int)Random.Range(1,10)%2 == 0){
			//even
			this.gameObject.renderer.sortingOrder= 2;
		}else{
			//odd
			this.gameObject.renderer.sortingOrder = 5;
		}
	}
}
