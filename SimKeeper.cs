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

        for (int y = 0; y < contentList.Count; y++)
        {
            string line = "";
            for (int x = 0; x < contentList.Count; x++)
            {
                line = line + "," +simTable[x, y];
            }

            Debug.Log("I am: " + contentList[y] + " sim: " + line);
        }

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
        foreach (string tagX in contentX.getTagList())
        {
            if (tagListY.Contains(tagX))
            {
                score++;
            }
        }

        int metaScore = 0;
        List<string> metaTagListY = contentY.getMetaTagList();
        foreach (string metaTagX in contentX.getMetaTagList())
        {
            if (metaTagListY.Contains(metaTagX))
            {
                metaScore++;
            }
        }

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
                    LineRenderer line = getNewLine();
                    contentList[y].addLine(line, vertexY);
                    contentList[x].addLine(line, vertexX);
                }
            }
        }
    }

    private static LineRenderer getNewLine()
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
