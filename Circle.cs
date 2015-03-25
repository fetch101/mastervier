using UnityEngine;
using System.Collections;

public class Circle {


    float radius;
    int numberOfElements;
    float currX;
    float currY;
    float currZ;
    float offsetZ = 0;
    Vector3 startVector = new Vector3(0f, 0f, 0f);

    public Circle(float radius, int numberOfElements)
    {
        this.radius = radius;
        this.numberOfElements = numberOfElements;
    }


    //TODO needs direction, decouple spiral from circle
    public Circle(float radius, float offsetZ, Vector3 startVector)
    {
        this.radius = radius;
        this.numberOfElements = 5;
        this.offsetZ = offsetZ;
        this.startVector = startVector;
    }


    public Vector3 getPosForElement(int elementNumber)
    {
        float angle = 360 / numberOfElements * elementNumber;
        float angleRad = angle * Mathf.PI / 180;

        currX = Mathf.Cos(angleRad) * radius;
        currY = Mathf.Sin(angleRad) * radius;
        currZ = offsetZ * elementNumber;


        return new Vector3(startVector.x + currX, startVector.y + currY, startVector.z + currZ);
    }

}
