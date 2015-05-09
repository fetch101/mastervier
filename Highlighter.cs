using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Highlighter : MonoBehaviour {

    public static Highlighter instance;
    List<Content> highlightedContents = new List<Content>();

	private int scaleSize = 10;

	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// test
	public void testsync(){

		Debug.Log ("gahts no?");
	}

	public void highlightContent(string field, string value)
	{


		switch (field) {
		case "Student":
			highlightStudent(value);
			break;
		case "Semester":
			highlightSemester(value);
			break;
		case "Phase":
			highlightPhase(value);
			break;
		case "Jahr":
			highlightYear(value);
			break;
		case "Objekttyp":
			highlightObjecttype(value);
			break;
		case "Titel":
			highlightTitel(value);
			break;
		case "Untertitel":
			highlightUntertitel(value);
			break;
		case "Autor":
			highlightAutor(value);
			break;
		case "Verortung":
			highlightVerortung(value);
			break;
		case "Unterrichtung":
			highlightUR(value);
			break;
		case "Präzisierung":
			highlightPUR(value);
			break;
		default:
			highlightTag(value);
			break;
		}

	}

	void highlightTag (string value)
	{
		List<Content> contentList = getAllContents();
		foreach(Content content in contentList){
			if (content.getTagList().Contains(value))
			{
				highlightedContents.Add(content);
				spawnExclamationMarkOnContents();			}
		}
	}

	void highlightPUR (string value)
	{
		List<Content> contentList = getAllContents();
		foreach(Content content in contentList){
			if (content.PUR == value)
			{
				highlightedContents.Add(content);
				spawnExclamationMarkOnContents();			}
		}
	}

	void highlightUR (string value)
	{
		List<Content> contentList = getAllContents();
		foreach(Content content in contentList){
			if (content.UR == value)
			{
				highlightedContents.Add(content);
				spawnExclamationMarkOnContents();			}
		}
	}

	void highlightVerortung (string value)
	{
		List<Content> contentList = getAllContents();
		foreach(Content content in contentList){
			if (content.Verortung == value)
			{
				highlightedContents.Add(content);
				spawnExclamationMarkOnContents();			}
		}
	}

	void highlightAutor (string value)
	{
		List<Content> contentList = getAllContents();
		foreach(Content content in contentList){
			if (content.Autor == value)
			{
				highlightedContents.Add(content);
				spawnExclamationMarkOnContents();			}
		}
	}

	void highlightUntertitel (string value)
	{
		List<Content> contentList = getAllContents();
		foreach(Content content in contentList){
			if (content.Untertitel == value)
			{
				highlightedContents.Add(content);
				spawnExclamationMarkOnContents();			}
		}
	}

	void highlightTitel (string value)
	{
		List<Content> contentList = getAllContents();
		foreach(Content content in contentList){
			if (content.Titel == value)
			{
				highlightedContents.Add(content);
				spawnExclamationMarkOnContents();			}
		}
	}

	void highlightObjecttype (string value)
	{
		List<Content> contentList = getAllContents();
		foreach(Content content in contentList){
			if (content.Objecttype == value)
			{
				highlightedContents.Add(content);
				spawnExclamationMarkOnContents();			}
		}
	}

	void highlightYear (string value)
	{
		List<Content> contentList = getAllContents();
		foreach(Content content in contentList){
			if (content.Year == value)
			{
				highlightedContents.Add(content);
				spawnExclamationMarkOnContents();			}
		}
	}

	void highlightPhase (string value)
	{
		List<Content> contentList = getAllContents();
		foreach(Content content in contentList){
			if (content.Phase == value)
			{
				highlightedContents.Add(content);
				spawnExclamationMarkOnContents();			}
		}
	}

	void highlightSemester (string value)
	{
		List<Content> contentList = getAllContents();
		foreach(Content content in contentList){
			if (content.Semester == value)
			{
				highlightedContents.Add(content);
				spawnExclamationMarkOnContents();			}
		}
	}

	void highlightStudent (string value)
	{
		List<Content> contentList = getAllContents();
		foreach(Content content in contentList){
			if (content.Student == value)
			{
				highlightedContents.Add(content);
				spawnExclamationMarkOnContents();			}
		}
	}


//    public void highlightContentFromStudent(string name)
//    {
//        removeCurrentHighlight();
//        highlightedContents = findContentFromStudent(name);
//        foreach (Content content in highlightedContents)
//        {
//            content.transform.localScale *= scaleSize;
//        }
//    }

    public void removeCurrentHighlight()
    {

//		Destroy(gameObject.FindWithTag("ExclamationMark"));
		Object[] objectContents = FindObjectsOfType (typeof(ExclamationMark));


		foreach (Object obj in objectContents) {
			Object.Destroy (obj);

		}

		List<Content> contentList = getAllContents();
		foreach (Content content in contentList) {
			content.markCount = 0;
			content.markOffsetX = 3;
			content.markOffsetZ = -3;

		}
	}

    private List<Content> findContentFromStudent(string name)
    {
		removeCurrentHighlight();
        List<Content> contentList = getAllContents();
        List<Content> studentContentList = new List<Content>();
        foreach(Content content in contentList){
            if (content.Student == name)
            {
                studentContentList.Add(content);
				content.transform.localScale *= scaleSize;


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


	public void spawnExclamationMarkOnContents()
	{
		foreach (Content content in highlightedContents)
		{
			content.spawnHighlightObject();
		}
		highlightedContents.Clear();
	}



}
