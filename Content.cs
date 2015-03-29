using UnityEngine;
using System.Collections.Generic;

public class Content : MonoBehaviour {
	
		
	public string Student;
	public string Semester;
	public string Phase;
	public string Year;
	public string Objecttype;
	
	public string Titel;
	public string Untertitel;
	public string Autor;
	
	public string Verortung;
	public string UR;
	public string PUR;
	
	
	public string Tag0;
	public string Tag1;
	public string Tag2;
	public string Tag3;
	public string Tag4;
	public string Tag5;
	public string Tag6;
	public string Tag7;
	public string Tag8;
	public string Tag9;
	
    private List<KeyValuePair<LineRenderer, int>> lineList = new List<KeyValuePair<LineRenderer, int>>();

	
	// Use this for initialization
	void Start () {
		addBoxCollider();
	}


    public void addBoxCollider()
    {
        this.gameObject.AddComponent<BoxCollider>();
    }
	
	
	// Update is called once per frame
	void Update()
	{
		drawLines();
		aligneObjectToCamera();
	}

    public void drawLines()
    {
        foreach (KeyValuePair<LineRenderer, int> pair in lineList)
        {
            pair.Key.SetPosition(pair.Value, this.transform.position);
        }
    }

    public void aligneObjectToCamera()
    {
        transform.LookAt(Camera.main.transform.position);
        transform.Rotate(0, 180, 0);
    }	
	
	public List<string> getTagList()
	{
        List<string> tagList = new List<string>();
        if (Tag0 != "")
        {
            tagList.Add(Tag0);
        }
        if (Tag1 != "")
        {
            tagList.Add(Tag1);
        }
        if (Tag2 != "")
        {
            tagList.Add(Tag2);
        }
        if (Tag3 != "")
        {
            tagList.Add(Tag3);
        }
        if (Tag4 != "")
        {
            tagList.Add(Tag4);
        }
        if (Tag5 != "")
        {
            tagList.Add(Tag5);
        }
        if (Tag6 != "")
        {
            tagList.Add(Tag6);
        }
        if (Tag7 != "")
        {
            tagList.Add(Tag7);
        }
        if (Tag8 != "")
        {
            tagList.Add(Tag8);
        }
        if (Tag9 != "")
        {
            tagList.Add(Tag9);
        }

		return tagList;
	}


    public List<string> getMetaTagList()
    {
        List<string> metaTagList = new List<string>();
        if (Titel != "")
        {
            metaTagList.Add(Titel);
        }
        if (Untertitel != "")
        {
            metaTagList.Add(Untertitel);
        }
        if (Autor != "")
        {
            metaTagList.Add(Autor);
        }
        if (Verortung != "")
        {
            metaTagList.Add(Verortung);
        }
        if (UR != "")
        {
            metaTagList.Add(UR);
        }
        if (PUR != "")
        {
            metaTagList.Add(PUR);
        }

        return metaTagList;
    }
	
 	
    public void addLine(LineRenderer linerenderer, int vertex)
    {
        lineList.Add(new KeyValuePair<LineRenderer, int>(linerenderer, vertex));
    }

    public void removeLines()
    {
        lineList.RemoveRange(0, lineList.Count);
    }
}
