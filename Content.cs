using UnityEngine;
using System.Collections.Generic;

public class Content : MonoBehaviour {

	public int markCount = 0;
	public int markOffsetX = 5;
	public int markOffsetZ = -5;

	public GameObject mark; 
	
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

	private float height;
    private bool isMoving;
    private Vector3 moveTowards;
    public float speed;
    public bool shouldAlign = true;
	
	// Use this for initialization
	void Start () {
		addBoxCollider();
		height = gameObject.GetComponent<Renderer> ().bounds.size.y / 2;

	}


    public void addBoxCollider()
    {
      BoxCollider collider = this.gameObject.AddComponent<BoxCollider>();
    }
	
	
	// Update is called once per frame
	void Update()
	{
		drawLines();
        if (shouldAlign)
        {
		    aligneObjectToCamera();
        }
        if (isMoving)
        {
            move();
        }
	}

    private void move()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, moveTowards, step);
        if(transform.position == moveTowards){
            isMoving = false;
        }
    }

    public void moveTo(Vector3 moveTowards)
    {
        this.moveTowards = moveTowards;
        isMoving = true;
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
		int activationDistance = 200; 
		int speedForRotation = 2;


		if((transform.position - Camera.main.transform.position).magnitude < activationDistance)
		
		{

			Quaternion targetRotation = Quaternion.LookRotation(Camera.main.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speedForRotation * Time.deltaTime);

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


    private List<string> getCombinedTagsToLower()
    {
        List<string> metaTag = getMetaTagList();
        metaTag = metaTag.ConvertAll(item => item.ToLower());
        List<string> tag = getTagList();
        tag = tag.ConvertAll(item => item.ToLower());
        metaTag.AddRange(tag);
        return metaTag;
    }

    public bool contains(string tag)
    {
        if (getCombinedTagsToLower().Contains(tag))
        {
            return true;
        }
        if (this.Student.ToLower() == tag || this.Semester.ToLower() == tag || this.Phase.ToLower() == tag || this.Year.ToLower() == tag || this.Objecttype.ToLower() == tag)
        {
            return true;
        }
        return false;
    }


    public void addLine(LineRenderer linerenderer, int vertex)
    {
        lineList.Add(new KeyValuePair<LineRenderer, int>(linerenderer, vertex));
    }

    public void removeLines()
    {
        lineList.RemoveRange(0, lineList.Count);
    }


	// TODO: set Content as Child without orientation to Camera
	public void spawnHighlightObject(){

		if (markCount > 0) {

			if (markCount % 2 == 0) {

				GameObject markCloneEven = Instantiate (mark, new Vector3 ((this.gameObject.transform.position.x + markOffsetX), this.gameObject.transform.position.y + 2 +  height, this.gameObject.transform.position.z), Quaternion.Euler (- 90, 90, 0)) as GameObject;
			
				markOffsetX += 5;
				markCount ++;

			} else {

				GameObject markCloneOdd = Instantiate (mark, new Vector3 ((this.gameObject.transform.position.x + markOffsetZ), this.gameObject.transform.position.y + 2 +  height , this.gameObject.transform.position.z), Quaternion.Euler (- 90, 90, 0)) as GameObject;
			
				markOffsetZ -= 5;
				markCount ++;

			}


		} else {

			GameObject markCloneOrigin = Instantiate (mark, new Vector3 ((this.gameObject.transform.position.x), this.gameObject.transform.position.y + 2 +  height , this.gameObject.transform.position.z), Quaternion.Euler (-90, 90, 0)) as GameObject;
			markCount ++;
//			markCloneOrigin.transform.parent = this.gameObject.transform;

		}
		}

}
