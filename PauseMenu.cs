using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class PauseMenu : MonoBehaviour {



	private List<KeyValuePair<String, String>> stringList;

	private List<KeyValuePair<String, String>> buttonList;

	public bool Button0 = false;


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

	private float textFieldWidth;
	
	private bool isInSight = false;

	Content objectToDisplayTags;

	public GameObject TagButton0;
	public GameObject TagButton1;
	public GameObject TagButton2;
	public GameObject TagButton3;
	public GameObject TagButton4;
	public GameObject TagButton5;
	public GameObject TagButton6;
	public GameObject TagButton7;
	public GameObject TagButton8;
	public GameObject TagButton9;
	public GameObject TagButton10;
	public GameObject TagButton11;
	public GameObject TagButton12;
	public GameObject TagButton13;
	public GameObject TagButton14;
	public GameObject TagButton15;







	public GameObject PauseMenuObject;

    private bool isPause;

    // Use this for initialization
    void Start()
    {
		TagButton0 = GameObject.Find ("TagButton0");
		TagButton1 = GameObject.Find ("TagButton1");
		TagButton2 = GameObject.Find ("TagButton2");
		TagButton3 = GameObject.Find ("TagButton3");
		TagButton4 = GameObject.Find ("TagButton4");
		TagButton5 = GameObject.Find ("TagButton5");
		TagButton6= GameObject.Find ("TagButton6");
		TagButton7 = GameObject.Find ("TagButton7");
		TagButton8 = GameObject.Find ("TagButton8");
		TagButton9 = GameObject.Find ("TagButton9");
		TagButton10 = GameObject.Find ("TagButton10");
		TagButton11 = GameObject.Find ("TagButton11");
		TagButton12 = GameObject.Find ("TagButton12");
		TagButton13 = GameObject.Find ("TagButton13");
		TagButton14 = GameObject.Find ("TagButton14");
		TagButton15 = GameObject.Find ("TagButton15");
		PauseMenuObject = GameObject.Find ("PauseMenuObject");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isPause = true;

    }

    // Update is called once per frame
    void Update()
    {

		isInSight = CheckRay ();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();
			ShowPauseMenu();
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








    void OnGUI()
    {
        if (isPause)
        {

            GUILayout.Label("Game is paused!");
            if (GUILayout.Button("Line View"))
                ViewKeeper.instance.lineView();
            if (GUILayout.Button("Cube View"))
                ViewKeeper.instance.cubeView();
            if (GUILayout.Button("Sun View"))
                ViewKeeper.instance.sunView();
            if (GUILayout.Button("TEST Wordcloud"))
                ViewKeeper.instance.wordCloud();
            if (GUILayout.Button("TEST Highlight DarioSala"))
                Highlighter.instance.highlightContentFromStudent("DarioSala");
            if (GUILayout.Button("TEST Highlight AliceGut"))
                Highlighter.instance.highlightContentFromStudent("AliceGut");
            if (GUILayout.Button("TEST Remove Highlight"))
                Highlighter.instance.removeCurrentHighlight();     

				}

		if (isInSight == true && isPause) {
			
			
			GUI.TextField (new Rect (810, 220, ((6 * textFieldWidth) + 110), numberOfDots), "");
			numberOfDots = (stringList.Count * 20) + 5;
			
			int offsetCounter = 10;
			foreach (KeyValuePair<String, String> tag in stringList) {
				
				GUI.Label (new Rect (815, 210 + offsetCounter, 300, 300), tag.Key);
				GUI.Label (new Rect (915, 210 + offsetCounter, 3000, 300), tag.Value);
				
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




	//TODO: Darios  listattempt chegge

//		private List<ButtonForTag> getAllButtons()
//
//	{
//		UnityEngine.Object[] objectButtons = FindObjectsOfType(typeof(ButtonForTag));
//		
//		List<ButtonForTag> buttonList = new List<ButtonForTag>();
//		foreach (ButtonForTag btn in objectButtons)
//		{
//			buttonList.Add((ButtonForTag)btn);
//		}
//		return buttonList;
//	}
//
//
//
//
//	
//
//	void showButtons (){
//
//			foreach (ButtonForTag btn in buttonList) {
//		 
//			if (stringList.Count >= buttonList.FindIndex)
//			{
//				GameObject buttonForTag;
//
//				// TODO: die Objects nun .SetActive(true);
//			}
//		}
//
//	}
	
	
	
	
	
	void ShowPauseMenu (){
		
		if (isPause) {
			PauseMenuObject.SetActive (true);



			if (stringList.Count == 0){
				TagButton0.SetActive(false);
				Highlighter.instance.highlightContentFromStudent(stringList[0].Value);

			}
			if (stringList.Count <= 1){
				TagButton1.SetActive(false);
			}
			if (stringList.Count <= 2){
				TagButton2.SetActive(false);
			}
			if (stringList.Count <= 3){
				TagButton3.SetActive(false);
			}
			if (stringList.Count <= 4){
				TagButton4.SetActive(false);
			}
			if (stringList.Count <= 5){
				TagButton5.SetActive(false);
			}
			if (stringList.Count <= 6){
				TagButton6.SetActive(false);
			}
			if (stringList.Count <= 7){
				TagButton7.SetActive(false);
			}
			if (stringList.Count <= 8){
				TagButton8.SetActive(false);
			}
			if (stringList.Count <= 9){
				TagButton9.SetActive(false);
			}
			if (stringList.Count <= 10){
				TagButton10.SetActive(false);
			}
			if (stringList.Count <= 11){
				TagButton11.SetActive(false);
			}
			if (stringList.Count <= 12){
				TagButton12.SetActive(false);
			}
			if (stringList.Count <= 13){
				TagButton13.SetActive(false);
			}
			if (stringList.Count <= 14){
				TagButton14.SetActive(false);
			}
			if (stringList.Count <= 15){
				TagButton15.SetActive(false);
			}
			



		} else {
			PauseMenuObject.SetActive(false);



		}
	}

		//TODO: Note from Mr. I.Verbugdincode: da heds en fehler geh, weiss nöd wie löse... 

//			private List<Content> getAllContents()
//    {
//
//        Object[] objectContents = FindObjectsOfType(typeof(Content));
//
//        List<Content> contentList = new List<Content>();
//        foreach (Object obj in objectContents)
//        {
//            contentList.Add((Content)obj);
//        }
//        return contentList;
//    }

    void togglePause()
    {
        if (isPause)
        {
            setUnPause();
        }
        else
        {
            setPause();
        }
    }

    private void setUnPause()
    {
        MouseLook.instance.enabled = true;
        Spectator.instance.enabled = true;
        SimKeeper.instance.enabled = false;
        ContentManager.instance.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

		TagButton0.SetActive(true);
		TagButton1.SetActive(true);
		TagButton2.SetActive(true);
		TagButton3.SetActive(true);
		TagButton4.SetActive(true);
		TagButton5.SetActive(true);
		TagButton6.SetActive(true);
		TagButton7.SetActive(true);
		TagButton8.SetActive(true);
		TagButton9.SetActive(true);
		TagButton10.SetActive(true);
		TagButton11.SetActive(true);
		TagButton12.SetActive(true);
		TagButton13.SetActive(true);
		TagButton14.SetActive(true);
		TagButton15.SetActive(true);


        isPause = false;
    }

    private void setPause()
    {
        MouseLook.instance.enabled = false;
        Spectator.instance.enabled = false;
        SimKeeper.instance.enabled = true;
        ContentManager.instance.enabled = false;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isPause = true;
    }
}
