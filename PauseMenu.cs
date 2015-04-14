using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour {

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();
        }

    }

    void OnGUI()
    {
        if (isPause)
        {
			
					Ray raycheck = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
					
					RaycastHit hitcheck;
			
					if (Physics.Raycast (raycheck, out hitcheck, 40f) && hitcheck.collider.gameObject.GetComponent<Content> () != null) {
			
					Content objectToDisplayTags = hitcheck.collider.gameObject.GetComponent<Content>();
			
			
				}





            GUILayout.Label("Game is paused!");
            if (GUILayout.Button("Line View"))
                ViewKeeper.instance.lineView();
            if (GUILayout.Button("Cube View"))
                ViewKeeper.instance.cubeView();
            if (GUILayout.Button("Circle View"))

				//TODO: "DarioSala_p5_12" mit dem GameObject vom Pickup Script ersetzen

					ViewKeeper.instance.circleView(hitcheck.collider.gameObject.GetComponent<Content>());
            if (GUILayout.Button("Spiral View"))
                ViewKeeper.instance.sunView();
            if (GUILayout.Button("TEST Rotated Spiral View"))
                ViewKeeper.instance.alignSpiralRotate();
            if (GUILayout.Button("TEST Wordcloud"))
                ViewKeeper.instance.wordCloud();          

        }
    }

    private List<Content> getAllContents()
    {

        Object[] objectContents = FindObjectsOfType(typeof(Content));

        List<Content> contentList = new List<Content>();
        foreach (Object obj in objectContents)
        {
            contentList.Add((Content)obj);
        }
        return contentList;
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
        isPause = false;
    }

    private void setPause()
    {
        MouseLook.instance.enabled = false;
        Spectator.instance.enabled = false;
        SimKeeper.instance.enabled = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isPause = true;
    }
}
