using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SunView : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void alignContents(List<Content> contentList)
    {
        alignSpiral(contentList);
    }

    private void alignSpiral(List<Content> contentList)
    {
        Spiral spiral = new Spiral();
        int i = 0;
        foreach (Content content in contentList)
        {
            content.transform.position = spiral.getPosForElement(i);
            i++;
        }
    }
    public void alignSpiralRotate(List<Content> contentList)
    {
        Spiral spiral = new Spiral(new Vector3(0f,0f,0f), 45f);
        int i = 0;
        foreach (Content content in contentList)
        {
            content.transform.position = spiral.getPosForElement(i);
            i++;
        }
    }

}
