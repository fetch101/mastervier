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
            Dictionary<string, int> studentDic = new Dictionary<string, int>();
            studentDic.Add(studentContent[0].Student, 0);
            foreach (Content content in studentContent)
            {
                fillContentToDic(content, studentDic);
            }
            string outputstring = "";
            foreach (KeyValuePair<string, int> pair in studentDic)
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

        //if (content.Tag0 != "" && !studentDic.ContainsKey(content.Tag0))
        //{
        //    studentDic.Add(content.Tag0, tagDic[content.Tag0]);
        //}
        //if (content.Tag1 != "" && !studentDic.ContainsKey(content.Tag1))
        //{
        //    studentDic.Add(content.Tag1, tagDic[content.Tag1]);
        //}
        //if (content.Tag2 != "" && !studentDic.ContainsKey(content.Tag2))
        //{
        //    studentDic.Add(content.Tag2, tagDic[content.Tag2]);
        //}
        //if (content.Tag3 != "" && !studentDic.ContainsKey(content.Tag3))
        //{
        //    studentDic.Add(content.Tag3, tagDic[content.Tag3]);
        //}
        //if (content.Tag4 != "" && !studentDic.ContainsKey(content.Tag4))
        //{
        //    studentDic.Add(content.Tag4, tagDic[content.Tag4]);
        //}
        //if (content.Tag5 != "" && !studentDic.ContainsKey(content.Tag5))
        //{
        //    studentDic.Add(content.Tag5, tagDic[content.Tag5]);
        //}
        //if (content.Tag6 != "" && !studentDic.ContainsKey(content.Tag6))
        //{
        //    studentDic.Add(content.Tag6, tagDic[content.Tag6]);
        //}
        //if (content.Tag7 != "" && !studentDic.ContainsKey(content.Tag7))
        //{
        //    studentDic.Add(content.Tag7, tagDic[content.Tag7]);
        //}
        //if (content.Tag8 != "" && !studentDic.ContainsKey(content.Tag8))
        //{
        //    studentDic.Add(content.Tag8, tagDic[content.Tag8]);
        //}
        //if (content.Tag9 != "" && !studentDic.ContainsKey(content.Tag9))
        //{
        //    studentDic.Add(content.Tag9, tagDic[content.Tag9]);
        //}
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
