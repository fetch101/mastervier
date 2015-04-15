using UnityEngine;
using System.Collections;

public class Spiral {



    Vector3 startPosition;
    float rotationYDegree;
    float currX;
    float currY;
    float currZ;
    float zAxisOffset = 20;
    int numberOfElementsPerCircle = 5;
    float radius = 20;

    public Spiral()
    {
    }    

    public Spiral(Vector3 startPosition, float rotationYDegree)
    {
        this.startPosition = startPosition;
        this.rotationYDegree = rotationYDegree;
    }
    
    public Vector3 getPosForElement(int elementNumber)
    {
        //TODO currZ calculation needs to be proofed
        //if (elementNumber == 0)
        //{
        //    return startPosition;
        //}

        float angle = 360 / numberOfElementsPerCircle * elementNumber;
        float angleRad = angle * Mathf.PI / 180;

        //currX = startPosition.x + Mathf.Cos(angleRad) * radius;
        //currY = startPosition.y + Mathf.Sin(angleRad) * radius;
        //currZ = startPosition.z + elementNumber * zAxisOffset;

        currX = startPosition.x + elementNumber * 60;
        currY = startPosition.y;
        currZ = startPosition.z;

        Vector3 currVector = new Vector3(currX, currY, currZ);
        //Debug.Log("before euler: " + currVector);
        //currVector = Quaternion.Euler(0, rotationYDegree, 0) * currVector;
        //Debug.Log("after euler: " + currVector);

        return currVector;

    }

}
