using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ButtonForTag : MonoBehaviour {


	public string tagToHighlight;

	public static Highlighter instance;
	List<Content> highlightedContents = new List<Content>();
	List<Content> stringList;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//getTagToHighlight ();

	}

//	private PauseMenu getPauseMenu()
//	{
//		Object[] objectPauseMenu = FindObjectsOfType(typeof(PauseMenu));
//		return (PauseMenu)objectPauseMenu[0];
//
//	}
//
//
//	public void getTagToHighlight(List<PauseMenu> stringList){
//
//
//		List<KeyValuePair> stringListToHighlight = getPauseMenu().getStringListForContentInSight();
//		Debug.Log ("I have the Tag " + stringListToHighlight [1].Value + " to highlight");
//
//
//	}




	public void highlightContentFromStudent(string name)
	{
		removeCurrentHighlight();
		highlightedContents = findContentFromStudent(name);
		
		foreach (Content content in highlightedContents)
		{
			content.transform.localScale *= 2;
		}
		
	}
	
	public void removeCurrentHighlight()
	{
		foreach (Content content in highlightedContents)
		{
			content.transform.localScale /= 2;
		}
		highlightedContents.Clear();
	}
	
	private List<Content> findContentFromStudent(string name)
	{
		List<Content> contentList = getAllContents();
		List<Content> studentContentList = new List<Content>();
		foreach(Content content in contentList){
			if (content.Student == name)
			{
				studentContentList.Add(content);
			}
		}
		
		
		return studentContentList;
	}














	private List<Content> getAllContents()
	{
		
		Object[] objectContents = FindObjectsOfType(typeof(Content));
		
		List<Content> contentList = new List<Content>();
		foreach (Object obj in objectContents)
		{
			contentList.Add((Content)obj);
		}
		return contentList;
	}
	


}
