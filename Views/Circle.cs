using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Circle {


    float radius;
    int numberOfElements;
    float currX;
    float currY;
    float currZ;
    Vector3 center = new Vector3(0f, 0f, 0f);
    float startAngleRad;
    float xOffset;
    int currMultiplicator = 1;


    public Circle(float radius, int numberOfElements)
    {
        this.radius = radius;
        this.numberOfElements = numberOfElements;

    }

    public Circle(float radius, float xOffset)
    {
        this.radius = radius;
        this.startAngleRad = Mathf.Asin(xOffset / radius);

    }

    public Circle(float radius, int numberOfElements, Vector3 center)
    {
        this.radius = radius;
        this.numberOfElements = numberOfElements;
        this.center = center;
    }


   

    public Vector3 getPosForElement(int elementNumber)
    {

        float angle = 360 / numberOfElements * elementNumber;

        float angleRad = angle * Mathf.PI / 180;

        currX = Mathf.Cos(angleRad) * radius;
        currY = Mathf.Sin(angleRad) * radius;


        return new Vector3(center.x + currX, center.y + currY, center.z + currZ);
    }

    public Vector3 getNextPos()
    {

        float currAngleRad = startAngleRad * currMultiplicator;
        currAngleRad = currAngleRad % (2 * Mathf.PI);

        currX = Mathf.Cos(currAngleRad) * radius;
        currY = Mathf.Sin(currAngleRad) * radius;

        currMultiplicator++;
        startAngleRad *= -1;
        

        return new Vector3(center.x + currX, center.y + currY, center.z + currZ);

    }

}
