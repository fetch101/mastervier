using UnityEngine;
using System.Collections;

public class Circle {


    float radius;
    int numberOfElements;
    float currX;
    float currY;
    float currZ;
    Vector3 center = new Vector3(0f, 0f, 0f);

    public Circle(float radius, int numberOfElements)
    {
        this.radius = radius;
        this.numberOfElements = numberOfElements;
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

}
