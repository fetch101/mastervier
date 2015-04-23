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

	public GameObject TagButton0_0;
	public GameObject TagButton0_1;
	public GameObject TagButton0_2;
	public GameObject TagButton0_3;
	public GameObject TagButton0_4;
	public GameObject TagButton0_5;
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

	public GameObject TagValue_0;
	public GameObject TagValue_1;
	public GameObject TagValue_2;
	public GameObject TagValue_3;
	public GameObject TagValue_4;
	public GameObject TagValue_5;
	public GameObject TagValue_6;
	public GameObject TagValue_7;
	public GameObject TagValue_8;
	public GameObject TagValue_9;
	public GameObject TagValue_10;
	public GameObject TagValue_11;
	public GameObject TagValue_12;
	public GameObject TagValue_13;
	public GameObject TagValue_14;
	public GameObject TagValue_15;
	public GameObject TagValue_16;
	public GameObject TagValue_17;
	public GameObject TagValue_18;
	public GameObject TagValue_19;
	public GameObject TagValue_20;
	public GameObject TagValue_21;

	public GameObject TagKey_0;
	public GameObject TagKey_1;
	public GameObject TagKey_2;
	public GameObject TagKey_3;

	

	// nur um auszuprobieren:
	Text TagValue_0Text;
	Text TagValue_1Text;
	Text TagValue_2Text;
	Text TagValue_3Text;
	Text TagValue_4Text;
	Text TagValue_5Text;
	Text TagValue_6Text;
	Text TagValue_7Text;
	Text TagValue_8Text;
	Text TagValue_9Text;
	Text TagValue_10Text;
	Text TagValue_11Text;
	Text TagValue_12Text;
	Text TagValue_13Text;
	Text TagValue_14Text;
	Text TagValue_15Text;
	Text TagValue_16Text;
	Text TagValue_17Text;
	Text TagValue_18Text;
	Text TagValue_19Text;
	Text TagValue_20Text;
	Text TagValue_21Text;

	Text TagKey_0Text;
	Text TagKey_1Text;
	Text TagKey_2Text;
	Text TagKey_3Text;

	
	public GameObject PauseMenuObject;
	public GameObject DisplayTagsRuntimeCanvas;
    private bool isPause;

    // Use this for initialization
    void Start()
    {

		TagValue_0 = GameObject.Find ("TagValue_0");
		TagValue_1 = GameObject.Find ("TagValue_1");
		TagValue_2 = GameObject.Find ("TagValue_2");
		TagValue_3 = GameObject.Find ("TagValue_3");
		TagValue_4 = GameObject.Find ("TagValue_4");
		TagValue_5 = GameObject.Find ("TagValue_5");
		TagValue_6 = GameObject.Find ("TagValue_6");
		TagValue_7 = GameObject.Find ("TagValue_7");
		TagValue_8 = GameObject.Find ("TagValue_8");
		TagValue_9 = GameObject.Find ("TagValue_9");
		TagValue_10 = GameObject.Find ("TagValue_10");
		TagValue_11 = GameObject.Find ("TagValue_11");
		TagValue_12 = GameObject.Find ("TagValue_12");
		TagValue_13 = GameObject.Find ("TagValue_13");
		TagValue_14 = GameObject.Find ("TagValue_14");
		TagValue_15 = GameObject.Find ("TagValue_15");
		TagValue_16 = GameObject.Find ("TagValue_16");
		TagValue_17 = GameObject.Find ("TagValue_17");
		TagValue_18 = GameObject.Find ("TagValue_18");
		TagValue_19 = GameObject.Find ("TagValue_19");
		TagValue_20 = GameObject.Find ("TagValue_20");
		TagValue_21 = GameObject.Find ("TagValue_21");

		TagKey_0 = GameObject.Find ("TagKey_0");
		TagKey_1 = GameObject.Find ("TagKey_1");
		TagKey_2 = GameObject.Find ("TagKey_2");
		TagKey_3 = GameObject.Find ("TagKey_3");

		
		TagButton0_0 = GameObject.Find ("TagButton0_0");
		TagButton0_1 = GameObject.Find ("TagButton0_1");
		TagButton0_2 = GameObject.Find ("TagButton0_2");
		TagButton0_3 = GameObject.Find ("TagButton0_3");
		TagButton0_4 = GameObject.Find ("TagButton0_4");
		TagButton0_5 = GameObject.Find ("TagButton0_5");
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
		DisplayTagsRuntimeCanvas = GameObject.Find ("DisplayTagsRuntimeCanvas");
		DisplayTagsRuntimeCanvas.SetActive (false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isPause = true;

    }

    // Update is called once per frame
    void Update()
    {

		isInSight = CheckRay ();

		showTagsAtRuntime();

		
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();

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
//		if (contentInSight.Semester != "") {
//			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Semester", contentInSight.Semester);
//			stringList.Add(curTag);
//		}
//		if (contentInSight.Phase != "") {
//			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Phase", contentInSight.Phase);
//			stringList.Add(curTag);
//		}
//		if (contentInSight.Year != "") {
//			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Jahr", contentInSight.Year);
//			stringList.Add(curTag);
//		}
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

//	public List<TagValueTextObject> tagValueTextObjectList (){
//
//
//
//		UnityEngine.Object[] tagValueTextObjects = FindObjectsOfType(typeof(TagValueTextObject));
//		
//		List<TagValueTextObject> tagValueTextObjectList = new List<TagValueTextObject>();
//
//
//		return tagValueTextObjectList;
//		
//	}
	
	
//	void OnGUI()
//	{
//		if (isPause) {
//
//			GUILayout.Label ("Game is paused!");
//			if (GUILayout.Button ("Line View"))
//				ViewKeeper.instance.lineView ();
//			if (GUILayout.Button ("Cube View"))
//				ViewKeeper.instance.cubeView ();
//			if (GUILayout.Button ("Sun View"))
//				ViewKeeper.instance.sunView ();
//			if (GUILayout.Button ("TEST Wordcloud"))
//				ViewKeeper.instance.wordCloud ();
////            if (GUILayout.Button("TEST Highlight DarioSala"))
////                Highlighter.instance.highlightContentFromStudent("DarioSala");
////            if (GUILayout.Button("TEST Highlight AliceGut"))
//////                Highlighter.instance.highlightContentFromStudent("AliceGut");
//			if (GUILayout.Button ("TEST Remove Highlight"))
//				Highlighter.instance.removeCurrentHighlight ();     
//
//		}
//	}





	void showTagsAtRuntime(){

//		UnityEngine.Object[] tagValueTextObjects = FindObjectsOfType(typeof(TagValueTextObject));
//		List<TagValueTextObject> tagValueTextObjectList = new List<TagValueTextObject>();
//		UnityEngine.Object[] tagKeyTextObjects = FindObjectsOfType(typeof(TagKeyTextObject));
//		List<TagKeyTextObject> tagKeyTextObjectList = new List<TagKeyTextObject>();
//		if (isInSight == true) {
//		int i;
//		for (i= 0; i < stringList.Count; i++){
//
//			foreach(GameObject TagKeyTextObject in tagKeyTextObjectList)
//			{
//				gameObject = tagKeyTextObjectList[i];
//				gameObject.SetActive(true);
//				i++;
//					Debug.Log("I have createt a Button with the name" + gameObject );
//			}
//		}
//		for (int j= 0; j < stringList.Count; j++){
//			
//			foreach(GameObject TagValueTextObject in tagValueTextObjectList)
//			{
//				GameObject = tagValueTextObjectList[i];
//				GameObject.SetActive(true);
//				j++;
//					Debug.Log("I have createt a flutton with the name" + gameObject );
//			}
//		}
//	}

		// TODO: Only do this if Content in sight has changed!!!

		if (isInSight == true) {


			DisplayTagsRuntimeCanvas.SetActive (true);
			int i = 0;
			int j = 0;


				while (stringList.Count >= i && i == j) {
					if(stringList [i].Value != ""){
					TagValue_0.SetActive (true);
					TagKey_0.SetActive(true);
					TagValue_0Text = TagValue_0.GetComponent<Text> ();
					TagValue_0Text.text = stringList [i].Value;
					TagKey_0Text = TagKey_0.GetComponent<Text> ();
					TagKey_0Text.text = stringList [i].Key;
					j++;
					} else { 
						i++;
						j++;
					}
				}
				i = j;

				while (stringList.Count >= i && i == j) {
					if(stringList [i].Value != ""){
					TagValue_1.SetActive (true);
					TagKey_1.SetActive(true);
					TagValue_1Text = TagValue_1.GetComponent<Text> ();
					TagValue_1Text.text = stringList [i].Value;
					TagKey_1Text = TagKey_1.GetComponent<Text> ();
					TagKey_1Text.text = stringList [i].Key;
					j++;
					} else { 
						i++;
						j++;
					}
				}
				i = j;
				while (stringList.Count >= i && i == j) {
					if(stringList [i].Value != ""){
					TagValue_2.SetActive (true);
					TagKey_2.SetActive(true);
					TagValue_2Text = TagValue_2.GetComponent<Text> ();
					TagValue_2Text.text = stringList [i].Value;
					TagKey_2Text = TagKey_2.GetComponent<Text> ();
					TagKey_2Text.text = stringList [i].Key;
					j++;
					} else { 
						i++;
						j++;
					}
				}
				i = j;



			}

	}

//		else {
//			DisplayTagsRuntimeCanvas.SetActive(false);
//			TagValue_0.SetActive(false);
//			TagValue_1.SetActive(false);
//			TagValue_2.SetActive(false);
//			TagValue_3.SetActive(false);
//			TagValue_4.SetActive(false);
//			TagValue_5.SetActive(false);
//			TagValue_6.SetActive(false);
//			TagValue_7.SetActive(false);
//			TagValue_8.SetActive(false);
//			TagValue_9.SetActive(false);
//			TagValue_10.SetActive(false);
//
//		}
//	}

		
			

	//NOED LOESCHE WEGE DE BERECHNIG

//		if (isInSight == true && isPause) {
//			
//			
//			GUI.TextField (new Rect (810, 220, ((6 * textFieldWidth) + 110), numberOfDots), "");
//			numberOfDots = (stringList.Count * 20) + 5;
//			
//			int offsetCounter = 10;
//			foreach (KeyValuePair<String, String> tag in stringList) {
//				
//				GUI.Label (new Rect (815, 210 + offsetCounter, 300, 300), tag.Key);
//				GUI.Label (new Rect (915, 210 + offsetCounter, 3000, 300), tag.Value);
//
//				if (tag.Value.Length > textFieldWidth) {
//					textFieldWidth = tag.Value.Length;
//				}
//				
//				offsetCounter += 20;
//			}
//		} else {
		//			textFieldWidth = }

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
		PauseMenuObject.SetActive (false);

		
		//
//		TagButton0.SetActive(false);
//		TagButton1.SetActive(false);
//		TagButton2.SetActive(false);
//		TagButton3.SetActive(false);
//		TagButton4.SetActive(false);
//		TagButton5.SetActive(false);
//		TagButton6.SetActive(false);
//		TagButton7.SetActive(false);
//		TagButton8.SetActive(false);
//		TagButton9.SetActive(false);
//		TagButton10.SetActive(false);
//		TagButton11.SetActive(false);
//		TagButton12.SetActive(false);
//		TagButton13.SetActive(false);
//		TagButton14.SetActive(false);
//		TagButton15.SetActive(false);
//		TagButton16.SetActive(false);
//		TagButton17.SetActive(false);
//		TagButton18.SetActive(false);
//		TagButton19.SetActive(false);
//		TagButton20.SetActive(false);
//		TagButton21.SetActive(false);

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
		DisplayTagsRuntimeCanvas.SetActive (true);

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
