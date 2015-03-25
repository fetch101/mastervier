using UnityEngine;
using System.Collections;

public class Circle {


    float radius;
    int numberOfElements;
    float currX;
    float currY;
    float currZ;

    public Circle(float radius, int numberOfElements)
    {
        this.radius = radius;
        this.numberOfElements = numberOfElements;
    }


    public Vector3 getPosForElement(int elementNumber)
    {
        float angle = 360 / numberOfElements * elementNumber;
        float angleRad = angle * Mathf.PI / 180;

        currX = Mathf.Cos(angleRad) * radius;
        currY = Mathf.Sin(angleRad) * radius;


        return new Vector3(currX, currY, currZ);
    }

}
