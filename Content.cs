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
	
	
    //public LineRenderer lr;
    //Vector3 seedContentPos;
	
    //public List<string> tagList = new List<string>();
    //public List<string> metaTagList = new List<string>();
    //public List<Content> contentList = new List<Content>();
    //public List<KeyValuePair<Content, int>> simList = new List<KeyValuePair<Content, int>>();
    private List<KeyValuePair<LineRenderer, int>> lineList = new List<KeyValuePair<LineRenderer, int>>();


	//public List<KeyValuePair<Content, int>> lineList = new List<KeyValuePair<Content, int>>();
	
    //private GameObject lineRenderGameObject;
	
    //private Renderer rend; 



	//BoxCollider col = (BoxCollider)collider;


    
	
	// Use this for initialization
	void Start () {

		addBoxCollider();


	}
	
	
	// Update is called once per frame
	void Update()
	{
		drawLines();

		aligneObjectToCamera ();
		
	}





	
	
	
	//TODO divide into tag and metatag list, also adjust compare method
    //public void buildTagList()
    //{
    //    buildMetaTagList();
        
    //    if (Tag0 != "")
    //    {
    //        tagList.Add(Tag0);
    //    }
    //    if (Tag1 != "")
    //    {
    //        tagList.Add(Tag1);
    //    }
    //    if (Tag2 != "")
    //    {
    //        tagList.Add(Tag2);
    //    }
    //    if (Tag3 != "")
    //    {
    //        tagList.Add(Tag3);
    //    }
    //    if (Tag4 != "")
    //    {
    //        tagList.Add(Tag4);
    //    }
    //    if (Tag5 != "")
    //    {
    //        tagList.Add(Tag5);
    //    }
    //    if (Tag6 != "")
    //    {
    //        tagList.Add(Tag6);
    //    }
    //    if (Tag7 != "")
    //    {
    //        tagList.Add(Tag7);
    //    }
    //    if (Tag8 != "")
    //    {
    //        tagList.Add(Tag8);
    //    }
    //    if (Tag9 != "")
    //    {
    //        tagList.Add(Tag9);
    //    }
		
    //}

    //private void buildMetaTagList()
    //{
    //    if (Titel != "")
    //    {
    //        metaTagList.Add(Titel);
    //    }
    //    if (Untertitel != "")
    //    {
    //        metaTagList.Add(Untertitel);
    //    }
    //    if (Autor != "")
    //    {
    //        metaTagList.Add(Autor);
    //    }
    //    if (Verortung != "")
    //    {
    //        metaTagList.Add(Verortung);
    //    }
    //    if (UR != "")
    //    {
    //        metaTagList.Add(UR);
    //    }
    //    if (PUR != "")
    //    {
    //        metaTagList.Add(PUR);
    //    }
    //}
	
	
    //public void buildContentList()
    //{
    //    Object[] objectContents = FindObjectsOfType(typeof(Content));
		
    //    foreach (Object obj in objectContents)
    //    {
    //        contentList.Add((Content)obj);
    //    }
    //    contentList.Remove(this);
    //}
	
    //public void buildSimList()
    //{
    //    foreach (Content cont in contentList)
    //    {
    //        int score = 0;
    //        List<string> remoteTagList = cont.getTagList();
    //        foreach (string tag in remoteTagList)
    //        {
    //            if (tagList.Contains(tag))
    //            {
    //                score++;
    //            }
    //        }
    //        simList.Add(new KeyValuePair<Content, int>(cont, score));
    //    }
		
    //    simList.Sort((x, y) => y.Value.CompareTo(x.Value));
		
     
		
    //}
	
    //public void alignCircle()
    //{
    //    float currRad = 60;
    //    Vector3 currPos = new Vector3(0f, 0f, 0f);
    //    gameObject.transform.position = currPos;
    //    int sameScore = 1;
    //    //TODO content with no similarities has an empty simList


    //    int currScore = simList[0].Value;
    //    int circlePos = 1;
		
    //    while (simList[sameScore].Value == currScore)
    //    {
    //        sameScore++;
    //    }
    //    //TODO make sure all elements have enough space on currRad


    //    Circle circle = new Circle(currRad, sameScore);
		
    //    for (int i = 0; i < simList.Count; i++)
    //    {
    //        currPos = circle.getPosForElement(circlePos);
    //        simList[i].Key.transform.position = currPos;
    //        circlePos++;
			
    //        if (i + 1 < simList.Count && simList[i + 1].Value != currScore)
    //        {
    //            sameScore = 1;
    //            currScore = simList[i + 1].Value;
    //            while (i + sameScore + 1 < simList.Count && simList[i + sameScore + 1].Value == currScore)
    //            {
    //                sameScore++;
    //            }

    //            if ( getMinRadius(sameScore) > currRad + 60)
    //            {
    //                currRad = getMinRadius(sameScore);					
    //            }
    //            else 					
    //            {
    //                currRad += 60;
    //            }

    //            circle = new Circle(currRad, sameScore);
    //            circlePos = 1;
				
    //        }
			
    //    }
		
    //}

    //private float getMinRadius(int numberOfElements){
    //    return (numberOfElements * 60)/(2*Mathf.PI);
    //}

    public void drawLines()
    {
        foreach (KeyValuePair<LineRenderer, int> pair in lineList)
        {
            pair.Key.SetPosition(pair.Value, this.transform.position);
        }
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
	
    //public List<KeyValuePair<Content,int>> getSimList()
    //{
    //    return this.simList;
    //}


	public void aligneObjectToCamera()
	{
        transform.LookAt (Camera.main.transform.position);
        transform.Rotate(0, 180, 0);
    }



	public void addBoxCollider (){
		
		//rend = GetComponent<Renderer>();
		
		BoxCollider boxCollider = this.gameObject.AddComponent<BoxCollider>();


		//boxCollider.center = new Vector3 (rend.bounds.extents.x - rend.bounds.size.x / 2, rend.bounds.extents.y - rend.bounds.size.y / 2, transform.position.z);
		//boxCollider.size = new Vector3 (rend.bounds.size.x * 10, rend.bounds.size.y * 100, 0);
		//boxCollider.size = rend.bounds.size * 100;

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
}
