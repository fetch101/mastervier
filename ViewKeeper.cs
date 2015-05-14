using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewKeeper : MonoBehaviour {

    public static ViewKeeper instance;
    public bool circleIsActive = false;

	// Use this for initialization
	void Start () {
        instance = this;
        this.GetComponent<CubeView>().alignContents(getAllContents());
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void circleView(Content center)
    {
        circleIsActive = true;
        SimKeeper.instance.setAllLines(true);
        Filter.instance.removeFilter();
        if (PauseMenu.instance.focusModeOn)
        {
            PauseMenu.instance.alligneCameraToCOntentInSight3();
        } 
        this.GetComponent<CircleView>().destroyLines();
        this.GetComponent<CircleView>().alignContentsWithCenter(center);
        this.GetComponent<CircleView>().drawLines(center);
    }

    public void cubeView()
    {
        circleIsActive = false;
        SimKeeper.instance.setAllLines(true);
        Filter.instance.removeFilter();
        if (PauseMenu.instance.focusModeOn)
        {
            PauseMenu.instance.alligneCameraToCOntentInSight3();
        }
        this.GetComponent<CircleView>().destroyLines();
        this.GetComponent<CubeView>().alignContents(getAllContents());
    }

    public void sunView()
    {
        circleIsActive = false;
        SimKeeper.instance.setAllLines(true);
        Filter.instance.removeFilter();
        if (PauseMenu.instance.focusModeOn)
        {
            PauseMenu.instance.alligneCameraToCOntentInSight3();
        } 
        this.GetComponent<CircleView>().destroyLines();
        this.GetComponent<SunView>().alignContents(getAllContents());
    }

    public void filteredView(List<Content> filteredContents)
    {
        circleIsActive = false;
        SimKeeper.instance.setAllLines(false);
        if (PauseMenu.instance.focusModeOn)
        {
            PauseMenu.instance.alligneCameraToCOntentInSight3();
        } 
        this.GetComponent<CircleView>().destroyLines();
        this.GetComponent<FilteredView>().alignContents(filteredContents);
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

}
