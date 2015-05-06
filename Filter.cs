using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class Filter : MonoBehaviour {

	public Text mustTags;
	public Text canTags;
	private string filterContains;

    private List<String> mustList = new List<String>();
    private List<String> canList = new List<String>();
    private List<Content> filteredContents = new List<Content>();

    public static Filter instance;

	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        displayFilterElements();
	
	}

    private void displayFilterElements(List<string> andList)
    {
        throw new NotImplementedException();
    }

    public void addAnd(string value)
    {
        mustList.Add(value);
    }

    public void addOr(string value)
    {
        canList.Add(value);
    }

    public void removeFilter()
    {

        foreach (Content content in filteredContents)
        {
            content.shouldAlign = true;
        }
        mustList.Clear();
        canList.Clear();
        filteredContents.Clear();
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

        foreach (Content content in filteredContents)
        {
            content.shouldAlign = false;
            content.transform.rotation = Quaternion.LookRotation(Vector3.up);
        }

        ViewKeeper.instance.filteredView(filteredContents);

    }

    private bool contentContainsOrString(Content content)
    {
        if (canList.Count == 0)
        {
            return true;
        }
        foreach (String orString in canList)
        {
            if (content.contains(orString.ToLower()))
            {
                return true;
            }
        }
        return false;
    }

    private bool contentContainsAllAndStrings(Content content)
    {
        if (mustList.Count == 0)
        {
            return true;
        }
        foreach (String andString in mustList)
        {
            if (!content.contains(andString.ToLower()))
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


    private void displayFilterElements()
    {
        string mustString = "";
        string canString = "";
        int count = 1;
        foreach (string must in mustList)
        {
            mustString += must;
            if (count < mustList.Count)
            {
                mustString += ", ";
            }
            count++;
        }
        count = 1;
        foreach (string can in canList)
        {
            canString += can; 
            if (count < canList.Count)
            {
                canString += ", ";
            }
            count++;
        }

        mustTags.text = mustString;
        canTags.text = canString;

    }
}
