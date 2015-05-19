using UnityEngine;
using System.Collections;


public class RTTDestroyer : MonoBehaviour {

	public static RTTDestroyer instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}



	void OnDestroy(){
		
		Destroy(this.gameObject);
		
		
		
	}
}
