﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class RuntimeTagHandler : MonoBehaviour {

    public GameObject RTTagPrefab;
    public Transform RTPrefabContainerPanel;
    public GameObject RTTagPrefabOther;
    private List<GameObject> runtimeTagList = new List<GameObject>();
	private List<string> otherList  = new List<string>();
	public static RuntimeTagHandler instance;


	// Use this for initialization
	void Start () {
		instance = this;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setDisplayContent(Content c)
    {
        if (c == null)
        {
            return;
        }
        foreach (GameObject runtimeTag in runtimeTagList)
        {
            GameObject.Destroy(runtimeTag);
        }
        runtimeTagList.Clear();
		runtimeTagList.Add (instantiateOtherRuntimeTag(c));

        Dictionary<string, int> tagDic = SimKeeper.instance.getTagDic();
        List<KeyValuePair<String, String>> displayList = getDisplayList(c);

        for (int i = 0; i < displayList.Count; i++)
        {
            string tagCount = "";
            tagCount = tagDic[displayList[i].Value].ToString();
			if (displayList[i].Key != "Student" && displayList[i].Key != "Phase" && displayList[i].Key != "Semester" && displayList[i].Key != "Objekttyp" && displayList[i].Key != "Jahr")
			{
                runtimeTagList.Add(instantiateRuntimeTag(displayList[i].Key, displayList[i].Value, tagCount));
            }
        }
    }

	private GameObject instantiateOtherRuntimeTag(Content contentInSight2)
    {


        GameObject tag = Instantiate(RTTagPrefabOther);
        tag.transform.SetParent(RTPrefabContainerPanel, false);
        Dictionary<string, GameObject> childGameObjects = getChildDictOther(tag);

		List<string> otherlist  = getDisplayListOther(contentInSight2);

		childGameObjects["TextStudent"].GetComponent<Text>().text = otherlist[0];
		childGameObjects["TextSemester"].GetComponent<Text>().text = otherlist[1];
		childGameObjects["TextPhase"].GetComponent<Text>().text = otherlist[2];
		childGameObjects["TextJahr"].GetComponent<Text>().text = otherlist[3];
		childGameObjects["TextObjekttyp"].GetComponent<Text>().text = otherlist[4];

        return tag;
    }

    private GameObject instantiateRuntimeTag(string key, string value, string count)
    {

        GameObject tag = Instantiate(RTTagPrefab);
        tag.transform.SetParent(RTPrefabContainerPanel, false);

        Dictionary<string, GameObject> childGameObjects = getChildDict(tag);
        childGameObjects["TextTagKey"].GetComponent<Text>().text = key;
        childGameObjects["TextTagValue "].GetComponent<Text>().text = value;
        childGameObjects["TextTagCount"].GetComponent<Text>().text = count;


        return tag;
    }

    private Dictionary<string, GameObject> getChildDict(GameObject runtimeTag)
    {
        Dictionary<string, GameObject> childGameObjects = new Dictionary<string, GameObject>();
        foreach (Transform t in runtimeTag.transform)
        {
            childGameObjects.Add(t.name, t.gameObject);
        }
        return childGameObjects;
    }

	private Dictionary<string, GameObject> getChildDictOther(GameObject runtimeTagOther)
	{
		Dictionary<string, GameObject> childGameObjects = new Dictionary<string, GameObject>();
		foreach (Transform t in runtimeTagOther.transform)
		{
			childGameObjects.Add(t.name, t.gameObject);
		}
		return childGameObjects;
	}


    private List<KeyValuePair<string, string>> getDisplayList(Content contentInSight)
    {

        List<KeyValuePair<String, String>> displayList = new List<KeyValuePair<String, String>>();

        if (contentInSight.Student != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Student", contentInSight.Student);
			displayList.Add(curTag);
        }
        if (contentInSight.Semester != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Semester", contentInSight.Semester);
			displayList.Add(curTag);
        }
        if (contentInSight.Phase != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Phase", contentInSight.Phase);
			displayList.Add(curTag);
        }
        if (contentInSight.Year != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Jahr", contentInSight.Year);
			displayList.Add(curTag);
        }
        if (contentInSight.Objecttype != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Objekttyp", contentInSight.Objecttype);
			displayList.Add(curTag);
        }
        if (contentInSight.Titel != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Titel", contentInSight.Titel);
            displayList.Add(curTag);
        }
        if (contentInSight.Untertitel != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Untertitel", contentInSight.Untertitel);
            displayList.Add(curTag);
        }
        if (contentInSight.Autor != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Autor", contentInSight.Autor);
            displayList.Add(curTag);
        }
        if (contentInSight.Verortung != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Verortung", contentInSight.Verortung);
            displayList.Add(curTag);
        }
        if (contentInSight.UR != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Unterrichtung", contentInSight.UR);
            displayList.Add(curTag);
        }
        if (contentInSight.PUR != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Präzisierung", contentInSight.PUR);
            displayList.Add(curTag);
        }
        if (contentInSight.Tag0 != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Keywords", contentInSight.Tag0);
            displayList.Add(curTag);
        }
        if (contentInSight.Tag1 != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag1);
            displayList.Add(curTag);
        }
        if (contentInSight.Tag2 != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag2);
            displayList.Add(curTag);
        }
        if (contentInSight.Tag3 != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag3);
            displayList.Add(curTag);
        }
        if (contentInSight.Tag4 != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag4);
            displayList.Add(curTag);
        }
        if (contentInSight.Tag5 != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag5);
            displayList.Add(curTag);
        }
        if (contentInSight.Tag6 != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag6);
            displayList.Add(curTag);
        }
        if (contentInSight.Tag7 != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag7);
            displayList.Add(curTag);
        }
        if (contentInSight.Tag8 != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag8);
            displayList.Add(curTag);
        }
        if (contentInSight.Tag9 != "")
        {
            KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag9);
            displayList.Add(curTag);
        }

        return displayList;

    }

	private List<string> getDisplayListOther(Content contentInSight)
	{
		
		List<String> displayListOther = new List<String>();

		if (contentInSight.Student != "")
		{
			displayListOther.Add(contentInSight.Student);
		}
		if (contentInSight.Semester != "")
		{
			displayListOther.Add(contentInSight.Semester);;
		}
		if (contentInSight.Phase != "")
		{
			displayListOther.Add(contentInSight.Phase);;
		}
		if (contentInSight.Year != "")
		{
			displayListOther.Add(contentInSight.Year);
		}
		if (contentInSight.Objecttype != "")
		{
			displayListOther.Add(contentInSight.Objecttype);
		}

		
		return displayListOther;
		
	}


}
