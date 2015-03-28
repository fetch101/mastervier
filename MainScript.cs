using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainScript : MonoBehaviour {
    

    private bool isPause;

    // Use this for initialization
	void Start () {
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

  

    	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = togglePause();
        }
	
	}

    void OnGUI()
    {
        if (isPause) {
            GUILayout.Label("Game is paused!");
            if (GUILayout.Button("Line View"))
                getOrderKeeper().GetComponent<LineView>().alignContents(getAllContents());
            if (GUILayout.Button("Cube View"))
                getOrderKeeper().GetComponent<CubeView>().alignContents(getAllContents());
            if (GUILayout.Button("Circle View"))
                getOrderKeeper().GetComponent<CircleView>().alignContents(getAllContents()[0]);
            if (GUILayout.Button("Spiral View"))
                getOrderKeeper().GetComponent<SunView>().alignContents(getAllContents());
            if (GUILayout.Button("Close"))
                isPause = togglePause();
        }
    }

    private GameObject getOrderKeeper()
    {
        GameObject objectOrderKeeper = GameObject.Find("OrderKeeper");
        return objectOrderKeeper;
    }

  

    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            this.GetComponent<MouseLook>().isPause = false;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            this.GetComponent<MouseLook>().isPause = true;
            return (true);
        }
    }

    
}
