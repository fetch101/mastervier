using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SunView : MonoBehaviour {

    List<Content> studentListYearSem;
    List<List<Content>> semCircle = new List<List<Content>>();
    List<GameObject> lineList = new List<GameObject>();
    List<GameObject> studentNameList = new List<GameObject>();
    List<WordCloud> wordCloudList = new List<WordCloud>();
    public GameObject studentNamePrefab;
    public int namePositionNearFar = 10;
    public float namePositionUpDown = -60;


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
        Spiral spiral = new Spiral(circleStart);
        LineRenderer line = createLine(contentList.Count);
        createStudentName(contentList, rotation, spiral);
        createStudentCloud(contentList, rotation, spiral);
        foreach (Content content in contentList)
        {
            Vector3 pos = spiral.getPosForElement(i, rotation);
            content.moveTo(pos);
            
            line.SetPosition(i, pos);
            lineList.Add(line.gameObject);
            i++;
        }

    }

    private void createStudentCloud(List<Content> contentList, float rotation, Spiral spiral)
    {
        WordCloud studentCloud = new WordCloud();
        studentCloud.drawCloud(contentList, spiral.getPosForElement(20, rotation));
        wordCloudList.Add(studentCloud);
    }

    private void createStudentName(List<Content> contentList, float rotation, Spiral spiral)
    {
        Vector3 namePos = spiral.getPosForElement(namePositionNearFar, rotation);
        namePos = new Vector3(namePos.x, namePositionUpDown, namePos.z);
        GameObject studentName = Instantiate(studentNamePrefab, namePos, Quaternion.Euler(-90, rotation, 0)) as GameObject;
        studentName.GetComponent<TextMesh>().text = contentList[0].Student;
        studentNameList.Add(studentName);
    }

    private LineRenderer createLine(int vertexCount)
    {
        GameObject lineObj = new GameObject();
        LineRenderer line = lineObj.AddComponent<LineRenderer>();
        line.SetVertexCount(vertexCount);
        line.SetWidth(spiralLineWidth, spiralLineWidth);
        line.material = spiralLine;
        return line;
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
        foreach (WordCloud cloud in wordCloudList)
        {
            cloud.destroyCloud();
        }
        wordCloudList.Clear();
    }

   
}
