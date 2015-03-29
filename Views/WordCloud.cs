using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WordCloud : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void drawCloud(List<Content> contentList){
        SortedDictionary<string, int> tagDic = generateTagList(contentList);
        generateObjects(tagDic);
    }

    private void generateObjects(SortedDictionary<string, int> tagDic)
    {
        float currX = 100;
        float currY = 100;
        float currZ = 0;
        float offsetX = 10;
        float offsetY = 10;
        int pos = 0;
        foreach (KeyValuePair<string,int> tag in tagDic)
        {

            GameObject currTag = new GameObject();
            TextMesh currMesh = currTag.AddComponent<TextMesh>();
            float maxCount = getMaxValue(tagDic);
            float percent = ((float)tag.Value / maxCount) * 100f;
            Debug.Log(percent);
            currMesh.text = tag.Key;
            currMesh.fontSize = calculateFontSize(percent);
            currTag.transform.position = new Vector3(currX, currY, currZ);
            currX += offsetX;
            if (pos > Mathf.Sqrt(tagDic.Count))
            {
                currY += offsetY;
                pos = 0;
                currX = 100;
            }
            pos++;
            
        }
    }

    private float getMaxValue(SortedDictionary<string, int> tagDic)
    {
        int max = 0;
        foreach (KeyValuePair<string, int> pair in tagDic)
        {
            if (pair.Value > max)
            {
                max = pair.Value;
            }
        }
        return max;
    }

    private int calculateFontSize(float percent)
    {
        if (percent < 20)
        {
            return 10;
        }
        else if (percent < 40)
        {
            return 40;
        }
        else if (percent < 60)
        {
            return 70;
        }
        else if (percent < 80)
        {
            return 100;
        }
        else
        {
            return 140;
        }
    }

    private SortedDictionary<string, int> generateTagList(List<Content> contentList)
    {
        SortedDictionary<string, int> tagDic = new SortedDictionary<string, int>();
        foreach (Content content in contentList)
        {
            List<string> currTagList = content.getTagList();
            foreach (string tag in currTagList)
            {
                if (tagDic.ContainsKey(tag))
                {
                    tagDic[tag] = tagDic[tag] + 1;
                }
                else
                {
                    tagDic.Add(tag, 1);
                }
            }
        }

        return tagDic;
    }


}
