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
	
	public int threshold;
	
	public LineRenderer lr;
	Vector3 seedContentPos;
	
	public List<string> tagList = new List<string>();
	public List<Content> contentList = new List<Content>();
	public List<KeyValuePair<Content, int>> simList = new List<KeyValuePair<Content, int>>();


	//public List<KeyValuePair<Content, int>> lineList = new List<KeyValuePair<Content, int>>();
	
	private GameObject lineRenderGameObject;
	
	private Renderer rend; 



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

		// TODO: Jedes Object/Inhalt muss sich nach der MainCamera ausrichten 
		
	}





	
	
	
	//TODO divide into tag and metatag list, also adjust compare method
	public void buildTagList()
	{


		if (Titel != "")
		{
			tagList.Add(Titel);
		}
		if (Untertitel != "")
		{
			tagList.Add(Untertitel);
		}
		if (Autor != "")
		{
			tagList.Add(Autor);
		}
		if (Verortung != "")
		{
			tagList.Add(Verortung);
		}
		if (UR != "")
		{
			tagList.Add(UR);
		}
		if (PUR != "")
		{
			tagList.Add(PUR);
		}


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
		
	}
	
	
	public void buildContentList()
	{
		Object[] objectContents = FindObjectsOfType(typeof(Content));
		
		foreach (Object obj in objectContents)
		{
			contentList.Add((Content)obj);
		}
		contentList.Remove(this);
	}
	
	public void buildSimList()
	{
		foreach (Content cont in contentList)
		{
			int score = 0;
			List<string> remoteTagList = cont.getTagList();
			foreach (string tag in remoteTagList)
			{
				if (tagList.Contains(tag))
				{
					score++;
				}
			}
			simList.Add(new KeyValuePair<Content, int>(cont, score));
		}
		
		simList.Sort((x, y) => y.Value.CompareTo(x.Value));
		
		if (simList.Count > 0 && simList[0].Value >= threshold)
		{
			int vertexCount = 0;
			foreach (KeyValuePair<Content, int> pair in simList)
			{
				if (pair.Value >= threshold)
				{
					vertexCount++;
				}
			}
			lineRenderGameObject = new GameObject();
			lr = lineRenderGameObject.AddComponent<LineRenderer>();
			lr.SetVertexCount(vertexCount * 2);   
			lr.SetWidth(0.08f, 0.08f);
			lr.SetColors(Color.white, Color.white);

			Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));

			lr.material = whiteDiffuseMat;



			
		}
		
	}
	
	public void alignCircle()
	{
		Debug.Log("center: " + Titel);
		float currRad = 60;
		Vector3 currPos = new Vector3(0f, 0f, 0f);
		gameObject.transform.position = currPos;
		int sameScore = 1;
		//TODO content with no similarities has an empty simList


		int currScore = simList[0].Value;
		int circlePos = 1;
		
		while (simList[sameScore].Value == currScore)
		{
			sameScore++;
		}
		//TODO make sure all elements have enough space on currRad


		Circle circle = new Circle(currRad, sameScore);
		
		for (int i = 0; i < simList.Count; i++)
		{
			currPos = circle.getPosForElement(circlePos);
			simList[i].Key.transform.position = currPos;
			circlePos++;
			
			if (i + 1 < simList.Count && simList[i + 1].Value != currScore)
			{


				sameScore = 1;
				currScore = simList[i + 1].Value;
				while (i + sameScore + 1 < simList.Count && simList[i + sameScore + 1].Value == currScore)
				{
					sameScore++;
				}

				if ( getMinRadius(sameScore) > currRad + 60)
				{
					
					currRad = getMinRadius(sameScore);
					
				}
				else 
					
				{
					currRad += 60;
				}



				circle = new Circle(currRad, sameScore);
				circlePos = 1;
				
			}
			
		}
		
	}

	private float getMinRadius(int numberOfElements){
		return (numberOfElements * 60)/(2*Mathf.PI);
	}
	
	public void drawLines()
	{
		
		if (simList.Count > 0 && simList[0].Value >= threshold)
		{
			
			int i = 0;
			//lr.SetPosition(0, this.gameObject.transform.position);
			foreach (KeyValuePair<Content, int> pair in simList)
			{
				if (pair.Value >= threshold)
				{
					lr.SetPosition(i, gameObject.transform.position);
					i++;
					lr.SetPosition(i, pair.Key.transform.position);
					i++;
				}
				else
				{
					break;
				}
			}
		}
	}
	
	
	public List<string> getTagList()
	{
		return this.tagList;
	}
	
	public List<KeyValuePair<Content,int>> getSimList()
	{
		return this.simList;
	}


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
	
	
	
}
