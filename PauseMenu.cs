using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;



public class PauseMenu : MonoBehaviour {

	public static PauseMenu instance;
	private bool wasMoving = false;
	public bool isInSight = false;

	public bool rayCasting = true;
	Content currContentInSight;
	Content contentInSight;
    Content oldContentInSight;
	public GameObject FocusOnContentCanvas;
    public GameObject RuntimeTagCanvas;
	public GameObject PauseMenuCanvas;
	Vector3 currPosition;
	public int clickCount = 0; 
    public bool isPause;
	public GameObject mainCamera;
	public GameObject target;
	public bool focusModeOn = false;
	public float timerPauseMenu = 0;
	public int currentPauseMenu = 0;
	public bool iWillRaycast = true;
	public bool setPauseWithButton = false;

	private float delayPauseMenu = 5;

    // Use this for initialization
    void Start()
    {
		instance = this;
		FocusOnContentCanvas.SetActive (false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isPause = true;
		focusModeOn = false;

    }

    // Update is called once per frame
    void Update()
    {
		if (Input.anyKey || Input.GetAxis ("Mouse ScrollWheel") != 0 || Input.GetAxis ("Mouse X") != 0 || Input.GetAxis ("Mouse Y") != 0){
			Spectator.instance.current = 0;
			Spectator.instance.ScreensaverCanvas.SetActive (false);
			Spectator.instance.ScreensaverCanvas1.SetActive (false);
			Spectator.instance.ScreensaverCanvas2.SetActive (false);
			Spectator.instance.ScreensaverCanvas3.SetActive (false);
			Spectator.instance.ScreensaverCanvas4.SetActive (false);
			Spectator.instance.ScreensaverCanvas5.SetActive(false);
			Spectator.instance.ScreensaverCanvas6.SetActive(false);
			Spectator.instance.ScreensaverCanvas7.SetActive(false);
			Spectator.instance.ScreensaverCanvas8.SetActive(false);
			Spectator.instance.ScreensaverCanvas9.SetActive(false);
			Spectator.instance.ScreensaverCanvas10.SetActive(false);
//			Spectator.instance.ScreensaverCanvas11.SetActive(false);
			Spectator.instance.ScreensaverCanvasBackground.SetActive(false);
			Spectator.instance.screenSaverIsActive = false;
			Spectator.instance.screensaverReachedLoopEnd = false;
			Spectator.instance.screensaverReachedLoopEnd2 = false;
			currentPauseMenu = 0;
			timerPauseMenu = 0;


		}
		if (isPause) {
			timerPauseMenu += Time.deltaTime;
		}
		if(timerPauseMenu > 1.0f)
		{
			currentPauseMenu ++;
			timerPauseMenu = 0;
		}

		if(currentPauseMenu == delayPauseMenu){
			togglePause();
		}

	
	
//			if (Input.GetKeyDown (KeyCode.Z)) {
//				Application.CaptureScreenshot ("/Users/itz/Desktop/Screenshots4/Screenshot4_.png", 10);		
//			}



			oldContentInSight = contentInSight;
			if (rayCasting) {
				isInSight = setContentInSight ();
			}

			if (!contentInSight == oldContentInSight && clickCount != 2) {
				PauseMenuCanvas.GetComponent<PauseTagHandler> ().setDisplayContent (contentInSight);
				RuntimeTagCanvas.GetComponent<RuntimeTagHandler> ().setDisplayContent (contentInSight);
			}

			if (isInSight) {
				if (!isPause && clickCount != 2 && !Spectator.instance.screenSaverIsActive) { 
					RuntimeTagCanvas.SetActive (true);
				}
				if (Input.GetKeyDown (KeyCode.C) || Input.GetMouseButtonDown (3)) {
					contentInSight.moveTo (contentInSight.transform.position);
					ViewKeeper.instance.circleView (contentInSight);
				}

			} else {
				RuntimeTagCanvas.SetActive (false);
			}


			if (Input.GetKeyDown (KeyCode.Escape) || Input.GetMouseButtonDown (1)) {
				if (focusModeOn) {
					alligneCameraToCOntentInSight3 ();
				}
				togglePause ();


			}
			if (Input.GetMouseButtonDown (0) && isInSight && !isPause) {
				clickCount++;
				currContentInSight = contentInSight;
				rayCasting = false;


				if (clickCount == 1) {
					currPosition = mainCamera.transform.position;
					alligneCameraToCOntentInSight1 ();
				}

				if (clickCount == 2) {
					alligneCameraToCOntentInSight2 ();
				}

				if (clickCount == 3) {
					alligneCameraToCOntentInSight3 ();
				}
			}

	}


	public bool setContentInSight(){

//		if (iWillRaycast == false) {
//			return false;
//		}
		Ray raycheck = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));

		RaycastHit hitcheck;
		
		if (Physics.Raycast (raycheck, out hitcheck, 80.0f) && hitcheck.collider.gameObject.GetComponent<Content>() != null) {
            contentInSight = hitcheck.collider.gameObject.GetComponent<Content>();
			target.transform.position = hitcheck.collider.gameObject.transform.position;
//			contentInSight.addHighlightPlane();
			return true;

			}else{
            contentInSight = null;
			return false;	
		}
		
	}

    void togglePause()
    {
        if (isPause)
        {
            setUnPause();
        }
        else
        {
            setPause();
        }
    }

    private void setUnPause()
    {
        MouseLook.instance.enabled = true;
        Spectator.instance.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
		currentPauseMenu = 0;

        if (isInSight && clickCount != 2)
        {
            RuntimeTagCanvas.SetActive (true);
        }

		PauseMenuCanvas.SetActive (false);

        isPause = false;
    }

    private void setPause()
    {
		currentPauseMenu = 0;
        MouseLook.instance.enabled = false;
        Spectator.instance.enabled = false;
        RuntimeTagCanvas.SetActive(false);
		Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isPause = true;
		PauseMenuCanvas.SetActive (true);
    }


	private void alligneCameraToCOntentInSight1 (){
        if (ViewKeeper.instance.circleIsActive)
        {
            ViewKeeper.instance.GetComponent<CircleView>().destroyLines();
        } 
        if (ViewKeeper.instance.sunIsActive)
        {
            ViewKeeper.instance.GetComponent<SunView>().destroyLines();
        }
		focusModeOn = true;
		FocusOnContentCanvas.SetActive(true);
		mainCamera.transform.position = new Vector3 (currContentInSight.transform.position.x + 0.01f ,  currContentInSight.transform.position.y  + 35.0f, currContentInSight.transform.position.z); 
        SimKeeper.instance.destroyLines();
		if (currContentInSight.isMoving) {
			currContentInSight.speed = 0.0f;
			wasMoving = true;
		}
		if (ViewKeeper.instance.filterIsActive){
			currContentInSight.shouldAlign = true;
		}
	}

	private void alligneCameraToCOntentInSight2 (){
			RuntimeTagCanvas.SetActive(false);
	}

	public void alligneCameraToCOntentInSight3 (){
        if (ViewKeeper.instance.circleIsActive)
        {
            ViewKeeper.instance.GetComponent<CircleView>().redrawLines();
        } 
        if (ViewKeeper.instance.sunIsActive)
        {
            ViewKeeper.instance.redrawSpiralLines();
        }
		FocusOnContentCanvas.SetActive(false);
        if (contentInSight)
        {
		    RuntimeTagCanvas.SetActive(true);
        }
		mainCamera.transform.position = currPosition;

		if(wasMoving == true){
			currContentInSight.speed = 40.0f;
			wasMoving = false;
	    }

    	SimKeeper.instance.redrawLines();
		focusModeOn = false;
        clickCount = 0;
        rayCasting = true;
		if (ViewKeeper.instance.filterIsActive){
			currContentInSight.shouldAlign = false;
			currContentInSight.transform.rotation = Quaternion.LookRotation(Vector3.up);

		}
	}
	
	
	public void activatePanel1(Animator anim){
		anim.SetBool ("Panel1_IsActive", true);
		anim.SetBool ("Panel2_IsActive", false);
	}
	
	public void activatePanel2(Animator anim){
		anim.SetBool ("Panel1_IsActive", false);
		anim.SetBool ("Panel2_IsActive", true);
	}
	public void bigSizeButton(Animator anim){
		anim.SetBool ("ButtonIsSmall", false);
	}

	public void samllSizeButton(Animator anim){
		anim.SetBool ("ButtonIsSmall", true);
	}
	
	public void restartGame(){
		Application.LoadLevel (0);
	}

	public void quit(){
		Application.Quit ();
	}

	public void togglePauseWithButton(){

			togglePause();
		}

}



