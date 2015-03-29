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

 
    //TODO update this if similarities change
    public void alignContents(Content center)
    {
        SimKeeper simKeeper = getSimKeeper();
        List<KeyValuePair<Content, int>> simList = simKeeper.getSimListForContent(center);
        float currRadius = 0;
        center.transform.position = new Vector3(0f, 0f, 0f);

        while (simList.Count > 0)
        {
            int currValue = simList[0].Value;
            List<Content> currContentCircle = getAndRemoveAllContentsWithValue(simList, currValue);
            currRadius = setNewRadius(currRadius, currContentCircle);
            Circle circle = new Circle(currRadius, currContentCircle.Count);

            for (int i = 0; i < currContentCircle.Count; i++ )
            {
                currContentCircle[i].transform.position = circle.getPosForElement(i);
            }
        }

              
    }

    private float setNewRadius(float currRadius, List<Content> currContentCircle)
    {
        if (getMinRadius(currContentCircle.Count) > currRadius)
        {
            currRadius = getMinRadius(currContentCircle.Count);
        }
        else
        {
            currRadius += 60;
        }
        return currRadius;
    }

    private float getMinRadius(int numberOfElements)
    {
        float minRad = (numberOfElements * 60) / (2 * Mathf.PI);
        return minRad >= 60 ? minRad : 60;
    }

    private List<Content> getAndRemoveAllContentsWithValue(List<KeyValuePair<Content, int>> simList, int value)
    {
        List<Content> sameValueList = new List<Content>();
        
        foreach (KeyValuePair<Content, int> pair in simList)
        {
            if (pair.Value >= value)
            {
                sameValueList.Add(pair.Key);
            }
            else
            {
                break;
            }
        }

        simList.RemoveAll(item => item.Value.Equals(value));
        
        return sameValueList;
    }

    private SimKeeper getSimKeeper()
    {
        Object[] objectSimKeeper = FindObjectsOfType(typeof(SimKeeper));
        return (SimKeeper)objectSimKeeper[0];
    }
}
