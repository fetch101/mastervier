using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WordCloud : MonoBehaviour {

    private List<GameObject> wordList = new List<GameObject>();
    private Vector3 startPos;
    private float rotation;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void drawCloud(List<Content> contentList, Vector3 startPos){
        this.startPos = startPos;
        SortedDictionary<string, int> tagDic = generateTagList(contentList);
        generateObjects(tagDic);
    }

    public void destroyCloud()
    {
        foreach (GameObject word in wordList)
        {
            GameObject.Destroy(word);
        }
        wordList.Clear();
    }

    private void generateObjects(SortedDictionary<string, int> tagDic)
    {
        float currX = startPos.x;
        float currY = startPos.y;
        float currZ = startPos.z;
        float offsetX = 5;
        float offsetY = 12;
        int pos = 0;
        foreach (KeyValuePair<string,int> tag in tagDic)
        {
            float maxCount = getMaxValue(tagDic);
            float percent = ((float)tag.Value / maxCount) * 100f;

            GameObject currTag = createTag(currX, currY, currZ, tag.Key, percent);
            currX += currTag.GetComponent<BoxCollider>().size.x + offsetX;
            if (pos > Mathf.Sqrt(tagDic.Count))
            {
                currY += offsetY;
                pos = 0;
                currX = 100;
            }
            pos++;
            
        }
    }

    private GameObject createTag(float currX, float currY, float currZ, string tag, float percent)
    {
        GameObject currTag = new GameObject();
        TextMesh currMesh = currTag.AddComponent<TextMesh>();
        currMesh.text = tag;
        currMesh.fontSize = calculateFontSize(percent);
        currMesh.color = Color.white;
        currTag.transform.position = new Vector3(currX, currY, currZ);
        BoxCollider collider = currTag.AddComponent<BoxCollider>();
        wordList.Add(currTag);
        return currTag;
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
