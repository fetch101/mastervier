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

            GUILayout.Label("Game is paused!");
            if (GUILayout.Button("Line View"))
                ViewKeeper.instance.lineView();
            if (GUILayout.Button("Cube View"))
                ViewKeeper.instance.cubeView();
            if (GUILayout.Button("Spiral View"))
                ViewKeeper.instance.sunView();
            if (GUILayout.Button("TEST Rotated Spiral View"))
                ViewKeeper.instance.alignSpiralRotate();
            if (GUILayout.Button("TEST Wordcloud"))
                ViewKeeper.instance.wordCloud();
            if (GUILayout.Button("TEST Highlight DarioSala"))
                Highlighter.instance.highlightContentFromStudent("DarioSala");
            if (GUILayout.Button("TEST Highlight AliceGut"))
                Highlighter.instance.highlightContentFromStudent("AliceGut");
            if (GUILayout.Button("TEST Remove Highlight"))
                Highlighter.instance.removeCurrentHighlight();     

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
        ContentManager.instance.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPause = false;
    }

    private void setPause()
    {
        MouseLook.instance.enabled = false;
        Spectator.instance.enabled = false;
        SimKeeper.instance.enabled = true;
        ContentManager.instance.enabled = false;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isPause = true;
    }
}
