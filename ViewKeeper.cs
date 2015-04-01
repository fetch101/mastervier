using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewKeeper : MonoBehaviour {

    public static ViewKeeper instance;

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
        this.GetComponent<CircleView>().destroyLines();
        this.GetComponent<CircleView>().alignContentsWithCenter(center);
        this.GetComponent<CircleView>().drawLines();
    }

    public void cubeView()
    {
        this.GetComponent<CircleView>().destroyLines();
        this.GetComponent<CubeView>().alignContents(getAllContents());
    }

    public void lineView()
    {
        this.GetComponent<CircleView>().destroyLines();
        this.GetComponent<LineView>().alignContents(getAllContents());
    }


    public void sunView()
    {
        this.GetComponent<CircleView>().destroyLines();
        this.GetComponent<SunView>().alignContents(getAllContents());
    }

    public void wordCloud()
    {
        this.GetComponent<WordCloud>().drawCloud(getAllContents());
    }

    public void alignSpiralRotate()
    {
        this.GetComponent<CircleView>().destroyLines();
        this.GetComponent<SunView>().alignSpiralRotate(getAllContents());
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
