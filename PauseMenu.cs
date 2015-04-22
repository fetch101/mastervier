using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;



public class PauseMenu : MonoBehaviour {
    
	private List<KeyValuePair<String, String>> displayStringList;


    public GUISkin OpenSansGuiSkin;
	
	public int numberOfTags = 0;
	public int numberOfDots = 10;

	public int i = 0;

	private float textFieldWidth;
	
	private bool contentInSight = false;

	Content objectToDisplayTags;

	public GameObject PauseMenuObject;

    private bool isPause;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isPause = true;

    }

    // Update is called once per frame
    void Update()
    {

		contentInSight = CheckRay ();

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
			getDisplayStringListForContentInSight (objectToDisplayTags);

			return true;

		}else{
			return false;			
		}
	}

	public List<KeyValuePair<string, string>> getDisplayStringListForContentInSight(Content contentInSight)
	{
		
		displayStringList = new List<KeyValuePair<String, String>> ();
		
		if (contentInSight.Student != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Student", contentInSight.Student);
			displayStringList.Add(curTag);
		}
		if (contentInSight.Semester != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Semester", contentInSight.Semester);
			displayStringList.Add(curTag);
		}
		if (contentInSight.Phase != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Phase", contentInSight.Phase);
			displayStringList.Add(curTag);
		}
		if (contentInSight.Year != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Jahr", contentInSight.Year);
			displayStringList.Add(curTag);
		}
		if (contentInSight.Objecttype != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Objekttyp", contentInSight.Objecttype);
			displayStringList.Add(curTag);
		}
		if (contentInSight.Titel != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Titel", contentInSight.Titel);
			displayStringList.Add(curTag);
		}
		if (contentInSight.Untertitel != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Untertitel", contentInSight.Untertitel);
			displayStringList.Add(curTag);
		}
		if (contentInSight.Autor != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Autor", contentInSight.Autor);
			displayStringList.Add(curTag);
		}
		if (contentInSight.Verortung != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Verortung", contentInSight.Verortung);
			displayStringList.Add(curTag);
		}
		if (contentInSight.UR != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Unterrichtung", contentInSight.UR);
			displayStringList.Add(curTag);
		}
		if (contentInSight.PUR != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Präzisierung", contentInSight.PUR);
			displayStringList.Add(curTag);
		}
		if (contentInSight.Tag0 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("Keywords", contentInSight.Tag0);
			displayStringList.Add(curTag);
		}
		if (contentInSight.Tag1 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag1);
			displayStringList.Add(curTag);
		}
		if (contentInSight.Tag2 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag2);
			displayStringList.Add(curTag);
		}
		if (contentInSight.Tag3 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag3);
			displayStringList.Add(curTag);
		}
		if (contentInSight.Tag4 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag4);
			displayStringList.Add(curTag);
		}
		if (contentInSight.Tag5 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag5);
			displayStringList.Add(curTag);
		}
		if (contentInSight.Tag6 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag6);
			displayStringList.Add(curTag);
		}
		if (contentInSight.Tag7 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag7);
			displayStringList.Add(curTag);
		}
		if (contentInSight.Tag8 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag8);
			displayStringList.Add(curTag);
		}
		if (contentInSight.Tag9 != "") {
			KeyValuePair<String, String> curTag = new KeyValuePair<String, String>("", contentInSight.Tag9);
			displayStringList.Add(curTag);
		}

		return displayStringList;
		
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
            if (GUILayout.Button("TEST Remove Highlight"))
                Highlighter.instance.removeCurrentHighlight();     

				}

        if (contentInSight && isPause)
        {
            displayTags(810f, 220f);
        }
    }

    private void displayTags(float left, float top)
    {

        GUI.TextField(new Rect((Screen.width / 2) - 280, (Screen.height / 2) - 345, ((8 * textFieldWidth) + 125), numberOfDots), "");
        numberOfDots = (displayStringList.Count * 20) + 5;

        float offsetCounter = 10f;
        foreach (KeyValuePair<String, String> tag in displayStringList)
        {

            GUI.Label(new Rect((Screen.width / 2) - 275, ((Screen.height / 2) - 355) + offsetCounter, 300, 300), tag.Key);
            GUI.Label(new Rect((Screen.width / 2) - 165, (Screen.height / 2) - 355 + offsetCounter, 3000, 300), tag.Value);

            if (tag.Value.Length > textFieldWidth)
            {
                textFieldWidth = tag.Value.Length;
            }

            offsetCounter += 20;
        }
    }


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
        ContentManager.instance.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        SimKeeper.instance.enabled = false;
        Cursor.visible = false;
        PauseMenuObject.SetActive(false);



		displayStringList.Clear();

        isPause = false;
    }

    private void setPause()
    {
        MouseLook.instance.enabled = false;
        Spectator.instance.enabled = false;
        ContentManager.instance.enabled = false;

        SimKeeper.instance.enabled = true;
		PauseMenuObject.SetActive (true);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isPause = true;
    }

	public void button0Control(){
		Highlighter.instance.highlightContent(displayStringList[0].Key, displayStringList[0].Value);
	}
	public void button1Control(){
		Highlighter.instance.highlightContent(displayStringList[1].Key, displayStringList[1].Value);
	}
	public void button2Control(){
		Highlighter.instance.highlightContent(displayStringList[2].Key, displayStringList[2].Value);
	}
	public void button3Control(){
		Highlighter.instance.highlightContent(displayStringList[3].Key, displayStringList[3].Value);
	}
	public void button4Control(){
		Highlighter.instance.highlightContent(displayStringList[4].Key, displayStringList[4].Value);
	}
	public void button5Control(){
		Highlighter.instance.highlightContent(displayStringList[5].Key, displayStringList[5].Value);
	}
	public void button6Control(){
		Highlighter.instance.highlightContent(displayStringList[6].Key, displayStringList[6].Value);
	}
	public void button7Control(){
		Highlighter.instance.highlightContent(displayStringList[7].Key, displayStringList[7].Value);
	}
	public void button8Control(){
		Highlighter.instance.highlightContent(displayStringList[8].Key, displayStringList[8].Value);
	}
	
	public void button9Control(){
		Highlighter.instance.highlightContent(displayStringList[9].Key, displayStringList[9].Value);
	}
	
	public void button10Control(){
		Highlighter.instance.highlightContent(displayStringList[10].Key, displayStringList[10].Value);
	}
	
	public void button11Control(){
		Highlighter.instance.highlightContent(displayStringList[11].Key, displayStringList[11].Value);
	}
	
	public void button12Control(){
		Highlighter.instance.highlightContent(displayStringList[12].Key, displayStringList[12].Value);
	}
	
	public void button13Control(){
		Highlighter.instance.highlightContent(displayStringList[13].Key, displayStringList[13].Value);
	}
	
	public void button14Control(){
		Highlighter.instance.highlightContent(displayStringList[14].Key, displayStringList[14].Value);
	}
	public void button15Control(){
		Highlighter.instance.highlightContent(displayStringList[15].Key, displayStringList[15].Value);
	}
	
	public void button16Control(){
		Highlighter.instance.highlightContent(displayStringList[16].Key, displayStringList[16].Value);
	}
	
	public void button17Control(){
		Highlighter.instance.highlightContent(displayStringList[17].Key, displayStringList[17].Value);
	}
	
	public void button18Control(){
		Highlighter.instance.highlightContent(displayStringList[18].Key, displayStringList[18].Value);
	}
	
	public void button19Control(){
		Highlighter.instance.highlightContent(displayStringList[19].Key, displayStringList[19].Value);
	}
	
	public void button20Control(){
		Highlighter.instance.highlightContent(displayStringList[20].Key, displayStringList[20].Value);
	}
	
	public void button21Control(){
		Highlighter.instance.highlightContent(displayStringList[21].Key, displayStringList[21].Value);
	}
	



}
