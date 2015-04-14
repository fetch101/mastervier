using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Circle {


    float radius;
    float currX;
    float currY;
    float currZ;
	Vector3 center = new Vector3 (0f, 0f, 0f);
	float startAngleRad;
    float xOffset = 30f;
    float currMultiplicator = 1;

	
    public Circle(float radius, Vector3 center)
    {
        this.radius = radius;
		this.center = center;
        setStartAngleRad(radius);

    }

    private void setStartAngleRad(float radius)
    {

        this.startAngleRad = Mathf.Asin(this.xOffset / radius);
    }

    public Vector3 getNextPos()
    {

        float currAngleRad = startAngleRad * currMultiplicator;

        currX = Mathf.Cos(currAngleRad) * radius;
        currY = Mathf.Sin(currAngleRad) * radius;

        startAngleRad *= -1;
        
        if (startAngleRad >= 0)
        {
            currMultiplicator += 2f;
        }

        return new Vector3(center.x + currX, center.y + currY, center.z + currZ);

    }

}
