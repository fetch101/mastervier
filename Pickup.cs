using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    public Texture2D contentMarkedTexture;
    public float markedTextureScale = 10f;
    private bool aimed = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Ray raycheck = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        RaycastHit hitcheck;

        //Debug.Log("Mouse position: " + Input.mousePosition);

        if (Physics.Raycast(raycheck, out hitcheck, 10f) && hitcheck.collider.gameObject.GetComponent<Content>() != null) 
        {
            setLock(true);
            


            if (Input.GetKeyDown("t"))
            {
                hitcheck.collider.gameObject.transform.parent = this.transform;
            }
            else if (Input.GetKeyDown("g"))
            {
                hitcheck.collider.gameObject.transform.parent = null;
            }

        }else{

            setLock(false);
        }

	
	}


  

    void OnGUI()
    {
        if (contentMarkedTexture != null)
        {
            if (aimed)
            {
                GUI.DrawTexture(new Rect((Screen.width - contentMarkedTexture.width * markedTextureScale) / 2, (Screen.height - contentMarkedTexture.height * markedTextureScale) / 2, contentMarkedTexture.width * markedTextureScale, contentMarkedTexture.height * markedTextureScale), contentMarkedTexture);
            }
        }
        else
        {
            Debug.Log("No crosshair texture set in the Inspector");
        }

    }

    public void setLock(bool aimed)
    {
        this.aimed = aimed;
    }

}


