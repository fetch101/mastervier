﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewKeeper : MonoBehaviour {
	public bool FilterViewIsActive = false;

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
		FilterViewIsActive = false;

        this.GetComponent<CircleView>().destroyLines();
        this.GetComponent<CircleView>().alignContentsWithCenter(center);
        this.GetComponent<CircleView>().drawLines(center);
    }

    public void cubeView()
    {
		FilterViewIsActive = false;

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
		FilterViewIsActive = false;

        this.GetComponent<CircleView>().destroyLines();
        this.GetComponent<SunView>().alignContents(getAllContents());
    }

    public void wordCloud()
    {
        this.GetComponent<WordCloud>().drawCloud(getAllContents());
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



    public void filteredView(List<Content> filteredContents)
    {
		FilterViewIsActive = true;

        this.GetComponent<CircleView>().destroyLines();
        this.GetComponent<FilteredView>().alignContents(filteredContents);
    }
}
