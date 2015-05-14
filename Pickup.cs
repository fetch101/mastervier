using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    public Texture2D contentMarkedTexture;
    public float markedTextureScale = 10f;
    private bool contentInSight = false;
    private bool contentIsGrabbed = false;
	private bool isFocusModeOn = false;
    private Content grabbedContent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		isFocusModeOn = PauseMenu.instance.focusModeOn;

        Ray raycheck = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        RaycastHit hitcheck;

        if (Input.GetKeyDown("t") && contentIsGrabbed)
        {
            grabbedContent.gameObject.transform.parent = null;
            contentIsGrabbed = false;
        }


        if (Physics.Raycast(raycheck, out hitcheck, 40f) && hitcheck.collider.gameObject.GetComponent<Content>() != null) 
        {
            contentInSight = true;

            if (Input.GetKeyDown("t") && !contentIsGrabbed && !hitcheck.collider.gameObject.GetComponent<Content>().isMoving && !PauseMenu.instance.focusModeOn)
            {
                grabbedContent = hitcheck.collider.gameObject.GetComponent<Content>();
                Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth/2, Camera.main.pixelHeight/2, 100));
                grabbedContent.gameObject.transform.position = p;
                grabbedContent.gameObject.transform.parent = this.transform;
                contentIsGrabbed = true;
            }
            
        }else{

            contentInSight = false;
        }

	
	}

  

    void OnGUI()
    {
		if(!isFocusModeOn && contentInSight)
            {
                GUI.DrawTexture(new Rect((Screen.width - contentMarkedTexture.width * markedTextureScale) / 2, (Screen.height - contentMarkedTexture.height * markedTextureScale) / 2, contentMarkedTexture.width * markedTextureScale, contentMarkedTexture.height * markedTextureScale), contentMarkedTexture);
			}
      
    }

}


