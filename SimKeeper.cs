using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimKeeper : MonoBehaviour {

    List<Content> contentList;
    int[,] simTable;
    public int threshold = 1;

	// Use this for initialization
	void Start () {
        contentList = getAllContents();
        buildTagLists(contentList);
        buildSimTable();
        spawnLineRenderers();

        //for (int y = 0; y < contentList.Count; y++)
        //{
        //    string line = "";
        //    for (int x = 0; x < contentList.Count; x++)
        //    {
        //        line = line + "," +simTable[x, y];
        //    }

        //    Debug.Log("I am: " + contentList[y] + " sim: " + line);
        //}
        //List<KeyValuePair<Content, int>> simList = getSimListForContent(contentList[1]);
        //foreach (KeyValuePair<Content, int> pair in simList)
        //{
        //    Debug.Log("I am: " + contentList[1] + " sim: " + pair.Value + " to " + pair.Key);
        //}

	}

    private void buildTagLists(List<Content> contentList)
    {
        foreach (Content content in contentList)
        {
            content.buildTagList();
        }
    }

    private void buildSimTable()
    {
        simTable = new int[contentList.Count, contentList.Count];
        for (int y = 0; y < contentList.Count; y++ )
        {
            for (int x = 0; x < contentList.Count; x++)
            {
                simTable[x, y] = getScore(contentList[x], contentList[y]);
            }
        }
    }


    private int getScore(Content contentX, Content contentY){

        int score = 0;
        List<string> tagListY = contentY.getTagList();
        List<string> tagListX = contentX.getTagList();
        foreach (string tagX in tagListX)
        {
            if (tagListY.Contains(tagX))
            {
                score++;
            }
        }

        int metaScore = 0;
        List<string> metaTagListY = contentY.getMetaTagList();
        List<string> metaTagListX = contentY.getMetaTagList();
        foreach (string metaTagX in metaTagListX)
        {
            if (metaTagListY.Contains(metaTagX))
            {
                metaScore++;
            }
        }
        Debug.Log("I am Y" + contentY + " and have score " + score + " meta " + metaScore + " to X: " + contentX);

        return score + metaScore;
    }

    private void spawnLineRenderers()
    {
        int vertexY = 0;
        int vertexX = 1;
        for (int x = 0; x < contentList.Count; x++)
        {
            for (int y = x + 1; y < contentList.Count; y++)
            {
                int score = simTable[x,y];
                if (score >= threshold)
                {
                    Debug.Log("Line from " + contentList[y] + " to " + contentList[x]);
                    LineRenderer line = getNewLine();
                    contentList[y].addLine(line, vertexY);
                    contentList[x].addLine(line, vertexX);
                }
            }
        }
    }

    private LineRenderer getNewLine()
    {
        GameObject lineObject = new GameObject();
        LineRenderer linerenderer = lineObject.AddComponent<LineRenderer>();
        linerenderer.SetVertexCount(2);
        linerenderer.SetWidth(0.08f, 0.08f);
        linerenderer.SetColors(Color.white, Color.white);
        linerenderer.material = new Material(Shader.Find("Unlit/Texture"));
        return linerenderer;
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

    public List<KeyValuePair<Content, int>> getSimListForContent(Content content)
    {
        List<KeyValuePair<Content, int>> simList = new List<KeyValuePair<Content, int>>();

        int contentIndex = contentList.IndexOf(content);
        for (int i = 0; i < contentList.Count; i++)
        {
            int score = simTable[contentIndex,i];
            Content neighbor = contentList[i];
            if (neighbor != content)
            {
                simList.Add(new KeyValuePair<Content, int>(neighbor, score));
            }
        }
        simList.Sort((x, y) => y.Value.CompareTo(x.Value));

        return simList;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
