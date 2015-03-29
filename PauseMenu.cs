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
        getOrderKeeper().GetComponent<CubeView>().alignContents(getAllContents());
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
                getOrderKeeper().GetComponent<LineView>().alignContents(getAllContents());
            if (GUILayout.Button("Cube View"))
                getOrderKeeper().GetComponent<CubeView>().alignContents(getAllContents());
            if (GUILayout.Button("Circle View"))
                getOrderKeeper().GetComponent<CircleView>().alignContents(GameObject.Find("DarioSala_p5_12").GetComponent<Content>());
            if (GUILayout.Button("Spiral View"))
                getOrderKeeper().GetComponent<SunView>().alignContents(getAllContents());
            if (GUILayout.Button("Rotated Spiral View"))
                getOrderKeeper().GetComponent<SunView>().alignSpiralRotate(getAllContents());
            if (GUILayout.Button("Wordcloud"))
                getOrderKeeper().GetComponent<WordCloud>().drawCloud(getAllContents());
            //if (GUILayout.Button("Close"))
            //    isPause = togglePause();
            //TODO Who shoud to this? pause menu oder simkeeper? also who sets startvalue?
            int thresholdOld = threshold;
            threshold = (int)GUI.VerticalSlider(new Rect(1200, 25, 100, 300), (float)threshold, 10.0F, 0.0F);
            if (thresholdChanged(threshold, thresholdOld))
            {
                SimKeeper.instance.thresholdChanged(threshold);
            }
           

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
