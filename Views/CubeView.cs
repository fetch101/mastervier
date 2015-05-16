using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CubeView : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void alignContents(List<Content> contents)
    {
        shuffleList(contents);

        int numberOfContents = contents.Count;
        int cubeDegree = getCubeDegree(numberOfContents);
        int i = 0;
        for (int x = 0; x < cubeDegree; x++)
        {
            for (int y = 0; y < cubeDegree; y++)
            {

                for (int z = 0; z < cubeDegree; z++)
                {
                    Vector3 pos = new Vector3(x * 100 - 400, y * 100 - 400, z * 100 - 400);
                    if (i < contents.Count)
                    {
                        contents[i].moveTo(pos);
                        i++;
                    }

                }
            }
        }
    }

    private void shuffleList(List<Content> contents)
    {
        for (int i = 0; i < contents.Count; i++)
        {
            Content temp = contents[i];
            int randomIndex = UnityEngine.Random.Range(i, contents.Count);
            contents[i] = contents[randomIndex];
            contents[randomIndex] = temp;
        }
    }

    private int getCubeDegree(int numberOfContents)
    {

        double degree = Mathf.Pow(numberOfContents, 1f / 3f);
        int roundedDegree = (int)Math.Round(degree, MidpointRounding.AwayFromZero);
        return degree > roundedDegree ? roundedDegree + 1 : roundedDegree;
    }

}
