using UnityEngine;
using System.Collections;

public class CurlyLine {

    private float radius;
    private Vector3 startPosition;

    float currX;
    float currY;
    float currZ;
    float zAxisOffset = 30;

    int numberOfElementsPerCircle = 5;

    public CurlyLine(float radius, Vector3 startPosition)
    {
        this.radius = radius;
        this.startPosition = startPosition;
    }

    public CurlyLine(float radius, Vector3 startPosition, int numberOfElementsPerCircle)
    {
        this.radius = radius;
        this.startPosition = startPosition;
        this.numberOfElementsPerCircle = numberOfElementsPerCircle;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Vector3 getPosForElement(int elementNumber)
    {
        //draw circle, move z coordinate for every node to back

        float angle = 360 / numberOfElementsPerCircle * elementNumber;
        float angleRad = angle * Mathf.PI / 180;

        currX = Mathf.Cos(angleRad) * radius;
        currY = Mathf.Sin(angleRad) * radius;
        currZ += zAxisOffset;


        return new Vector3(currX, currY, currZ);

    }

}
