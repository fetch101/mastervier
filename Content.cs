using UnityEngine;
using System.Collections.Generic;

public class Content : MonoBehaviour {
	public Vector3 finalDestination;
	public Quaternion currRotation = Quaternion.Euler(new Vector3(0, 0, 0));
//	private Vector3 currRotation;

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
    public int phaseNumber;

    private List<KeyValuePair<LineRenderer, int>> sameStudentLines = new List<KeyValuePair<LineRenderer, int>>();
    private List<KeyValuePair<LineRenderer, int>> differentStudentLines = new List<KeyValuePair<LineRenderer, int>>();

	private float height;
    public bool isMoving;
    private Vector3 moveTowards;
    public float speed;
    public bool shouldAlign = true;
    public bool battleMode = false;
	new Vector3 modifiedCollider;

	GameObject highlightPlane;
	Vector3 scale;
	Vector3 position;
	Vector3 rotation;
	// Use this for initialization
	void Start () {
		addBoxCollider();
		height = gameObject.GetComponent<Renderer> ().bounds.size.y / 2;
        trimStrings();
        extractPhase();
	}

    private void extractPhase()
    {
        string[] phaseNumber = Phase.Split(new char[] { 'P' }, 2);
        this.phaseNumber = int.Parse(phaseNumber[1]);
    }

    private void trimStrings()
    {
        Student = Student.Trim();
        Semester = Semester.Trim();
        Phase = Phase.Trim();
        Year = Year.Trim();
        Objecttype = Objecttype.Trim();
    }


//	public void addHighlightPlane(){
//		GameObject highlightPlane = GameObject.CreatePrimitive(PrimitiveType.Cube);
////		highlightPlane.transform.parent = this.gameObject.transform;
////		highlightPlane.transform.localScale = new Vector3((highlightPlane.transform.localScale.x * 0.001f), (highlightPlane.transform.localScale.y * 0.001f), (highlightPlane.transform.localScale.z * 0.001f) );
////
//////		scale = new Vector3 (this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
//////		position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + 1);
//////		GameObject highlightPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
//////		highlightPlane.transform.position = position;
//////		highlightPlane.transform.localScale = scale;
//////		highlightPlane.transform.rotation = rotation;
//	}
//
//	public void destroyHighlightPlane(){
////		Destroy (highlightPlane);
//	}

    public void addBoxCollider()
    {
      BoxCollider collider = this.gameObject.AddComponent<BoxCollider>();

		if (collider.size.y < 5000 && Objecttype != "Image") {
			collider.size = new Vector3(collider.size.x, 5000, collider.size.z);

		}
		if (collider.size.x < 5000 && Objecttype != "Image") {
			collider.size = new Vector3(5000, collider.size.y, collider.size.z);
			
		}
	}
	
	
	// Update is called once per frame
	void Update()
	{
        //rotation = new Vector3(this.gameObject.transform.rotation.x, this.gameObject.transform.rotation.y, this.gameObject.transform.rotation.z);
		drawLines();
        if (shouldAlign)
        {
		    aligneObjectToCamera();
        }
        if (isMoving)
        {
            move();
        }
        if (battleMode)
        {
            this.moveTo(Camera.main.transform.position);
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
		finalDestination = moveTowards;
    }

    public void drawLines()
    {
        foreach (KeyValuePair<LineRenderer, int> pair in sameStudentLines)
        {
            pair.Key.SetPosition(pair.Value, this.transform.position);
        }
        foreach (KeyValuePair<LineRenderer, int> pair in differentStudentLines)
        {
            pair.Key.SetPosition(pair.Value, this.transform.position);
        }
    }

    public void aligneObjectToCamera()
    {
		int activationDistance = 300; 
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
            tagList.Add(Tag0.Trim());
        }
        if (Tag1 != "")
        {
            tagList.Add(Tag1.Trim());
        }
        if (Tag2 != "")
        {
            tagList.Add(Tag2.Trim());
        }
        if (Tag3 != "")
        {
            tagList.Add(Tag3.Trim());
        }
        if (Tag4 != "")
        {
            tagList.Add(Tag4.Trim());
        }
        if (Tag5 != "")
        {
            tagList.Add(Tag5.Trim());
        }
        if (Tag6 != "")
        {
            tagList.Add(Tag6.Trim());
        }
        if (Tag7 != "")
        {
            tagList.Add(Tag7.Trim());
        }
        if (Tag8 != "")
        {
            tagList.Add(Tag8.Trim());
        }
        if (Tag9 != "")
        {
            tagList.Add(Tag9.Trim());
        }

		return tagList;
	}


    public List<string> getMetaTagList()
    {
        List<string> metaTagList = new List<string>();
        if (Titel != "")
        {
            metaTagList.Add(Titel.Trim());
        }
        if (Untertitel != "")
        {
            metaTagList.Add(Untertitel.Trim());
        }
        if (Autor != "")
        {
            metaTagList.Add(Autor.Trim());
        }
        if (Verortung != "")
        {
            metaTagList.Add(Verortung.Trim());
        }
        if (UR != "")
        {
            metaTagList.Add(UR.Trim());
        }
        if (PUR != "")
        {
            metaTagList.Add(PUR.Trim());
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
        tag = tag.ToLower();
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


    public void addSameStudentLine(LineRenderer linerenderer, int vertex)
    {
        sameStudentLines.Add(new KeyValuePair<LineRenderer, int>(linerenderer, vertex));
    }

    public void addDifferentStudentLine(LineRenderer linerenderer, int vertex)
    {
        differentStudentLines.Add(new KeyValuePair<LineRenderer, int>(linerenderer, vertex));
    }

    public void removeDifferentLines()
    {
        differentStudentLines.Clear();
    }

    public void removeSameStudentLines()
    {
        sameStudentLines.Clear();
    }


	public void spawnHighlightObject(){
		if (this.transform.rotation != Quaternion.Euler (0, 0, 0)) {
			currRotation = this.transform.rotation;
		}
		float scale = 0.02f;
		float textscale = 500.0f;

		if (markCount > 0) {

			if (markCount % 2 == 0) {
				this.transform.rotation = Quaternion.Euler (0, 0, 0);
				GameObject markCloneEven = Instantiate (mark, new Vector3 ((this.gameObject.transform.position.x + markOffsetX), this.gameObject.transform.position.y + 2 +  height, this.gameObject.transform.position.z), Quaternion.Euler (- 90, 90, 0)) as GameObject;
				markCloneEven.transform.parent = transform;
				if (Objecttype == "Image"){
					markCloneEven.transform.localScale = new Vector3(scale, scale, scale);
				} else {
					markCloneEven.transform.localScale = new Vector3(textscale, textscale, textscale);
					
				}				markOffsetX += 5;
				markCount ++;
				this.transform.rotation = currRotation;
			} else {
				this.transform.rotation = Quaternion.Euler (0, 0, 0);
				GameObject markCloneOdd = Instantiate (mark, new Vector3 ((this.gameObject.transform.position.x + markOffsetZ), this.gameObject.transform.position.y + 2 +  height , this.gameObject.transform.position.z), Quaternion.Euler (- 90, 90, 0)) as GameObject;
				markCloneOdd.transform.parent = transform;
				if (Objecttype == "Image"){
					markCloneOdd.transform.localScale = new Vector3(scale, scale, scale);
				} else {
					markCloneOdd.transform.localScale = new Vector3(textscale, textscale, textscale);
					
				}				markOffsetZ -= 5;
				markCount ++;
				this.transform.rotation = currRotation;

					}
		} else {
			this.transform.rotation = Quaternion.Euler (0, 0, 0);
			GameObject markCloneOrigin = Instantiate (mark, new Vector3 ((this.gameObject.transform.position.x), this.gameObject.transform.position.y + 2 +  height , this.gameObject.transform.position.z), Quaternion.Euler (-90, 90, 0)) as GameObject;
			markCloneOrigin.transform.parent = transform;
			if (Objecttype == "Image"){
				markCloneOrigin.transform.localScale = new Vector3(scale, scale, scale);
			} else {
				markCloneOrigin.transform.localScale = new Vector3(textscale, textscale, textscale);

			}

//			markCloneOrigin.transform.localScale = new Vector3(scale, scale, scale);
			markCount ++;
			this.transform.rotation = currRotation;
				}
		}
}
