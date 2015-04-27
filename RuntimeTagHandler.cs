using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class RuntimeTagHandler : MonoBehaviour {

    public GameObject RTTagPrefab;
    public Transform RTPrefabContainerPanel;
    private List<GameObject> runtimeTagList = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setDisplayContent(Content c)
    {
        foreach (GameObject runtimeTag in runtimeTagList)
        {
            GameObject.Destroy(runtimeTag);
        }
        runtimeTagList.Clear();
        List<KeyValuePair<String, String>> displayList = getDisplayList(c);
        for (int i = 0; i < displayList.Count; i++)
        {
            runtimeTagList.Add(instantiateRuntimeTag(displayList[i].Key, displayList[i].Value, "500"));
        }
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

}
