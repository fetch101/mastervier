using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonForTag : MonoBehaviour {


	public static Highlighter instance;
	List<Content> highlightedContents = new List<Content>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public void getTagToHighlight(){



	
	}


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
