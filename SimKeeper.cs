using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimKeeper : MonoBehaviour {

    List<Content> contentList;
    List<GameObject> lineRenderList = new List<GameObject>();
    int[,] simTable;
    public int startThreshold = 3;
    private int threshold = 3;

    public static SimKeeper instance;



	void Start () {
        instance = this;
        contentList = getAllContents();
        buildSimTable();
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
        List<string> metaTagListX = contentX.getMetaTagList();
        foreach (string metaTagX in metaTagListX)
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
                if (score >= startThreshold)
                {
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
        lineRenderList.Add(lineObject);
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
	
	void Update () {
	
	}

    void OnGUI()
    {

        int thresholdOld = threshold;
        threshold = (int)GUI.VerticalSlider(new Rect(1220, 25, 100, 300), (float)threshold, 10.0F, 0.0F);
        if (thresholdHasChanged(threshold, thresholdOld))
        {
            startThreshold = threshold;
            removeLinesFromContent();
            destroyLineRenderObjects();
            spawnLineRenderers();
        }
        GUI.Label(new Rect(Screen.width - 130, 25, 200, Screen.height), "Current Threshold: " + threshold);
        
    }

    private bool thresholdHasChanged(int thresholdNew, int thresholdOld)
    {
        if (thresholdNew != thresholdOld)
        {
            threshold = thresholdNew;
            return true;
        }
        return false;
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
