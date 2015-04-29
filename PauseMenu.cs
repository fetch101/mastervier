using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;



public class PauseMenu : MonoBehaviour {

	private bool isInSight = false;

	Content contentInSight;
    Content oldContentInSight;

    public GameObject RuntimeTagCanvas;
	public GameObject PauseMenuCanvas;

    private bool isPause;

    // Use this for initialization
    void Start()
    {

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isPause = true;

    }

    // Update is called once per frame
    void Update()
    {

        oldContentInSight = contentInSight;
		isInSight = setContentInSight();

        if (!contentInSight == oldContentInSight)
        {
            PauseMenuCanvas.GetComponent<PauseTagHandler>().setDisplayContent(contentInSight);
        }

        if (isInSight)
        {
            if (!contentInSight.Equals(oldContentInSight))
            {
                RuntimeTagCanvas.GetComponent<RuntimeTagHandler>().setDisplayContent(contentInSight);
                RuntimeTagCanvas.SetActive(true);
            }

        }else{
            RuntimeTagCanvas.SetActive(false);
        }
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();

		}

        if (Input.GetKeyDown(KeyCode.C) && isInSight)
        {
            ViewKeeper.instance.circleView(contentInSight);
        }

    }


	public bool setContentInSight(){
		
		Ray raycheck = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));

		RaycastHit hitcheck;
		
		if (Physics.Raycast (raycheck, out hitcheck, 40f) && hitcheck.collider.gameObject.GetComponent<Content>() != null) {
            contentInSight = hitcheck.collider.gameObject.GetComponent<Content>();
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
		RuntimeTagCanvas.SetActive (true);

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

}
