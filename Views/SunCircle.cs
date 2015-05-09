using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SunCircle {


    float radius;
	Vector3 center;
    int numberOfElements;

	
    public SunCircle(float radius, Vector3 center, int numberOfElements)
    {
        this.radius = radius;
		this.center = center;
        this.numberOfElements = numberOfElements;
    }


    public Vector3 getPosForElement(int elementNumber)
    {

        float angle = 360 / numberOfElements * elementNumber;

        float angleRad = angle * Mathf.PI / 180;

        float currY = 0;
        float currX = Mathf.Cos(angleRad) * radius;
        float currZ = Mathf.Sin(angleRad) * radius;

        return new Vector3(center.x + currX, center.y + currY, center.z + currZ);
    }

    //this somehow return correct rotations... magic!
    public float getRotationForElement(int elementNumber)
    {
        return 360 / numberOfElements * elementNumber;
    }

}
