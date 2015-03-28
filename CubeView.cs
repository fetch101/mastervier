﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeView : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void alignContents(List<Content> contents)
    {

        int numberOfContents = contents.Count;
        int cubeDegree = getCubeDegree(numberOfContents);
        int i = 0;
        for (int x = 0; x < cubeDegree; x++)
        {
            for (int y = 0; y < cubeDegree; y++)
            {

                for (int z = 0; z < cubeDegree; z++)
                {
                    Vector3 pos = new Vector3(x * 100, y * 100, z * 100);
                    if (i < contents.Count)
                    {
                        contents[i].gameObject.transform.position = pos;
                        i++;
                    }

                }
            }
        }
    }

    private int getCubeDegree(int numberOfContents)
    {
        //TODO round degree to next higher int 
        float degree = Mathf.Pow(numberOfContents, 1f / 3f);
        return (int)degree + 1;
    }
}