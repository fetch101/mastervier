using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainScript : MonoBehaviour {
    

    private bool isPause;

    // Use this for initialization
	void Start () {
        List<Content> contentList = getAllContents();


        foreach (Content content in contentList)
        {
            content.buildTagList();
            content.buildContentList();
        }
        foreach (Content content in contentList)
        {
            content.buildSimList();
        }

        contentList[0].alignCircle();

        int count = 0;
        foreach (Content content in contentList)
        {

            //content.drawLines();
            Debug.Log("Object Nr: " + count + ", " + content.Titel);
            count++;
        }


        foreach (KeyValuePair<Content, int> pair in contentList[6].getSimList())
        {
            Debug.Log("I am " + contentList[6].Titel + " and have score " + pair.Value + " to " + pair.Key.Titel);

        }


        //System.Random rand = new System.Random();


        //testtags seedContent = (testtags)objectContents[rand.Next(0, contents.Count)];


        //alignContentsInCube(contents);

        //Vector3 seedContentPos = getContentPos(seedContent);


        //foreach (testtags currentContent in contents)
        //{

        //    currentContent.drawLine(seedContentPos);
        //}

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


    private void alignContentsInLine(List<Content> contents)
    {
        Vector3 start = new Vector3(0f, 0f, 0f);
        foreach (Content cont in contents)
        {
            cont.gameObject.transform.position = start;
            start.z += 10;
        }
    }

    private void alignContentsInCube(List<Content> contents)
    {

        int numberOfContents = contents.Count;
        int cubeDegree = getCubeDegree(numberOfContents);
        int i = 0;
            for (int x = 0; x < cubeDegree; x++)
            {
                for(int y = 0; y < cubeDegree; y++){

                    for(int z = 0; z < cubeDegree; z++){
                        Vector3 pos = new Vector3(x*100, y*100, z*100);
                        if (i < contents.Count)
                        {
                            contents[i].gameObject.transform.position = pos;
                            i++;
                        }

                    }
                }
            }
    }

    private int getCubeDegree(int numberOfContents)
    {

		//TODO round degree to next higher int 
        float degree = Mathf.Pow(numberOfContents, 1f/3f);
        return (int)degree + 1;
    }



    private static Vector3 getContentPos(Content content)
    {
        Vector3 seedCubePos = new Vector3(content.transform.position.x, content.transform.position.y, content.transform.position.z);
        return seedCubePos;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = togglePause();
        }
	
	}

    void OnGUI()
    {
        if (isPause) {
            GUILayout.Label("Game is paused!");
            if (GUILayout.Button("Line View"))
                alignContentsInLine(getAllContents());
            if (GUILayout.Button("Start Cube View"))
                alignContentsInCube(getAllContents());
            if (GUILayout.Button("Circle View"))
                alignContentsInCircleWithCenter(getAllContents()[0]);
            if (GUILayout.Button("Curly Line"))
                //alignContentsAsSun(getStudentList(getAllContents()));
                alignSpiral(getAllContents(), new Vector3(0f,0f,0f));
            if (GUILayout.Button("Close"))
                isPause = togglePause();
        }
    }

    private List<List<Content>> getStudentList(List<Content> contents)
    {
        List<List<Content>> studentList = new List<List<Content>>();
        foreach (Content content in contents)
        {
           //studentList.Add(cont)
        }

        return null;
    }


    private void alignContentsAsSun(List<List<Content>> studentList)
    {
        Vector3 firstPos = new Vector3(0f, 0f, 0f);
        foreach (List<Content> contentList in studentList)
        {
            alignSpiral(contentList, firstPos);
            firstPos.x += 50;
        }
    }

    private void alignSpiral(List<Content> contentList, Vector3 startPosition)
    {
        float radius = 50;
        float offsetZ = 30;
        Circle spiral = new Circle(radius, offsetZ, startPosition);
        int i = 0;
        foreach (Content content in contentList)
        {
            content.transform.position = spiral.getPosForElement(i);
            i++;
        }
    }

    private void alignContentsInCircleWithCenter(Content content)
    {
        content.alignCircle();
    }

    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            this.GetComponent<MouseLook>().isPause = false;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            this.GetComponent<MouseLook>().isPause = true;
            return (true);
        }
    }

    
}
