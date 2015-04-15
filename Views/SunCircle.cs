using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SunCircle {


    float radius;
    float currX;
    float currY;
    float currZ;
	Vector3 center = new Vector3 (0f, 0f, 0f);
	float startAngleRad;
    float xOffset = 30f;
    float currMultiplicator = 1;
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

        currX = Mathf.Cos(angleRad) * radius;
        currZ = Mathf.Sin(angleRad) * radius;


        return new Vector3(center.x + currX, center.y + currY, center.z + currZ);
    }

    public float getRotationForElement(int elementNumber)
    {

        return 360 / numberOfElements * elementNumber;

    }

}
