using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class SimKeeper : MonoBehaviour {

    List<Content> contentList;
    List<GameObject> lineRenderList = new List<GameObject>();
    int[,] simTable;
    

    public static SimKeeper instance;

	public float threshold = 2.0f;
	public float tagWeight = 10.0f;
	public float metaTagWeight = 10.0f;
   
    private int newThreshold;
    private int newTagWeight;
    private int newMetaTagWeight;

    private int[,] metaSimTable;
	public Material materialLineSameStudent;
	public Material materialLineDifferentStudent;


	void Start () {
        instance = this;
        contentList = getAllContents();
        buildSimTable();
        buildMetaSimTable();
        spawnLineRenderers();
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

    private void buildMetaSimTable()
    {
        metaSimTable = new int[contentList.Count, contentList.Count];
        for (int y = 0; y < contentList.Count; y++)
        {
            for (int x = 0; x < contentList.Count; x++)
            {
                metaSimTable[x, y] = getMetaScore(contentList[x], contentList[y]);
            }
        }
    }

    private int getMetaScore(Content contentX, Content contentY)
    {
        int metaScore = 0;
        List<string> metaTagListY = contentY.getMetaTagList();
        foreach (string metaTagY in metaTagListY)
        {
            metaTagY.ToLower();
        }
        List<string> metaTagListX = contentX.getMetaTagList();
        foreach (string metaTagX in metaTagListX)
        {
            metaTagX.ToLower();
            if (metaTagListY.Contains(metaTagX))
            {
                metaScore++;
            }
        }
        return metaScore;
    }


    private int getScore(Content contentX, Content contentY){

        int score = 0;
        List<string> tagListY = contentY.getTagList();
        foreach (string tagY in tagListY)
        {
            tagY.ToLower();
        }
        List<string> tagListX = contentX.getTagList();
        foreach (string tagX in tagListX)
        {
            tagX.ToLower();
            if (tagListY.Contains(tagX))
            {
                score++;
            }
        }
       
        return score;
    }

    private void spawnLineRenderers()
    {
        int vertexY = 0;
        int vertexX = 1;
        for (int x = 0; x < contentList.Count; x++)
        {
            for (int y = x + 1; y < contentList.Count; y++)
            {
                int score = (int)Math.Round(simTable[x,y] / 10f * tagWeight + metaSimTable[x,y] / 10f * metaTagWeight, MidpointRounding.AwayFromZero);
                if (score >= threshold)
                {

					if (contentList[y].Student.Equals(contentList[x].Student) )

					{
						LineRenderer line = getNewLine();
						line.SetWidth(0.1f, 0.1f);
						line.material = materialLineSameStudent;

						contentList[y].addLine(line, vertexY);
						contentList[x].addLine(line, vertexX);

					}else{
						LineRenderer line = getNewLine();
						contentList[y].addLine(line, vertexY);
						contentList[x].addLine(line, vertexX);
						line.material = materialLineDifferentStudent;

					}


                }
            }
        }
    }

    private LineRenderer getNewLine()
    {
        GameObject lineObject = new GameObject();
        LineRenderer linerenderer = lineObject.AddComponent<LineRenderer>();
        linerenderer.SetVertexCount(2);
        linerenderer.SetWidth(0.8f, 0.8f);
        linerenderer.material = new Material(Shader.Find("Unlit/Texture"));
        lineRenderList.Add(lineObject);
        return linerenderer;
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

	//TODO: Werden die Linien ohne den Angaben "Student", "Jahr", "Phase", "Semester" und "Objecttype" gezeichnet?????? Müssten sie ja, sonst hats zuviele übereinstimmungen
    public List<KeyValuePair<Content, int>> getSimListForContent(Content content)
    {
        List<KeyValuePair<Content, int>> simList = new List<KeyValuePair<Content, int>>();

        int contentIndex = contentList.IndexOf(content);
        for (int i = 0; i < contentList.Count; i++)
        {
            int score = simTable[contentIndex, i] + metaSimTable[contentIndex, i];
            Content neighbor = contentList[i];
            if (neighbor != content)
            {
                simList.Add(new KeyValuePair<Content, int>(neighbor, score));
            }
        }
        simList.Sort((x, y) => y.Value.CompareTo(x.Value));

        return simList;
    }
	
	void Update () {


	
	}

    void OnGUI()
    {

    }

	public void adjustThreshold(float newThreshold){
		if (threshold != newThreshold)
		{	threshold = newThreshold;
			removeLinesFromContent();
			destroyLineRenderObjects();
			spawnLineRenderers();
		}

	}

	public void adjustTagWeight(float newTagweight){
		if (tagWeight != newTagweight)
		{	tagWeight = newTagweight;
			removeLinesFromContent();
			destroyLineRenderObjects();
			spawnLineRenderers();
		}
			
	}

	public void adjustMetatagweight(float newMetatagweight){
		if (metaTagWeight != newMetatagweight)
		{	tagWeight = newMetatagweight;
			removeLinesFromContent();
			destroyLineRenderObjects();
			spawnLineRenderers();
		}	
	}



    
    private void destroyLineRenderObjects()
    {
        foreach (GameObject lineRenderer in lineRenderList)
        {
            GameObject.Destroy(lineRenderer);
        }
        lineRenderList.RemoveRange(0, lineRenderList.Count);
    }

    private void removeLinesFromContent()
    {
        foreach (Content content in contentList)
        {
            content.removeLines();
        }
    }
}
