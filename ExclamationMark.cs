using UnityEngine;
using System.Collections;

public class ExclamationMark : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (new Vector3(0, 0, 100)  * Time.deltaTime);



	
	}

	void OnDestroy(){

		Destroy(this.gameObject);


	
	}


//	public void destroyMe(){
//
//		Destroy(this.gameObject);
//	}




}
