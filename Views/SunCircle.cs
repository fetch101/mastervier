using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SunCircle {


    float radius;
	Vector3 center;
    int numberOfElements;

	
    public SunCircle(Vector3 center, int numberOfElements)
    {
        this.radius = (numberOfElements * 150) / (2 * Mathf.PI);
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

    public float getRotationForElement(int elementNumber)
    {
        return 360 / numberOfElements * elementNumber;
    }

}
