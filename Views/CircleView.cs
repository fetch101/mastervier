using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CircleView : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    //TODO refactor this
    //TODO call this when similarities change
    public void alignContents(Content center)
    {
        SimKeeper simKeeper = getSimKeeper();
        List<KeyValuePair<Content, int>> simList = simKeeper.getSimListForContent(center);
        float currRad = 60;
        Vector3 currPos = new Vector3(0f, 0f, 0f);
        center.transform.position = currPos;
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

    private SimKeeper getSimKeeper()
    {
        Object[] objectSimKeeper = FindObjectsOfType(typeof(SimKeeper));
        return (SimKeeper)objectSimKeeper[0];
    }
}
