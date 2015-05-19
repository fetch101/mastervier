using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;



public class PauseMenu : MonoBehaviour {

	public static PauseMenu instance;
	private bool wasMoving = false;
	public bool isInSight = false;

	bool rayCasting = true;
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
	
//		if (Input.GetKeyDown (KeyCode.Z)) {
//			Application.CaptureScreenshot("/Users/itz/Desktop/Screenshots4/Screenshot4_1.png", 5);		
//		}


        oldContentInSight = contentInSight;
		if(rayCasting){
			isInSight = setContentInSight();
		}

        if (!contentInSight == oldContentInSight && clickCount != 2)
        {
            PauseMenuCanvas.GetComponent<PauseTagHandler>().setDisplayContent(contentInSight);
            RuntimeTagCanvas.GetComponent<RuntimeTagHandler>().setDisplayContent(contentInSight);
//			currContentInSight.destroyHighlightPlane();
        }

        if (isInSight)
        {
            if (!isPause && clickCount != 2) { 
                RuntimeTagCanvas.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                contentInSight.moveTo(contentInSight.transform.position);
                ViewKeeper.instance.circleView(contentInSight);
            }

        }else{
            RuntimeTagCanvas.SetActive(false);
        }


		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
        {
			if (focusModeOn) {
				alligneCameraToCOntentInSight3();
			}
			togglePause();


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
        if (isInSight && clickCount != 2)
        {
            RuntimeTagCanvas.SetActive (true);
        }

		PauseMenuCanvas.SetActive (false);

        isPause = false;
    }

    private void setPause()
    {
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
}



