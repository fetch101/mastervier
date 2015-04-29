using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Filter : MonoBehaviour {

    private List<String> andList = new List<String>();
    private List<String> orList = new List<String>();
    private List<Content> filteredContents = new List<Content>();

    public static Filter instance;

	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addAnd(string value)
    {
        andList.Add(value);
        Debug.Log("Added " + value + " to AND filter");
    }

    public void addOr(string value)
    {
        orList.Add(value);
        Debug.Log("Added " + value + " to OR filter");
    }

    public void removeFilter()
    {
        andList.Clear();
        orList.Clear();
        filteredContents.Clear();
        Debug.Log("cleared filter");
    }

    public void applyFilter()
    {
        List<Content> contents = getAllContents();

        foreach(Content content in contents)
        {
            if (contentContainsAllAndStrings(content))
            {
                if (contentContainsOrString(content))
                {
                    filteredContents.Add(content);
                }
            }

        }

        Debug.Log("and count" + andList.Count);
        Debug.Log("or count" + orList.Count);
        Debug.Log("filtered contents count" + filteredContents.Count);

        foreach (Content c in filteredContents)
        {
            Debug.Log(c.name);
        }

    }

    private bool contentContainsOrString(Content content)
    {
        if (orList.Count == 0)
        {
            return true;
        }
        foreach (String orString in orList)
        {
            if (content.getCombinedTagsToLower().Contains(orString))
            {
                return true;
            }
        }
        return false;
    }

    private bool contentContainsAllAndStrings(Content content)
    {
        if (andList.Count == 0)
        {
            return true;
        }
        foreach (String andString in andList)
        {
            if (!content.getCombinedTagsToLower().Contains(andString))
            {
                return false;
            }
        }
        return true;
    }

    private List<Content> getAllContents()
    {

        UnityEngine.Object[] objectContents = FindObjectsOfType(typeof(Content));

        List<Content> contentList = new List<Content>();
        foreach (UnityEngine.Object obj in objectContents)
        {
            contentList.Add((Content)obj);
        }
        return contentList;
    }
}
