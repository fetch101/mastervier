using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class FilteredView : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void alignContents(List<Content> filteredContents)
    {
        List<Content> notFilteredContents = getAllContents();
        notFilteredContents.RemoveAll(content => filteredContents.Contains(content));

        moveToSquare(filteredContents);
        moveAway(notFilteredContents);
    }

    private void moveAway(List<Content> notFilteredContents)
    {
        foreach (Content content in notFilteredContents)
        {
            content.moveTo(new Vector3(0, 150, 0));
        }
    }

    private void moveToSquare(List<Content> filteredContents)
    {
        float degree = getSquareDegree(filteredContents.Count);
		float startX = degree * (-30);
		float startY = degree * (-30);
        int i = 0;
        for(float x = 0; x < degree; x++)
        {
            for (float z = 0; z < degree; z++)
            {
                Vector3 pos = new Vector3((startX + (x*60f)), 0f, (startY + (z*60f)));
                if (i < filteredContents.Count)
                {
                    filteredContents[i].moveTo(pos);
                    i++;
                }
            }
        }
    }

    private int getSquareDegree(int numberOfContents)
    {
        double degree = Mathf.Pow(numberOfContents, 1f / 2f);
        int roundedDegree = (int)Math.Round(degree, MidpointRounding.AwayFromZero);
        return degree > roundedDegree ? roundedDegree + 1 : roundedDegree;
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
