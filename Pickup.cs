using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    public Texture2D contentMarkedTexture;
    public float markedTextureScale = 10f;
    private bool contentInSight = false;
    private bool contentIsGrabbed = false;
	private bool isFocusModeOn = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		isFocusModeOn = PauseMenu.instance.focusModeOn;

        Ray raycheck = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        RaycastHit hitcheck;


        if (Physics.Raycast(raycheck, out hitcheck, 40f) && hitcheck.collider.gameObject.GetComponent<Content>() != null) 
        {
            contentInSight = true;

            if (Input.GetKeyDown("t") && !contentIsGrabbed)
            {
                hitcheck.collider.gameObject.transform.parent = this.transform;
                contentIsGrabbed = true;
            }
            else if (Input.GetKeyDown("t") && contentIsGrabbed)
            {
                hitcheck.collider.gameObject.transform.parent = null;
                contentIsGrabbed = false;
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


