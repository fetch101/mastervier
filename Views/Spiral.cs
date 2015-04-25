using UnityEngine;
using System.Collections;

public class Spiral {


    //TODO this values have to be trimmed to fit the space requirements between contents
    Vector3 startPosition;
    float currX;
    float currY;
    float currZ;
    float zAxisOffset = 20;
    int numberOfElementsPerCircle = 5;
    float radius = 20;

    public Spiral(Vector3 startPosition)
    {
        this.startPosition = startPosition;
    }
    
    //TODO rotation needs to take place here
    public Vector3 getPosForElement(int elementNumber)
    {

        float angle = 360 / numberOfElementsPerCircle * elementNumber;
        float angleRad = angle * Mathf.PI / 180;

        //currX = startPosition.x + Mathf.Cos(angleRad) * radius;
        //currY = startPosition.y + Mathf.Sin(angleRad) * radius;
        //currZ = startPosition.z + elementNumber * zAxisOffset;
        currX = startPosition.x + elementNumber * 30;
        currY = startPosition.y + 20;
        //currZ = startPosition.z + 20;
        
        Vector3 currVector = new Vector3(currX, currY, currZ);
        return currVector;

    }

}
