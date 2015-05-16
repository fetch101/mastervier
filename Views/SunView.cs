﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SunView : MonoBehaviour {

    List<Content> studentListYearSem;
    List<List<Content>> semCircle = new List<List<Content>>();
    List<GameObject> lineList = new List<GameObject>();
    List<GameObject> studentNameList = new List<GameObject>();
    public GameObject studentNamePrefab;


    public Material spiralLine;
    public float spiralLineWidth;

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
            studentListYearSem.Sort((x, y) => x.phaseNumber.CompareTo(y.phaseNumber));
            semCircle.Add(studentListYearSem);
        }

        SunCircle circle = new SunCircle(new Vector3(0f, 0f, 0f), semCircle.Count);
        
        int i = 0;
        foreach (List<Content> studentList in semCircle)
        {
            Vector3 circleStart = circle.getPosForElement(0);
            alignSpiral(studentList, circleStart, circle.getRotationForElement(i));
            i++;
        }
    }


    public void alignSpiral(List<Content> contentList, Vector3 circleStart, float rotation)
    {
        int i = 0;
        GameObject lineObj = new GameObject();
        LineRenderer line = lineObj.AddComponent<LineRenderer>();
        line.SetVertexCount(contentList.Count);
        line.SetWidth(spiralLineWidth, spiralLineWidth);
        line.material = spiralLine;

        Spiral spiral = new Spiral(circleStart);
        foreach (Content content in contentList)
        {
            Vector3 pos = spiral.getPosForElement(i, rotation);
            content.moveTo(pos);
            if(i == 0){
                Vector3 namePos = new Vector3(pos.x, -40, pos.z);
                GameObject studentName = Instantiate(studentNamePrefab, namePos, Quaternion.Euler(-90, rotation, 0)) as GameObject;
                studentName.GetComponent<TextMesh>().text = content.Student;
                studentNameList.Add(studentName);
            }
            line.SetPosition(i, pos);
            lineList.Add(lineObj);
            i++;
        }

    }


    public void destroyLines()
    {
        foreach (GameObject line in lineList)
        {
            GameObject.Destroy(line);
        }
        lineList.Clear();
        foreach (GameObject studentName in studentNameList)
        {
            GameObject.Destroy(studentName);
        }
        studentNameList.Clear();
    }

   
}
