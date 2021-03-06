﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class PauseTagHandler : MonoBehaviour
{

    public GameObject PauseTagPrefab;
    public Transform PausePrefabContainerPanel;
    private List<GameObject> pauseTagList = new List<GameObject>();
	public Text TextThresholdNumber;
	public Slider ThresholdSlider;
	public Text TextTagSliderNumber;
	public Slider TagSlider;
	public Text TextMetaTagSliderNumber;
	public Slider Metatagslider;
	public Text Tooltip0;
	public Text Tooltip1;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		displaySliderNumbers ();
    }

    public void setDisplayContent(Content c)
    {
        if (c == null)
        {
            return;
        }
        foreach (GameObject runtimeTag in pauseTagList)
        {
            GameObject.Destroy(runtimeTag);
        }
        pauseTagList.Clear();
        List<KeyValuePair<String, String>> displayList = getDisplayList(c);
        Dictionary<string, int> tagDic = SimKeeper.instance.getTagDic();
        for (int i = 0; i < displayList.Count; i++)
        {
            string tagCount = "";
                tagCount = tagDic[displayList[i].Value].ToString();
                pauseTagList.Add(instantiateRuntimeTag(displayList[i].Key, displayList[i].Value, tagCount));
        }
    }


    private GameObject instantiateRuntimeTag(string key, string value, string count)
    {

        GameObject tag = Instantiate(PauseTagPrefab);
        tag.transform.SetParent(PausePrefabContainerPanel, false);

        Dictionary<string, GameObject> childGameObjects = getChildDict(tag);
        childGameObjects["TextTagKey"].GetComponent<Text>().text = key;
        childGameObjects["TextTagValue "].GetComponent<Text>().text = value;
        childGameObjects["TextTagCount"].GetComponent<Text>().text = count;
        childGameObjects["Button 0"].GetComponent<Button>().onClick.AddListener(() => Highlighter.instance.highlightContent(key, value));
        childGameObjects["Button 1"].GetComponent<Button>().onClick.AddListener(() => Filter.instance.addOr(value));
        childGameObjects["Button 2"].GetComponent<Button>().onClick.AddListener(() => Filter.instance.addAnd(value));

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

	private void displaySliderNumbers(){

        TextThresholdNumber.text = Convert.ToString (ThresholdSlider.value);
        float tsv = TagSlider.value * 10;
        TextTagSliderNumber.text = Convert.ToString (tsv);
        float mtsv = Metatagslider.value * 10;
        TextMetaTagSliderNumber.text = Convert.ToString (mtsv);

	}

	public void displayTooltip0(){
		Tooltip0.text = "";
		Tooltip1.text = "";

	}
	public void displayTooltip1(){
		Tooltip0.text = 
			"Jedes Objekt ist mit verschiedenen Tags versehen." + "\n" +
			"Mit diesem Regler wird die Anzahl der benötigten" + "\n" +
			"übereinsitmmenden Tag's zweier Objekte festgelegt," + "\n" +
			"damit eine Linie zwischen ihnen gezeichnet wird";
	}
	public void displayTooltip2(){
		Tooltip0.text = 
			"Mit diesem regler wird Gewichtung "+ "\n" + 
			"der allgemeinen Tag's festgelegt." + "\n" +
			"Die Allgemeinen Tags sind:" + "\n" + "\n" +
			

				"Student" + "\n" +
				"Semester" + "\n" +
				"Jahr" + "\n" +
				"Phase" + "\n" +
				"Objekttyp" + "\n" +
				"Titel" + "\n" +
				"Autor" + "\n" +
				"Verortung";


//		"Mit diesem regler wird Gewichtung" + "\n" + 
//			"der allgemeinen Tag's festgelegt." + "\n" +
//				"Die Allgemeinen Tags sind:" + "\n" +
//				"Student / Semester / Jahr  " + "\n" +
//				"Phase / Objekttyp / Titel" + "\n" +
//				"Autor / Verortung";
	}

	public void displayTooltip3(){
		Tooltip0.text = 
				"Mit diesem regler wird Gewichtung der " + "\n" + 
				"Tag's «Keywords» festgelegt." ;
	}

	public void displayTooltip4(){
		Tooltip0.text = 
			"In der Studentenansicht werden alle Objekte" + "\n" +
			"nach den Studenten sortiert und angeordnet.";
	}

	public void displayTooltip5(){
		Tooltip0.text = 
			"In der Zufallsansicht werden alle" + "\n" +
			"Objekte zufällig angeordnet.";
	}

	public void displayTooltip6(){
		Tooltip1.text = 
			"Dies ist die Anzahl der Objekte," + "\n" +
			"welche ebenfalls mit diesem Tag" + "\n" +
			"versehen sind.";
	}

}
