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
    public Vector3 getPosForElement(int elementNumber, float rotationY)
    {

        //float angle = 360 / numberOfElementsPerCircle * elementNumber;
        //float angleRad = angle * Mathf.PI / 180;

        //currX = startPosition.x + Mathf.Cos(angleRad) * radius;
        //currY = startPosition.y + Mathf.Sin(angleRad) * radius;
        //currZ = startPosition.z + elementNumber * zAxisOffset;
        currX = startPosition.x + elementNumber * 25;
        currY = startPosition.y;
        currZ = startPosition.z;
        //currY = startPosition.y + 20;
        //currZ = startPosition.z + 20;

        //float phi = Mathf.Atan(currZ / currX);
        //float r = Mathf.Sqrt(Mathf.Pow(currZ, 2) + Mathf.Pow(currX, 2));
        //float phi2 = phi + localRot;
        //currZ = r * Mathf.Sin(phi2);
        //currX = r * Mathf.Cos(phi2);
        Vector3 currVector = new Vector3(currX, currY, currZ);

        if (elementNumber % 4 == 0)
        {
            currVector = Quaternion.Euler(0, rotationY, 5) * currVector;

        }
        else if(elementNumber % 4 == 1)
        {
            currVector = Quaternion.Euler(0, rotationY + 5, 0) * currVector;
        }
        else if (elementNumber % 4 == 2)
        {
            currVector = Quaternion.Euler(0, rotationY, -5) * currVector;
        }
        else
        {
            currVector = Quaternion.Euler(0, rotationY - 5, 0) * currVector;
        }

        return currVector;

    }

}
