using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleMode : MonoBehaviour
{

    public static BattleMode instance;
    public GameObject bulletClone;


    public bool battleMode = false;
    private List<Content> contents;

    // Use this for initialization
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        if (battleMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                fire();
            }
        }

    }

    public void setBattleMode(bool active)
    {
        SimKeeper.instance.setAllLines(false);
        contents = getAllContents();
        battleMode = active;

        foreach (Content content in contents)
        {
            //content.battleMode = true;
        }

    }

    private void fire()
    {
        GameObject bullet = Instantiate(bulletClone, Camera.main.transform.position, Camera.main.transform.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 1000);
    }

    public void alignContents(List<Content> contentList)
    {
        foreach (Content cont in contentList)
        {
            cont.moveTo(Camera.main.transform.position);
        }
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
