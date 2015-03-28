using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineView : MonoBehaviour{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void alignContents(List<Content> contentList)
    {
        Vector3 start = new Vector3(0f, 0f, 0f);
        foreach (Content cont in contentList)
        {
            cont.gameObject.transform.position = start;
            start.z += 60;
        }
    }
}
