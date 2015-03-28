using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OrderKeeper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //TODO refactor this
    //TODO call this when similarities change
    public void alignContentInCircleWithCenter(Content centerContent)
    {
        SimKeeper simKeeper = getSimKeeper();
        List<KeyValuePair<Content, int>> simList = simKeeper.getSimListForContent(centerContent);
        float currRad = 60;
        Vector3 currPos = new Vector3(0f, 0f, 0f);
        centerContent.transform.position = currPos;
        int sameScore = 1;
        //TODO content with no similarities has an empty simList


        int currScore = simList[0].Value;
        int circlePos = 1;

        while (simList[sameScore].Value == currScore)
        {
            sameScore++;
        }
        //TODO make sure all elements have enough space on currRad


        Circle circle = new Circle(currRad, sameScore);

        for (int i = 0; i < simList.Count; i++)
        {
            currPos = circle.getPosForElement(circlePos);
            simList[i].Key.transform.position = currPos;
            circlePos++;

            if (i + 1 < simList.Count && simList[i + 1].Value != currScore)
            {
                sameScore = 1;
                currScore = simList[i + 1].Value;
                while (i + sameScore + 1 < simList.Count && simList[i + sameScore + 1].Value == currScore)
                {
                    sameScore++;
                }

                if (getMinRadius(sameScore) > currRad + 60)
                {
                    currRad = getMinRadius(sameScore);
                }
                else
                {
                    currRad += 60;
                }

                circle = new Circle(currRad, sameScore);
                circlePos = 1;

            }

        }
    }

    private float getMinRadius(int numberOfElements)
    {
        return (numberOfElements * 60) / (2 * Mathf.PI);
    }


    public void alignContentsInLine()
    {
        List<Content> contentList = getAllContents();
        Vector3 start = new Vector3(0f, 0f, 0f);
        foreach (Content cont in contentList)
        {
            cont.gameObject.transform.position = start;
            start.z += 60;
        }
    }


    public void alignContentsInCube()
    {
        List<Content> contents = getAllContents();
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

    public void alignContentsAsSun()
    {
        alignSpiral();

    }

    private void alignSpiral()
    {
        List<Content> contentList = getAllContents();
        Spiral spiral = new Spiral();
        int i = 0;
        foreach (Content content in contentList)
        {
            content.transform.position = spiral.getPosForElement(i);
            i++;
        }
    }


    private List<Content> getAllContents()
    {
        Object[] objectContents = FindObjectsOfType(typeof(Content));

        List<Content> contentList = new List<Content>();
        foreach (Object obj in objectContents)
        {
            contentList.Add((Content)obj);
        }
        return contentList;
    }


    private SimKeeper getSimKeeper()
    {
        Object[] objectSimKeeper = FindObjectsOfType(typeof(SimKeeper));
        return (SimKeeper)objectSimKeeper[0];
    }
}
