using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DisplayAllTags : MonoBehaviour {

    private int i = 0;
    private Dictionary<string, int> tagDic;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (i == 100)
        {
            tagDic = SimKeeper.instance.getTagDic();
            printTags();
        }
        i++;
	}

    private void printTags()
    {
        List<List<Content>> studentList = getStudentList();
        foreach (List<Content> studentContent in studentList)
        {
            string studentString = "";
            studentString += studentContent[0].Student;
            studentString += "\n";
            foreach (Content content in studentContent)
            {
                studentString += getContentString(content);
                studentString += "\n";
            }
            studentString += "------------Student END-------------";
            Debug.Log(studentString);
        }
    }

    private string getContentString(Content content)
    {
        string contentString = "";
        //TODO only print tags you wish to have
        List<string> tagList = content.getTagList();
        List<string> metaTagList = content.getMetaTagList();
        tagList.AddRange(metaTagList);
        foreach (string tag in tagList)
        {
            contentString += tagDic[tag];
            contentString += " - ";
            contentString += tag;
            contentString += "\n";
        }
        return contentString;
    }

    private List<List<Content>> getStudentList()
    {
        List<Content> contentList = getAllContents();
        List<Content> studentContent;

        List<List<Content>> studentList = new List<List<Content>>();
        while (contentList.Count > 0)
        {
            string currStudent = contentList[0].Student;
            studentContent = contentList.FindAll(content => content.Student == currStudent);
            contentList.RemoveAll(content => content.Student == currStudent);
            studentList.Add(studentContent);
        }

        return studentList;
    }

    private List<Content> getAllContents()
    {
        UnityEngine.Object[] objectContents = FindObjectsOfType(typeof(Content));

        List<Content> contentList = new List<Content>();
        foreach (UnityEngine.Object obj in objectContents)
        {
            contentList.Add((Content)obj);
        }
        return contentList;
    }
}
