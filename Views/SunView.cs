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
        semCircle = new List<List<Content>>();
        while (contentList.Count > 0)
        {
            string currStudent = contentList[0].Student;
            studentListYearSem = contentList.FindAll(content => content.Student == currStudent);
            contentList.RemoveAll(content => content.Student == currStudent);
            semCircle.Add(studentListYearSem);
        }

        SunCircle circle = new SunCircle(50f, new Vector3(0f, 0f, 0f), semCircle.Count);
        int i = 0;
        foreach (List<Content> studentList in semCircle)
        {
            alignSpiral(studentList, circle.getPosForElement(i), circle.getRotationForElement(i));
            i++;
        }
    }


    public void alignSpiral(List<Content> contentList, Vector3 startPosition, float rotation)
    {
        Spiral spiral = new Spiral(startPosition, rotation);
        int i = 0;
        GameObject lineObj = new GameObject();
        LineRenderer line = lineObj.AddComponent<LineRenderer>();
        line.SetVertexCount(contentList.Count);
        foreach (Content content in contentList)
        {
            content.transform.position = spiral.getPosForElement(i);
            //TODO move rotation to spiral for content.moveTo() call
            content.transform.RotateAround(startPosition, Vector3.up, rotation);
           
            line.SetPosition(i, content.transform.position);
            i++;
        }
    }

}
