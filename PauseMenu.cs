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
	float currThreshold = 3.0f;
	public int clickCount = 0; 
    private bool isPause;
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
                ViewKeeper.instance.circleView(contentInSight);
            }

        }else{
            RuntimeTagCanvas.SetActive(false);
        }
		if (Input.GetKeyDown(KeyCode.Escape))
        {
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
				rayCasting = true;
			}
		}
    }


	public bool setContentInSight(){
		
		Ray raycheck = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));

		RaycastHit hitcheck;
		
		if (Physics.Raycast (raycheck, out hitcheck, 60.0f) && hitcheck.collider.gameObject.GetComponent<Content>() != null) {
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
        SimKeeper.instance.enabled = false;
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
        SimKeeper.instance.enabled = true;
        RuntimeTagCanvas.SetActive(false);
		Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isPause = true;
		PauseMenuCanvas.SetActive (true);
    }

	private void alligneCameraToCOntentInSight1 (){
		focusModeOn = true;
		currThreshold = SimKeeper.instance.threshold;
		FocusOnContentCanvas.SetActive(true);
		mainCamera.transform.position = new Vector3 (currContentInSight.transform.position.x + 0.01f ,  currContentInSight.transform.position.y  + 35.0f, currContentInSight.transform.position.z); 
        SimKeeper.instance.destroyLines();
		if (currContentInSight.isMoving) {
			currContentInSight.speed = 0.0f;
			wasMoving = true;
		}
	}

	private void alligneCameraToCOntentInSight2 (){
			RuntimeTagCanvas.SetActive(false);
	}

	public void alligneCameraToCOntentInSight3 (){
		FocusOnContentCanvas.SetActive(false);
		RuntimeTagCanvas.SetActive(true);
		mainCamera.transform.position = currPosition;

		if(wasMoving == true){
			currContentInSight.speed = 40.0f;
			wasMoving = false;
	    }

    	SimKeeper.instance.redrawLines();
		focusModeOn = false;
		clickCount = 0;
	}

}



