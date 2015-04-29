using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Filter : MonoBehaviour {

    private List<String> andList = new List<String>();
    private List<String> orList = new List<String>();

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
        Debug.Log("cleared filter");
    }
}
