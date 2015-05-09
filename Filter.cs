using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class Filter : MonoBehaviour {

	public Text mustTagsText;
	public Text canTagsText;
    public Text NumberOfFilteredElementsNumber;

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
	}

    public void addAnd(string value)
    {
        mustList.Add(value);
        calculateFilteredContents();
        displayFilterElements();
    }

    public void addOr(string value)
    {
        canList.Add(value);
        calculateFilteredContents();
        displayFilterElements();
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
        displayFilterElements();
    }

    public void applyFilter()
    {
        calculateFilteredContents();

        foreach (Content content in filteredContents)
        {
            content.shouldAlign = false;
            content.transform.rotation = Quaternion.LookRotation(Vector3.up);
        }

        ViewKeeper.instance.filteredView(filteredContents);

    }

    private void calculateFilteredContents()
    {
        filteredContents.Clear();
        List<Content> contents = getAllContents();

        foreach (Content content in contents)
        {
            if (contentContainsAllAndStrings(content))
            {
                if (contentContainsOrString(content))
                {
                    filteredContents.Add(content);
                }
            }

        }
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

        mustTagsText.text = mustString;
        canTagsText.text = canString;
        NumberOfFilteredElementsNumber.text = filteredContents.Count.ToString();

    }
}
