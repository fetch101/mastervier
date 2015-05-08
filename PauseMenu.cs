﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;



public class PauseMenu : MonoBehaviour {

	private bool isInSight = false;

	Content contentInSight;
    Content oldContentInSight;
	public GameObject FocusOnContentCanvas;
    public GameObject RuntimeTagCanvas;
	public GameObject PauseMenuCanvas;
	private bool click1 = false;
	private bool click2 = false;
	private bool click3 = false;
	public int clickCount = 0; 
    private bool isPause;
	public GameObject mainCamera;
	public GameObject target;
//	private float thresholdFloat = 12.0f;


    // Use this for initialization
    void Start()
    {
		FocusOnContentCanvas.SetActive (false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isPause = true;

    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown (0) && isInSight && !isPause) {
			clickCount++;
		
			if (clickCount == 1) {
				alligneCameraToCOntentInSight1 ();


			}
			if (clickCount == 2) {
				alligneCameraToCOntentInSight2 ();
			}
			if (clickCount == 3) {
				alligneCameraToCOntentInSight3 ();
			}
		}
        oldContentInSight = contentInSight;
		isInSight = setContentInSight();
        if (!contentInSight == oldContentInSight && clickCount != 2)
        {
            PauseMenuCanvas.GetComponent<PauseTagHandler>().setDisplayContent(contentInSight);
            RuntimeTagCanvas.GetComponent<RuntimeTagHandler>().setDisplayContent(contentInSight);
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

    }


	public bool setContentInSight(){
		
		Ray raycheck = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));

		RaycastHit hitcheck;
		
		if (Physics.Raycast (raycheck, out hitcheck, 50f) && hitcheck.collider.gameObject.GetComponent<Content>() != null) {
            contentInSight = hitcheck.collider.gameObject.GetComponent<Content>();
			target.transform.position = hitcheck.collider.gameObject.transform.position;
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
					FocusOnContentCanvas.SetActive(true);
					mainCamera.transform.position = new Vector3 (contentInSight.transform.position.x + 0.01f , contentInSight.transform.position.y  + 35.0f, contentInSight.transform.position.z); 
					SimKeeper.instance.adjustThreshold (14.0f);
	}
	private void alligneCameraToCOntentInSight2 (){
		RuntimeTagCanvas.SetActive(false);
	}

	private void alligneCameraToCOntentInSight3 (){
					clickCount = 0;
					FocusOnContentCanvas.SetActive(false);
					RuntimeTagCanvas.SetActive(true);
					SimKeeper.instance.adjustThreshold (3.0f);
	}

}



