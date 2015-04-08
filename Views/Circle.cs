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
    float xOffset = 30f;
    float currMultiplicator = 1;


    public Circle(float radius, int numberOfElements)
    {
        this.radius = radius;
        this.numberOfElements = numberOfElements;

    }

    public Circle(float radius)
    {
        this.radius = radius;
        setStartAngleRad(radius);

    }

    private void setStartAngleRad(float radius)
    {

        this.startAngleRad = Mathf.Asin(this.xOffset / radius);
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
