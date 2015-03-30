using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewKeeper : MonoBehaviour {

    public static ViewKeeper instance;
    private IView currentView;

	// Use this for initialization
	void Start () {
        instance = this;
        currentView = this.GetComponent<CubeView>();
        changeCurrentView(this.GetComponent<CubeView>());
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void circleView(Content center)
    {
        CircleView circleView = this.GetComponent<CircleView>();
        circleView.setCenter(center);
        changeCurrentView(circleView);
    }

    public void cubeView()
    {
        changeCurrentView(this.GetComponent<CubeView>());
    }

    public void lineView()
    {
        changeCurrentView(this.GetComponent<LineView>());
    }


    public void sunView()
    {
        changeCurrentView(this.GetComponent<SunView>());
    }

    public void wordCloud()
    {
        this.GetComponent<WordCloud>().drawCloud(getAllContents());
    }

    public void alignSpiralRotate()
    {
        this.GetComponent<SunView>().alignSpiralRotate(getAllContents());
    }

    private void changeCurrentView(IView newView)
    {
        currentView.destroyLines();
        currentView = newView;
        currentView.alignContents(getAllContents());
        currentView.drawLines();
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
