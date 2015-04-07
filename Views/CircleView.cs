using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CircleView : MonoBehaviour {

    private List<GameObject> lineList = new List<GameObject>();
    private List<float> radList = new List<float>();
    private Content center;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

 
    //public void alignContentsWithCenter(Content center)
    //{
    //    List<KeyValuePair<Content, int>> simList = getSimKeeper().getSimListForContent(center);
    //    float currRadius = 0;
    //    center.transform.position = new Vector3(0f, 0f, 0f);

    //    while (simList.Count > 0)
    //    {
    //        int currValue = simList[0].Value;
    //        List<Content> currContentCircle = getAndRemoveAllContentsWithValue(simList, currValue);
    //        currRadius = setNewRadius(currRadius, currContentCircle);
    //        Circle circle = new Circle(currRadius, currContentCircle.Count);
    //        radList.Add(currRadius);

    //        for (int i = 0; i < currContentCircle.Count; i++ )
    //        {
    //            currContentCircle[i].transform.position = circle.getPosForElement(i);
    //        }
    //    }

              
    //}


    //TODO fix start double offset and end too close objects
    public void alignContentsWithCenter(Content center)
    {
        List<KeyValuePair<Content, int>> simList = getSimKeeper().getSimListForContent(center);
        float currRadius = 0;
        center.transform.position = new Vector3(0f, 0f, 0f);
        
        while (simList.Count > 0)
        {
            int currValue = simList[0].Value;
            List<Content> currContentCircle = getAndRemoveAllContentsWithValue(simList, currValue);
            currRadius = setNewRadius(currRadius, currContentCircle);
            Circle circle = new Circle(currRadius, 60f);
            radList.Add(currRadius);
            for (int i = 0; i < currContentCircle.Count; i++)
            {
                currContentCircle[i].transform.position = circle.getNextPos();
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
        Debug.Log("Draw circle with radius: " + currRadius);
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

    private void drawCircleLine(float radius)
    {
        GameObject circleLine = new GameObject();
        LineRenderer lineRenderer = circleLine.AddComponent<LineRenderer>();
        float theta_scale = 0.1f;
        int size = (int)((2.0 * Mathf.PI) / theta_scale) + 1;


        lineRenderer.SetWidth(0.2F, 0.2F);
        lineRenderer.SetVertexCount(size + 1);

        int i = 0;

        for (float theta = 0; theta < 2 * Mathf.PI; theta += theta_scale)
        {
            float x = radius * Mathf.Cos(theta);
            float y = radius * Mathf.Sin(theta);

            Vector3 pos = new Vector3(x, y, 0);
            lineRenderer.SetPosition(i, pos);
            if (i == 0)
            {
                lineRenderer.SetPosition(size, pos);
            }
            i += 1;
        }
        lineList.Add(circleLine);
    }

    public void drawLines()
    {
        foreach (float rad in radList)
        {
            drawCircleLine(rad);
        }
    }

    public void destroyLines()
    {
        foreach (GameObject lineRenderer in lineList)
        {
            GameObject.Destroy(lineRenderer);
        }
        lineList.RemoveRange(0, lineList.Count);
        radList.RemoveRange(0, radList.Count);
    }

}
