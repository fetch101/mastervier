using UnityEngine;
using System.Collections;

public class ContentManager : MonoBehaviour {
	private bool aimed = false;

	public string Tag0;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Ray raycheck = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
		
		RaycastHit hitcheck;
		
		
		
		if (Physics.Raycast (raycheck, out hitcheck, 40f) && hitcheck.collider.gameObject.GetComponent<Content> () != null) {

			setLock(true);
			
			GameObject ObjectToDisplayTags = hitcheck.collider.gameObject;
			
			Content contentScript = ObjectToDisplayTags.GetComponent<Content> ();
			
			Tag0 = contentScript.Tag0;

			//Debug.Log("active Tag:" + Tag0);

//			string Tag0 = contentScript.Tag0;

		
		}else{

			setLock(false);
		}
	}
	
	
public void OnGUI() {


			if (aimed)
			{
				GUI.TextField(new Rect(10, 10, 200, 200), "Tag0 = " + Tag0);
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





//	void DisplayTagsOfCurrentObject() {
//
//	GameObject ObjectToDisplayTags = hitcheck.collider.gameObject;
//	
//	Content contentScript = ObjectToDisplayTags.GetComponent<Content>();
//	
//	string Tag0 = contentScript.Tag0;
//	
//	
//	GUI.TextField(new Rect(10, 10, 200, 200), "Tag0 = " + Tag0);
//
//	}



