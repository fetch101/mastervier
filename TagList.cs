using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class TagList : MonoBehaviour {

    public GameObject tagGameObjectPrefab;
    public int itemCount = 20, columnCount = 1;
    public List<GameObject> displayStringList;
    public Dictionary<string, GameObject> childGameObjects;
    private List<GameObject> runtimeTags = new List<GameObject>();

    void Start()
    {
            RectTransform rowRectTransform = tagGameObjectPrefab.GetComponent<RectTransform>();
            RectTransform containerRectTransform = gameObject.GetComponent<RectTransform>();

            //calculate the width and height of each child item.
            float width = containerRectTransform.rect.width / columnCount;
            float ratio = width / rowRectTransform.rect.width;
            float height = rowRectTransform.rect.height * ratio;
            int rowCount = itemCount / columnCount;
            if (itemCount % rowCount > 0)
                rowCount++;

            //adjust the height of the container so that it will just barely fit all its children
            float scrollHeight = height * rowCount;
            containerRectTransform.offsetMin = new Vector2(containerRectTransform.offsetMin.x, -scrollHeight / 2);
            containerRectTransform.offsetMax = new Vector2(containerRectTransform.offsetMax.x, scrollHeight / 2);

            int j = 0;
            for (int i = 0; i < itemCount; i++)
            {
                //this is used instead of a double for loop because itemCount may not fit perfectly into the rows/columns
                if (i % columnCount == 0)
                    j++;

                //create a new item, name it, and set the parent
                GameObject newTag = Instantiate(tagGameObjectPrefab) as GameObject;
                newTag.name = gameObject.name + " tag line at (" + i + "," + j + ")";
                newTag.transform.SetParent(gameObject.transform, false);
                runtimeTags.Add(newTag);
                
                buildChildDict();
                setTagValues(newTag);

                //move and size the new item
                RectTransform rectTransform = newTag.GetComponent<RectTransform>();

                float x = -containerRectTransform.rect.width / 2 + width * (i % columnCount);
                float y = containerRectTransform.rect.height / 2 - height * j;
                rectTransform.offsetMin = new Vector2(x, y);

                x = rectTransform.offsetMin.x + width;
                y = rectTransform.offsetMin.y + height;
                rectTransform.offsetMax = new Vector2(x, y);
            }


    }

    private void setTagValues(GameObject newTag)
    {
        childGameObjects["TagName"].GetComponent<Text>().text = "tagname";
        childGameObjects["TagValue"].GetComponent<Text>().text = "tagvalue";
    }

    private void buildChildDict()
    {
        childGameObjects = new Dictionary<string, GameObject>();
        foreach (Transform t in tagGameObjectPrefab.transform)
        {
            childGameObjects.Add(t.name, t.gameObject);
        }
    }

    void Update()
    {

    }

}
