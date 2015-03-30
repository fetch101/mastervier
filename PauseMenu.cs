using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour {

    private bool isPause;
    public int threshold = 3;

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
            GUILayout.Label("Game is paused!");
            if (GUILayout.Button("Line View"))
                ViewKeeper.instance.lineView();
            if (GUILayout.Button("Cube View"))
                ViewKeeper.instance.cubeView();
            if (GUILayout.Button("Circle View"))
                ViewKeeper.instance.circleView(GameObject.Find("DarioSala_p5_12").GetComponent<Content>());
            if (GUILayout.Button("Spiral View"))
                ViewKeeper.instance.sunView();
            if (GUILayout.Button("TEST Rotated Spiral View"))
                ViewKeeper.instance.alignSpiralRotate();
            if (GUILayout.Button("Wordcloud"))
                ViewKeeper.instance.wordCloud();
            //if (GUILayout.Button("Close"))
            //    isPause = togglePause();
            //TODO Who should to this? pause menu oder simkeeper? also who sets startvalue?
            int thresholdOld = threshold;
            threshold = (int)GUI.VerticalSlider(new Rect(1220, 25, 100, 300), (float)threshold, 10.0F, 0.0F);
            if (thresholdChanged(threshold, thresholdOld))
            {
                SimKeeper.instance.thresholdChanged(threshold);
            }
            GUI.Label(new Rect(Screen.width - 130, 25, 200, Screen.height), "Current Threshold: " + threshold);
           

        }
    }

    private bool thresholdChanged(int thresholdNew, int thresholdOld)
    {
        if (thresholdNew != thresholdOld)
        {
            threshold = thresholdNew;
            return true;
        }
        return false;
    }

    private GameObject getOrderKeeper()
    {
        GameObject objectOrderKeeper = GameObject.Find("OrderKeeper");
        return objectOrderKeeper;
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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPause = false;
    }

    private void setPause()
    {
        MouseLook.instance.enabled = false;
        Spectator.instance.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isPause = true;
    }
}
