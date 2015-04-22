using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ContentManager : MonoBehaviour {

    public static ContentManager instance;
	private bool aimed = false;
	private List<KeyValuePair<String, String>> stringList;

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

	public int numberOfTags = 0;
	public int numberOfDots = 10;

	public int windowOffset = 0;
	public int effectiveWindowOffset = 0;

	private float textFieldWidth;

	private bool isInSight = false;

	public GUISkin OpenSansGuiSkin;



	Content objectToDisplayTags;

	// Use this for initialization
	void Start () {
        instance = this;


	}
	
	// Update is called once per frame
	void Update () {

		isInSight = CheckRay ();
		if(isInSight && Input.GetKeyDown("c")){

			ViewKeeper.instance.circleView(objectToDisplayTags);

		}

	}




	public bool CheckRay(){

		Ray raycheck = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
		
		RaycastHit hitcheck;

		if (Physics.Raycast (raycheck, out hitcheck, 40f) && hitcheck.collider.gameObject.GetComponent<Content> () != null) {

			objectToDisplayTags = hitcheck.collider.gameObject.GetComponent<Content>();
			buldStringList (objectToDisplayTags);


			return true;




		}else{
			return false;
		}
	}


	void buldStringList (Content contentInSight)
	{

		stringList = new List<KeyValuePair<String, String>> ();

		if (contentInSight.Student != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Student", contentInSight.Student);
			stringList.Add(curTag);
		}
		if (contentInSight.Semester != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Semester", contentInSight.Semester);
			stringList.Add(curTag);
		}
		if (contentInSight.Year != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Jahr", contentInSight.Year);
			stringList.Add(curTag);
		}
		if (contentInSight.Objecttype != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Objekttyp", contentInSight.Objecttype);
			stringList.Add(curTag);
		}
		if (contentInSight.Titel != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Titel", contentInSight.Titel);
			stringList.Add(curTag);
		}
		if (contentInSight.Untertitel != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Untertitel", contentInSight.Untertitel);
			stringList.Add(curTag);
		}
		if (contentInSight.Autor != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Autor", contentInSight.Autor);
			stringList.Add(curTag);
		}
		if (contentInSight.Verortung != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Verortung", contentInSight.Verortung);
			stringList.Add(curTag);
		}
		if (contentInSight.UR != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Unterrichtung", contentInSight.UR);
			stringList.Add(curTag);
		}
		if (contentInSight.PUR != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Präzisierung", contentInSight.PUR);
			stringList.Add(curTag);
		}
		if (contentInSight.Tag0 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Keywords", contentInSight.Tag0);
			stringList.Add(curTag);
		}
		if (contentInSight.Tag1 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag1);
			stringList.Add(curTag);
		}
		if (contentInSight.Tag2 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag2);
			stringList.Add(curTag);
		}
		if (contentInSight.Tag3 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag3);
			stringList.Add(curTag);
		}
		if (contentInSight.Tag4 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag4);
			stringList.Add(curTag);
		}
		if (contentInSight.Tag5 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag5);
			stringList.Add(curTag);
		}
		if (contentInSight.Tag6 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag6);
			stringList.Add(curTag);
		}
		if (contentInSight.Tag7 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag7);
			stringList.Add(curTag);
		}
		if (contentInSight.Tag8 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag8);
			stringList.Add(curTag);
		}
		if (contentInSight.Tag9 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag9);
			stringList.Add(curTag);
		}

	
	}

    
	public void OnGUI() {

		GUI.skin = OpenSansGuiSkin;


		if (isInSight == true) {

		
			GUI.TextField (new Rect (10, 10, ((6 * textFieldWidth) + 110), numberOfDots), "");
			numberOfDots = (stringList.Count * 20) + 5;
	
			int offsetCounter = 10;
			foreach (KeyValuePair<String, String> tag in stringList) {

				GUI.Label (new Rect (18, offsetCounter, 300, 300), tag.Key);
				GUI.Label (new Rect (100, offsetCounter, 3000, 300), tag.Value);

				//Debug.Log ("Current tagvalue length is " + tag.Value.Length + "for " + tag.Value);

				if (tag.Value.Length > textFieldWidth) {
					textFieldWidth = tag.Value.Length;
				}

				offsetCounter += 20;
			}
		} else {
			textFieldWidth = 0;


		}
	
	}




}

