using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Spectator : MonoBehaviour
{


	public static Spectator instance;
//	public Transform targetToLookAt;
//	public Transform targetToLookAtEmpty;
//	private int clickCount2 = 0;

    //initial speed
    public int speed = 60;
	public float mouseWheel = 0;
	public float timer = 0.0f;
//	public GameObject ScreensaverCanvas;
	public bool screenSaverIsActive = false;
	public float newTimer = 0.0f;
	public float current = 0.0f;
	public float maximum = 1.0f;
	public Sprite Image1;
	public Image myPanel;
	public float delay = 5;
	private float offset = 25;
	public bool loopEnd = false;
	public bool screensaverReachedLoopEnd = false;
	public bool screensaverReachedLoopEnd2 = false;



	public GameObject ScreensaverCanvas;
	public GameObject ScreensaverCanvas1;
	public GameObject ScreensaverCanvas2;
	public GameObject ScreensaverCanvas3;
	public GameObject ScreensaverCanvas4;
	public GameObject ScreensaverCanvas5;
	public GameObject ScreensaverCanvas6;
	public GameObject ScreensaverCanvas7;
	public GameObject ScreensaverCanvas8;
	public GameObject ScreensaverCanvas9;
	public GameObject ScreensaverCanvas10;
//	public GameObject ScreensaverCanvas11;
	public GameObject ScreensaverCanvasBackground;
	public bool hadSameLines;
	public bool hadDifferentLines;
	public float oldThreshold;
	public float oldTagweight;
	public float oldMetatagweight;







    // Use this for initialization
    void Start()
    {
        instance = this;
        this.enabled = false;
		ScreensaverCanvas.SetActive(false);
		ScreensaverCanvas1.SetActive(false);
		ScreensaverCanvas2.SetActive(false);
		ScreensaverCanvas3.SetActive(false);
		ScreensaverCanvas4.SetActive(false);


	


    }

    // Update is called once per frame
    void Update()
    {
//		Debug.Log (Time.time);

			if (PauseMenu.instance.clickCount > 0) {
				transform.LookAt (PauseMenu.instance.target.transform);

			} else {
			newTimer += Time.time;

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
				if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
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
				if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
				
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

			if (Input.anyKey || Input.GetAxis ("Mouse ScrollWheel") != 0 ||  Input.GetAxis("Mouse X")!= 0 ||  Input.GetAxis("Mouse Y")!=0)
			{
			timer = 0;
			current = 0;

			if(screenSaverIsActive == true){
				ScreensaverCanvas.SetActive(false);
				ScreensaverCanvas1.SetActive(false);
				ScreensaverCanvas2.SetActive(false);
				ScreensaverCanvas3.SetActive(false);
				ScreensaverCanvas4.SetActive(false);
				ScreensaverCanvas5.SetActive(false);
				ScreensaverCanvas6.SetActive(false);
				ScreensaverCanvas7.SetActive(false);
				ScreensaverCanvas8.SetActive(false);
				ScreensaverCanvas9.SetActive(false);
				ScreensaverCanvas10.SetActive(false);
//				ScreensaverCanvas11.SetActive(false);
				ScreensaverCanvasBackground.SetActive(false);
				screensaverReachedLoopEnd = false;
				screensaverReachedLoopEnd2 = false;
//				PauseMenu.instance.rayCasting = true;

				screenSaverIsActive = false;

				if (PauseMenu.instance.isInSight && PauseMenu.instance.clickCount != 2)
				{
					PauseMenu.instance.RuntimeTagCanvas.SetActive (true);
				}


				}

			}

				
		timer += Time.deltaTime;

		if(timer > 1.0f)
			{
			current ++;
			timer = 0;
			}
		if (loopEnd == true) {
			current = delay;
			loopEnd = false;
			screensaverReachedLoopEnd = true;
		}

		if (current == delay) {

			ScreensaverCanvasBackground.SetActive (true);

			if(screensaverReachedLoopEnd == true){
				ScreensaverCanvas.SetActive (true);
				ScreensaverCanvas.GetComponent<Image>().canvasRenderer.SetAlpha(0.0f);
				ScreensaverCanvas.GetComponent<Image> ().CrossFadeAlpha (1, 2, false);
				ScreensaverCanvas10.GetComponent<Image>().CrossFadeAlpha(0, 2, false);
				screensaverReachedLoopEnd = false;
				screensaverReachedLoopEnd2 = true;

			}else{
//				PauseMenu.instance.rayCasting = false;
				PauseMenu.instance.RuntimeTagCanvas.SetActive(false);
				ScreensaverCanvas.SetActive (true);
				ScreensaverCanvasBackground.GetComponent<Image>().canvasRenderer.SetAlpha(0.0f);
				ScreensaverCanvasBackground.GetComponent<Image>().CrossFadeAlpha(1, 2, false);
				ScreensaverCanvas.GetComponent<Image>().canvasRenderer.SetAlpha(0.0f);
				ScreensaverCanvas.GetComponent<Image>().CrossFadeAlpha(1, 2, false);

				screenSaverIsActive = true;

		}

		if(current == (delay + 5) && screensaverReachedLoopEnd2 == true){
			ScreensaverCanvas10.SetActive (false);
			screensaverReachedLoopEnd2 = false;
		}

		if(current == delay + (1 * offset)){
			ScreensaverCanvas.GetComponent<Image>().CrossFadeAlpha(0, 2, false);
			ScreensaverCanvas1.SetActive (true);
			ScreensaverCanvas1.GetComponent<Image>().canvasRenderer.SetAlpha(0.0f);
			ScreensaverCanvas1.GetComponent<Image>().CrossFadeAlpha(1, 2, false);
		}

		if(current == delay + (1 * offset) + 5){
			ScreensaverCanvas.SetActive (false);

		}

		if(current == delay + (2 * offset)){
			ScreensaverCanvas1.GetComponent<Image>().CrossFadeAlpha(0, 2, false);
			ScreensaverCanvas2.SetActive (true);
			ScreensaverCanvas2.GetComponent<Image>().canvasRenderer.SetAlpha(0.0f);
			ScreensaverCanvas2.GetComponent<Image>().CrossFadeAlpha(1, 2, false);
		}
		
		if(current == delay + (2 * offset) + 5){
			ScreensaverCanvas1.SetActive (false);

		}
		if(current == delay + (3 * offset)){
			ScreensaverCanvas2.GetComponent<Image>().CrossFadeAlpha(0, 2, false);
			ScreensaverCanvas3.SetActive (true);
			ScreensaverCanvas3.GetComponent<Image>().canvasRenderer.SetAlpha(0.0f);
			ScreensaverCanvas3.GetComponent<Image>().CrossFadeAlpha(1, 2, false);
		}
		
		if(current == delay + (3 * offset) + 5){
			ScreensaverCanvas2.SetActive (false);

		}

		if(current == delay + (4 * offset)){
			ScreensaverCanvas3.GetComponent<Image>().CrossFadeAlpha(0, 2, false);
			ScreensaverCanvas4.SetActive (true);
			ScreensaverCanvas4.GetComponent<Image>().canvasRenderer.SetAlpha(0.0f);
			ScreensaverCanvas4.GetComponent<Image>().CrossFadeAlpha(1, 2, false);
		}
		
		if(current == delay + (4 * offset) + 5){
			ScreensaverCanvas3.SetActive (false);

		}

		if(current == delay + (5 * offset)){
			ScreensaverCanvas4.GetComponent<Image>().CrossFadeAlpha(0, 2, false);;
			ScreensaverCanvas5.SetActive (true);
			ScreensaverCanvas5.GetComponent<Image>().canvasRenderer.SetAlpha(0.0f);
			ScreensaverCanvas5.GetComponent<Image>().CrossFadeAlpha(1, 2, false);
		}
		if(current == delay + (5 * offset) + 5){
			ScreensaverCanvas4.SetActive (false);

		}

		if(current == delay + (6 * offset)){
			ScreensaverCanvas5.GetComponent<Image>().CrossFadeAlpha(0, 2, false);;
			ScreensaverCanvas6.SetActive (true);
			ScreensaverCanvas6.GetComponent<Image>().canvasRenderer.SetAlpha(0.0f);
			ScreensaverCanvas6.GetComponent<Image>().CrossFadeAlpha(1, 2, false);
		}
		if(current == delay + (6 * offset) + 5){
			ScreensaverCanvas5.SetActive (false);

		}

		if(current == delay + (7 * offset)){
			ScreensaverCanvas6.GetComponent<Image>().CrossFadeAlpha(0, 2, false);;
			ScreensaverCanvas7.SetActive (true);
			ScreensaverCanvas7.GetComponent<Image>().canvasRenderer.SetAlpha(0.0f);
			ScreensaverCanvas7.GetComponent<Image>().CrossFadeAlpha(1, 2, false);
		}
		if(current == delay + (7 * offset) + 5){
			ScreensaverCanvas6.SetActive (false);

		}

		if(current == delay + (8 * offset)){
			ScreensaverCanvas7.GetComponent<Image>().CrossFadeAlpha(0, 2, false);;
			ScreensaverCanvas8.SetActive (true);
			ScreensaverCanvas8.GetComponent<Image>().canvasRenderer.SetAlpha(0.0f);
			ScreensaverCanvas8.GetComponent<Image>().CrossFadeAlpha(1, 2, false);
		}
		if(current == delay + (8 * offset) + 5){
			ScreensaverCanvas7.SetActive (false);

		}

		if(current == delay + (9 * offset)){
			ScreensaverCanvas8.GetComponent<Image>().CrossFadeAlpha(0, 2, false);;
			ScreensaverCanvas9.SetActive (true);
			ScreensaverCanvas9.GetComponent<Image>().canvasRenderer.SetAlpha(0.0f);
			ScreensaverCanvas9.GetComponent<Image>().CrossFadeAlpha(1, 2, false);
		}
		if(current == delay + (9 * offset) + 5){
			ScreensaverCanvas8.SetActive (false);

		}

		if(current == delay + (10 * offset)){
			ScreensaverCanvas9.GetComponent<Image>().CrossFadeAlpha(0, 2, false);;
			ScreensaverCanvas10.SetActive (true);
			ScreensaverCanvas10.GetComponent<Image>().canvasRenderer.SetAlpha(0.0f);
			ScreensaverCanvas10.GetComponent<Image>().CrossFadeAlpha(1, 2, false);
		}
		if(current == delay + (10 * offset) + 5){
			ScreensaverCanvas9.SetActive (false);

		}

//		if(current == delay + (11 * offset)){
//			ScreensaverCanvas10.GetComponent<Image>().CrossFadeAlpha(0, 2, false);;
//			ScreensaverCanvas11.SetActive (true);
//			ScreensaverCanvas11.GetComponent<Image>().canvasRenderer.SetAlpha(0.0f);
//			ScreensaverCanvas11.GetComponent<Image>().CrossFadeAlpha(1, 2, false);
//		}
//		if(current == delay + (11 * offset)+ 5){
//			ScreensaverCanvas10.SetActive (false);
//
//		}
	
		if(current == delay + (11 * offset)){
			loopEnd = true;

		}
	}

}
}