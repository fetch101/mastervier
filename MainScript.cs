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
                alignContentsInLine();
            if (GUILayout.Button("Start Cube View"))
                alignContentsInCube();
            if (GUILayout.Button("Circle View"))
                alignContentsInCircleWithCenter(getAllContents()[0]);
            if (GUILayout.Button("Spiral View"))
                alignContentsAsSun();
            if (GUILayout.Button("Close"))
                isPause = togglePause();
        }
    }

    private OrderKeeper getOrderKeeper()
    {
        Object[] objectOrderKeeper = FindObjectsOfType(typeof(OrderKeeper));
        return (OrderKeeper)objectOrderKeeper[0];
    }

    //TODO move align methods to OrderKeeper
    private void alignContentsInLine()
    {
        getOrderKeeper().alignContentsInLine();
    }

    private void alignContentsInCube()
    {
        getOrderKeeper().alignContentsInCube();
    }

    private void alignContentsAsSun()
    {
        getOrderKeeper().alignContentsAsSun();
    }    

    private void alignContentsInCircleWithCenter(Content content)
    {
        getOrderKeeper().alignContentInCircleWithCenter(content);
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
