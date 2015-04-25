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
        Vector3 circleStart = circle.getPosForElement(0);
        drawCircleLine(50f, new Vector3(0f, 0f, 0f));
        int i = 0;
        foreach (List<Content> studentList in semCircle)
        {
            alignSpiral(studentList, circleStart, circle.getRotationForElement(i));
            i++;
        }
    }


    public void alignSpiral(List<Content> contentList, Vector3 circleStart, float rotation)
    {
        Spiral spiral = new Spiral(circleStart);
        int i = 0;
        GameObject lineObj = new GameObject();
        LineRenderer line = lineObj.AddComponent<LineRenderer>();
        line.SetVertexCount(contentList.Count);
        foreach (Content content in contentList)
        {
            Vector3 unrotatedPos = spiral.getPosForElement(i);
            Vector3 rotatedPos = Quaternion.Euler(0, rotation, 0) * unrotatedPos;
            content.moveTo(rotatedPos);
            line.SetPosition(i, rotatedPos);
            i++;
        }
    }

    private void drawCircleLine(float radius, Vector3 center)
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
            float z = radius * Mathf.Sin(theta);

            Vector3 pos = new Vector3(center.x + x, center.y, center.z + z);
            lineRenderer.SetPosition(i, pos);
            if (i == 0)
            {
                lineRenderer.SetPosition(size, pos);
            }
            i += 1;
        }
    }

}
