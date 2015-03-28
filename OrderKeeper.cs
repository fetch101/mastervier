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

    public void alignContentInCircleWithCenter(Content centerContent)
    {
        this.GetComponent<CircleView>().alignContents(centerContent);
    }

   
    public void alignContentsInLine()
    {
        this.GetComponent<LineView>().alignContents(getAllContents());
    }


    public void alignContentsInCube()
    {
        this.GetComponent<CubeView>().alignContents(getAllContents());
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

}
