using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleMode : MonoBehaviour
{

    public static BattleMode instance;


    public bool battleMode = false;
    private List<Content> contents;

    public float range = 200.0f;

    public float cooldown = 0.02f;
    public float cooldownRemaining = 0;

    public GameObject debrisPrefab;


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
            cooldownRemaining -= Time.deltaTime;

            if (Input.GetMouseButton(0) && cooldownRemaining <= 0)
            {
                cooldownRemaining = cooldown;

                Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo, range))
                {
                    Vector3 hitPoint = hitInfo.point;
                    GameObject go = hitInfo.collider.gameObject;
                    Debug.Log("Hit Object: " + go.name);
                    Debug.Log("Hit Point: " + hitPoint);

                    if (go.GetComponent<Content>() != null)
                    {
                        if (debrisPrefab != null)
                        {
                            Instantiate(debrisPrefab, hitPoint, Quaternion.identity);
                        }
                    }

                }

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
            content.battleMode = true;
        }

    }

    private void fire()
    {


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
