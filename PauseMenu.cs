using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;



public class PauseMenu : MonoBehaviour {

	public List<KeyValuePair<ButtonForTag, String>> buttonForTagWithTagList;

    private List<KeyValuePair<String, String>> stringList = new List<KeyValuePair<String, String>>();

	public List<ButtonForTag> buttonList;

	public bool Button0 = false;
	public bool Button1 = false;
	public bool Button2 = false;
	public bool Button3 = false;
	public bool Button4 = false;
	public bool Button5 = false;
	public bool Button6 = false;
	public bool Button7 = false;
	public bool Button8 = false;
	public bool Button9 = false;
	public bool Button10 = false;
	public bool Button11 = false;
	public bool Button12 = false;
	public bool Button13 = false;
	public bool Button14 = false;
	public bool Button15 = false;
	public bool Button17 = false;
	public bool Button18 = false;
	public bool Button19 = false;
	public bool Button20 = false;
	public bool Button21 = false;


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

	public int i = 0;

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
	public GameObject TagButton16;
	public GameObject TagButton17;
	public GameObject TagButton18;
	public GameObject TagButton19;
	public GameObject TagButton20;
	public GameObject TagButton21;







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
		TagButton16 = GameObject.Find ("TagButton16");
		TagButton17 = GameObject.Find ("TagButton17");
		TagButton18 = GameObject.Find ("TagButton18");
		TagButton19 = GameObject.Find ("TagButton19");
		TagButton20 = GameObject.Find ("TagButton20");
		TagButton21 = GameObject.Find ("TagButton21");
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
//			getButtonForTagWithTagList();
        }

    }


	public bool CheckRay(){
		
		Ray raycheck = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));

		RaycastHit hitcheck;
		
		if (Physics.Raycast (raycheck, out hitcheck, 40f) && hitcheck.collider.gameObject.GetComponent<Content> () != null) {
			
			objectToDisplayTags = hitcheck.collider.gameObject.GetComponent<Content>();
			getStringListForContentInSight (objectToDisplayTags);

			return true;

		}else{
			return false;			
		}
	}

	public List<KeyValuePair<string, string>> getStringListForContentInSight(Content contentInSight)
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
		if (contentInSight.Phase != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Phase", contentInSight.Phase);
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

		return stringList;
		
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
//            if (GUILayout.Button("TEST Highlight DarioSala"))
//                Highlighter.instance.highlightContentFromStudent("DarioSala");
//            if (GUILayout.Button("TEST Highlight AliceGut"))
////                Highlighter.instance.highlightContentFromStudent("AliceGut");
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

				if (tag.Value.Length > textFieldWidth) {
					textFieldWidth = tag.Value.Length;
				}
				
				offsetCounter += 20;
			}
		} else {
			textFieldWidth = 0;
				
		}
}


	void ShowPauseMenu (){
		
		if (isPause) {
			PauseMenuObject.SetActive (true);

			if (isInSight){


			if (stringList.Count >= 0) {
				TagButton0.SetActive (true);
			}
			if (stringList.Count >= 1) {
				TagButton1.SetActive (true);
			}
			if (stringList.Count >= 2) {
				TagButton2.SetActive (true);
			}
			if (stringList.Count >= 3) {
				TagButton3.SetActive (true);
			}
			if (stringList.Count >= 4) {
				TagButton4.SetActive (true);
			}
			if (stringList.Count >= 5) {
				TagButton5.SetActive (true);
			}
			if (stringList.Count >= 6) {
				TagButton6.SetActive (true);
			}
			if (stringList.Count >= 7) {
				TagButton7.SetActive (true);
			}
			if (stringList.Count >= 8) {
				TagButton8.SetActive (true);
			}
			if (stringList.Count >= 9) {
				TagButton9.SetActive (true);
			}
			if (stringList.Count >= 10) {
				TagButton10.SetActive (true);
			}
			if (stringList.Count >= 11) {
				TagButton11.SetActive (true);
			}
			if (stringList.Count >= 12) {
				TagButton12.SetActive (true);
			}
			if (stringList.Count >= 13) {
				TagButton13.SetActive (true);
			}
			if (stringList.Count >= 14) {
				TagButton14.SetActive (true);
			}
			if (stringList.Count >= 15) {
				TagButton15.SetActive (true);
			}
			if (stringList.Count >= 16) {
				TagButton16.SetActive (true);
			}
			if (stringList.Count >= 17) {
				TagButton17.SetActive (true);
			}
			if (stringList.Count >= 18) {
				TagButton18.SetActive (true);
			}
			if (stringList.Count >= 19) {
				TagButton19.SetActive (true);
			}
			if (stringList.Count >= 20) {
				TagButton20.SetActive (true);
			}
			if (stringList.Count >= 21) {
				TagButton21.SetActive (true);
			}
			}

		} else {
				PauseMenuObject.SetActive (false);
			}
	}




	
//	public List<KeyValuePair<ButtonForTag, string>> getButtonForTagWithTagList(){
//		
//		UnityEngine.Object[] objectButtons = FindObjectsOfType(typeof(ButtonForTag));
//		Debug.Log ("objectbuttons: " + objectButtons.Length);
//		
//		List<ButtonForTag> buttonList = new List<ButtonForTag>();
//		foreach (ButtonForTag btn in objectButtons)
//		{
//			buttonList.Add((ButtonForTag)btn);
//		}
//		
//		buttonForTagWithTagList = new List<KeyValuePair<ButtonForTag, String>>();
//		Debug.Log ("stringlistcount: " + stringList.Count);
//		Debug.Log ("buttonlistcount: " + buttonList.Count);
//		
//		for (int i = 0; i < stringList.Count; i++)
//		{
//			string tag = stringList[i].Value;
//			ButtonForTag button = buttonList[i];
//
//			buttonForTagWithTagList.Add(new KeyValuePair<ButtonForTag, string>(button, tag));
//
//		}
//		return buttonForTagWithTagList;
//		Debug.Log ("buttonfortagwithtaglis: " + buttonForTagWithTagList.Count);
//
//	}



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


		TagButton0.SetActive(false);
		TagButton1.SetActive(false);
		TagButton2.SetActive(false);
		TagButton3.SetActive(false);
		TagButton4.SetActive(false);
		TagButton5.SetActive(false);
		TagButton6.SetActive(false);
		TagButton7.SetActive(false);
		TagButton8.SetActive(false);
		TagButton9.SetActive(false);
		TagButton10.SetActive(false);
		TagButton11.SetActive(false);
		TagButton12.SetActive(false);
		TagButton13.SetActive(false);
		TagButton14.SetActive(false);
		TagButton15.SetActive(false);
		TagButton16.SetActive(false);
		TagButton17.SetActive(false);
		TagButton18.SetActive(false);
		TagButton19.SetActive(false);
		TagButton20.SetActive(false);
		TagButton21.SetActive(false);

		stringList.Clear();

        isPause = false;
    }

    private void setPause()
    {


        MouseLook.instance.enabled = false;
        Spectator.instance.enabled = false;
        SimKeeper.instance.enabled = true;
        ContentManager.instance.enabled = false;

        PauseMenuObject.SetActive(true);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isPause = true;
    }

	public void button0Control(){
		Highlighter.instance.highlightContent(stringList[0].Key, stringList[0].Value);
	}
	public void button1Control(){
		Highlighter.instance.highlightContent(stringList[1].Key, stringList[1].Value);
	}
	public void button2Control(){
		Highlighter.instance.highlightContent(stringList[2].Key, stringList[2].Value);
	}
	public void button3Control(){
		Highlighter.instance.highlightContent(stringList[3].Key, stringList[3].Value);
	}
	public void button4Control(){
		Highlighter.instance.highlightContent(stringList[4].Key, stringList[4].Value);
	}
	public void button5Control(){
		Highlighter.instance.highlightContent(stringList[5].Key, stringList[5].Value);
	}
	public void button6Control(){
		Highlighter.instance.highlightContent(stringList[6].Key, stringList[6].Value);
	}
	public void button7Control(){
		Highlighter.instance.highlightContent(stringList[7].Key, stringList[7].Value);
	}
	public void button8Control(){
		Highlighter.instance.highlightContent(stringList[8].Key, stringList[8].Value);
	}
	
	public void button9Control(){
		Highlighter.instance.highlightContent(stringList[9].Key, stringList[9].Value);
	}
	
	public void button10Control(){
		Highlighter.instance.highlightContent(stringList[10].Key, stringList[10].Value);
	}
	
	public void button11Control(){
		Highlighter.instance.highlightContent(stringList[11].Key, stringList[11].Value);
	}
	
	public void button12Control(){
		Highlighter.instance.highlightContent(stringList[12].Key, stringList[12].Value);
	}
	
	public void button13Control(){
		Highlighter.instance.highlightContent(stringList[13].Key, stringList[13].Value);
	}
	
	public void button14Control(){
		Highlighter.instance.highlightContent(stringList[14].Key, stringList[14].Value);
	}
	public void button15Control(){
		Highlighter.instance.highlightContent(stringList[15].Key, stringList[15].Value);
	}
	
	public void button16Control(){
		Highlighter.instance.highlightContent(stringList[16].Key, stringList[16].Value);
	}
	
	public void button17Control(){
		Highlighter.instance.highlightContent(stringList[17].Key, stringList[17].Value);
	}
	
	public void button18Control(){
		Highlighter.instance.highlightContent(stringList[18].Key, stringList[18].Value);
	}
	
	public void button19Control(){
		Highlighter.instance.highlightContent(stringList[19].Key, stringList[19].Value);
	}
	
	public void button20Control(){
		Highlighter.instance.highlightContent(stringList[20].Key, stringList[20].Value);
	}
	
	public void button21Control(){
		Highlighter.instance.highlightContent(stringList[21].Key, stringList[21].Value);
	}
	



}
