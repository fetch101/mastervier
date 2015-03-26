using UnityEngine;
using System.Collections;

public class Spiral {



    Vector3 startPosition = new Vector3(0f, 0f, 0f);
    Vector3 direction = new Vector3(0f, 0f, 0f);
    float currX;
    float currY;
    float currZ;
    float zAxisOffset = 30;
    int numberOfElementsPerCircle = 5;
    float radius = 50;

    public Spiral()
    {
    }    
    
    // TODO Implement direction
    public Spiral(Vector3 startPosition, Vector3 direction)
    {
        this.startPosition = startPosition;
    }

    public Spiral(float radius, Vector3 startPosition, int numberOfElementsPerCircle, float zAxisOffset)
    {
        this.radius = radius;
        this.startPosition = startPosition;
        this.numberOfElementsPerCircle = numberOfElementsPerCircle;
        this.zAxisOffset = zAxisOffset;
    }

    public Vector3 getPosForElement(int elementNumber)
    {
        //TODO currZ calculation needs to be proofed

        float angle = 360 / numberOfElementsPerCircle * elementNumber;
        float angleRad = angle * Mathf.PI / 180;

        currX = startPosition.x + Mathf.Cos(angleRad) * radius;
        currY = startPosition.y + Mathf.Sin(angleRad) * radius;
        currZ = startPosition.z + elementNumber * zAxisOffset;


        return new Vector3(currX, currY, currZ);

    }

}
