using UnityEngine;
using System.Collections;

public class Spectator : MonoBehaviour
{


	public static Spectator instance;
//	public Transform targetToLookAt;
//	public Transform targetToLookAtEmpty;
//	private int clickCount2 = 0;

    //initial speed
    public int speed = 60;
	public float mouseWheel = 0;

    // Use this for initialization
    void Start()
    {
        instance = this;
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (PauseMenu.instance.clickCount > 0){
			transform.LookAt (PauseMenu.instance.target.transform);

		} else {

			//press shift to move faster
			if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
				speed = 350;

			} else {
				//if shift is not pressed, reset to default speed
				speed = 40;
			}
			//For the following 'if statements' don't include 'else if', so that the user can press multiple buttons at the same time
			//move camera to the left
			if (Input.GetKey (KeyCode.A)) {
				transform.position = transform.position + Camera.main.transform.right * -1 * speed * Time.deltaTime;
			}

			//move camera backwards
			if (Input.GetKey (KeyCode.S)) {
				transform.position = transform.position + Camera.main.transform.forward * -1 * speed * Time.deltaTime;

			}
			//move camera backwards
			if (Input.GetAxis("Mouse ScrollWheel") < 0) {
				transform.position = transform.position + Camera.main.transform.forward * -10 * speed * Time.deltaTime;
				
			}

			//move camera to the right
			if (Input.GetKey (KeyCode.D)) {
				transform.position = transform.position + Camera.main.transform.right * speed * Time.deltaTime;

			}
			//move camera forward
			if (Input.GetKey (KeyCode.W)) {

				transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
			}
			if (Input.GetAxis("Mouse ScrollWheel") > 0) {
				
				transform.position = transform.position + Camera.main.transform.forward * speed * 10 * Time.deltaTime;
			}
			//move camera upwards
			if (Input.GetKey (KeyCode.E)) {
				transform.position = transform.position + Camera.main.transform.up * speed * Time.deltaTime;
			}
			//move camera downwards
			if (Input.GetKey (KeyCode.Q)) {
				transform.position = transform.position + Camera.main.transform.up * -1 * speed * Time.deltaTime;
			}
		}
    }

//	public void SetClickCountToZero(){
//		clickCount2 = 0;
//	}

}