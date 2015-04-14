using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SunView : MonoBehaviour {

    List<Content> studentListYearSem;
    List<List<Content>> semCircle = new List<List<Content>>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void alignContents(List<Content> contentList)
    {
        while (contentList.Count > 0)
        {
            string currStudent = contentList[0].Student;
            studentListYearSem = contentList.FindAll(content => content.Student == currStudent);
            contentList.RemoveAll(content => content.Student == currStudent);
            semCircle.Add(studentListYearSem);
        }

        float xOffset = 100;
        foreach (List<Content> studentList in semCircle)
        {
            alignSpiral(studentList, new Vector3(0f+xOffset,0f,0f), 0f);
            xOffset += 200;
        }

    }

    private void alignSpiralOld(List<Content> contentList)
    {
        Spiral spiral = new Spiral();
        int i = 0;
        foreach (Content content in contentList)
        {
            content.transform.position = spiral.getPosForElement(i);
            i++;
        }
    }
    public void alignSpiral(List<Content> contentList, Vector3 startPosition, float rotation)
    {
        Spiral spiral = new Spiral(startPosition, rotation);
        int i = 0;
        foreach (Content content in contentList)
        {
            content.transform.position = spiral.getPosForElement(i);
            i++;
        }
    }

}
