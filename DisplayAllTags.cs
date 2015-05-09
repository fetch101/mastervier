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

//        if (i == 100)
//        {
//            tagDic = SimKeeper.instance.getTagDic();
//            printTags();
//        }
//        i++;
	}

    private void printTags()
    {
        List<List<Content>> studentList = getStudentList();
        foreach (List<Content> studentContent in studentList)
        {
            Dictionary<string, int> studentDic = new Dictionary<string, int>();
            studentDic.Add(studentContent[0].Student, 1000);
            foreach (Content content in studentContent)
            {
                fillContentToDic(content, studentDic);
            }

            List<KeyValuePair<string, int>> sortedStudentList = new List<KeyValuePair<string, int>>();
            foreach (KeyValuePair<string, int> pair in studentDic)
            {
                sortedStudentList.Add(pair);
            }
            sortedStudentList.Sort((x, y) => y.Value.CompareTo(x.Value));
            string outputstring = "";
            foreach (KeyValuePair<string, int> pair in sortedStudentList)
            {
                outputstring += pair.Value;
                outputstring += " - ";
                outputstring += pair.Key;
                outputstring += "\n";
            }
            Debug.Log(outputstring);
        }
    }

    private void fillContentToDic(Content content, Dictionary<string, int> studentDic)
    {
        List<string> tagList = content.getTagList();


        if (content.Autor != "")
        {
            if (!studentDic.ContainsKey(content.Autor))
            {
                    studentDic.Add(content.Autor, 1);
            }
            else
            {
                studentDic[content.Autor]++;
            }
        }
        if (content.Verortung != "")
        {
            if (!studentDic.ContainsKey(content.Verortung))
            {
                studentDic.Add(content.Verortung, 1);
            }
            else
            {
                studentDic[content.Verortung]++;
            }
        }

        if (content.UR != "")
        {
            if (!studentDic.ContainsKey(content.UR))
            {
                studentDic.Add(content.UR, 1);
            }
            else
            {
                studentDic[content.UR]++;
            }
        }

        if (content.PUR != "")
        {
            if (!studentDic.ContainsKey(content.PUR))
            {
                studentDic.Add(content.PUR, 1);
            }
            else
            {
                studentDic[content.PUR]++;
            }
        }


        foreach (string tag in tagList)
        {
            if (!studentDic.ContainsKey(tag))
            {
                studentDic.Add(tag, 1);
            }
            else
            {
                studentDic[tag]++;
            }
        }


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
