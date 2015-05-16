using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class SimKeeper : MonoBehaviour {

    List<Content> contentList;
    List<GameObject> sameStudentLines = new List<GameObject>();
    List<GameObject> differentStudentLines = new List<GameObject>();
    int[,] simTable;


    public static SimKeeper instance;
    public Toggle sameLineToggle;
    public Toggle differentLineToggle;

	public float threshold = 3.0f;
	public float tagWeight = 10.0f;
	public float metaTagWeight = 5.0f;
   
    private int newThreshold;
    private int newTagWeight;
    private int newMetaTagWeight;

    private int[,] metaSimTable;
	public Material materialLineSameStudent;
	public Material materialLineDifferentStudent;
    public float sameStudentLinesWidth;
    public float differentStudentLinesWidth;

    private Dictionary<string, int> tagDic = new Dictionary<string, int>();
    private bool sameStudentLinesActive = false;
    private bool differentStudentLinesActive = true;
    private bool circleLinesActive;



	void Start () {
        instance = this;
        contentList = getAllContents();
        buildSimTable();
        buildMetaSimTable();
        buildTagDic();
        spawnLines();
        ViewKeeper.instance.gameObject.GetComponent<SunView>().alignContents(getAllContents());
        ViewKeeper.instance.sunIsActive = true;
    }

    private void buildTagDic()
    {
        foreach (Content content in contentList)
        {
            List<string> tagList = content.getTagList();
            List<string> metaTagList = content.getMetaTagList();
            tagList.AddRange(metaTagList);
            tagList.Add(content.Student);
            tagList.Add(content.Phase);
            tagList.Add(content.Semester);
            tagList.Add(content.Year);
            tagList.Add(content.Objecttype);
            addTagsToDic(tagList);
        }
    }

    private void addTagsToDic(List<string> tagList)
    {
        foreach (string tag in tagList)
        {
            if (tagDic.ContainsKey(tag))
            {
                tagDic[tag]++;
            }
            else
            {
                tagDic.Add(tag, 1);
            }
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
        metaTagListY = metaTagListY.ConvertAll(item => item.ToLower());
        List<string> metaTagListX = contentX.getMetaTagList();
        metaTagListX = metaTagListX.ConvertAll(item => item.ToLower());
        foreach (string metaTagX in metaTagListX)
        {
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
        tagListY = tagListY.ConvertAll(item => item.ToLower());
        List<string> tagListX = contentX.getTagList();
        tagListX = tagListX.ConvertAll(item => item.ToLower());
        foreach (string tagX in tagListX)
        {
            if (tagListY.Contains(tagX))
            {
                score++;
            }
        }
       
        return score;
    }

    public void redrawLines()
    {
        destroyLines();
        spawnLines();
    }

    private void spawnLines()
    {
        if (sameStudentLinesActive)
        {
            spawnSameStudentLines();
        }
        if (differentStudentLinesActive)
        {
            spawnDifferentStudentLines();
        }

    }

    private void spawnSameStudentLines()
    {
        int vertexY = 0;
        int vertexX = 1;
        for (int x = 0; x < contentList.Count; x++)
        {
            for (int y = x + 1; y < contentList.Count; y++)
            {
                int score = (int)Math.Round(simTable[x, y] / 10f * tagWeight + metaSimTable[x, y] / 10f * metaTagWeight, MidpointRounding.AwayFromZero);
                if (score >= threshold)
                {
                    if (contentList[y].Student.Equals(contentList[x].Student))
                    {
                        LineRenderer line = getNewLine();
                        line.SetWidth(sameStudentLinesWidth, sameStudentLinesWidth);
                        line.material = materialLineSameStudent;
                        contentList[y].addSameStudentLine(line, vertexY);
                        contentList[x].addSameStudentLine(line, vertexX);
                        sameStudentLines.Add(line.gameObject);

                    }
                }
            }
        }
    }

    private void spawnDifferentStudentLines()
    {
        int vertexY = 0;
        int vertexX = 1;
        for (int x = 0; x < contentList.Count; x++)
        {
            for (int y = x + 1; y < contentList.Count; y++)
            {
                int score = (int)Math.Round(simTable[x, y] / 10f * tagWeight + metaSimTable[x, y] / 10f * metaTagWeight, MidpointRounding.AwayFromZero);
                if (score >= threshold)
                {
                    if (!contentList[y].Student.Equals(contentList[x].Student))
                    {
                        LineRenderer line = getNewLine();
                        line.SetWidth(differentStudentLinesWidth, differentStudentLinesWidth);
                        line.material = materialLineDifferentStudent;
                        contentList[y].addDifferentStudentLine(line, vertexY);
                        contentList[x].addDifferentStudentLine(line, vertexX);
                        differentStudentLines.Add(line.gameObject);
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

    public Dictionary<string, int> getTagDic()
    {
        return tagDic;
    }
	
	void Update () {
	
	}

	public void adjustThreshold(float newThreshold){
		if (threshold != newThreshold)
		{	
            threshold = newThreshold;
            redrawLines();
		}

	}

	public void adjustTagWeight(float newTagweight){
		if (tagWeight != newTagweight)
		{	
            tagWeight = newTagweight;
            redrawLines();
		}
			
	}

	public void adjustMetatagweight(float newMetatagweight){
		if (metaTagWeight != newMetatagweight)
		{	
            metaTagWeight = newMetatagweight;
            redrawLines();
		}	
	}

    
    public void destroyLines()
    {
        destroyDifferentStudentLines();
        destroySameStudentLines();
    }

    private void destroySameStudentLines()
    {
        removeSameStudentLinesFromContent();
        foreach (GameObject lineRenderer in sameStudentLines)
        {
            GameObject.Destroy(lineRenderer);
        }
        sameStudentLines.Clear();
    }

    private void destroyDifferentStudentLines()
    {
        removeDifferentStudentLinesFromContent();
        foreach (GameObject lineRenderer in differentStudentLines)
        {
            GameObject.Destroy(lineRenderer);
        }
        differentStudentLines.Clear();
    }

    private void removeSameStudentLinesFromContent()
    {
        foreach (Content content in contentList)
        {
            content.removeSameStudentLines();
        }
    }

    private void removeDifferentStudentLinesFromContent()
    {
        foreach (Content content in contentList)
        {
            content.removeDifferentLines();
        }
    }

    public void setAllLines(bool active)
    {
        setSameStudentLines(active);
        setDifferentStudentLines(active);
    }

    public void setSameStudentLines(bool active)
    {
        sameLineToggle.isOn = active;
        this.sameStudentLinesActive = active;
        if (active)
        {
            destroySameStudentLines();
            spawnSameStudentLines();
        }
        else
        {
            destroySameStudentLines();
        }
    }

    public void setDifferentStudentLines(bool active)
    {
        differentLineToggle.isOn = active;
        this.differentStudentLinesActive = active;
        if (active)
        {
            destroyDifferentStudentLines();
            spawnDifferentStudentLines();
        }
        else
        {
            destroyDifferentStudentLines();
        }

    }

}
