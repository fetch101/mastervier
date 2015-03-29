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
        drawCircleLine();
    }

    public Circle(float radius, int numberOfElements, Vector3 center)
    {
        this.radius = radius;
        this.numberOfElements = numberOfElements;
        this.center = center;
    }


    private void drawCircleLine()
    {
        GameObject circleLine = new GameObject();
        LineRenderer lineRenderer = circleLine.AddComponent<LineRenderer>();
        float theta_scale = 0.1f;             
        int size = (int)((2.0 * Mathf.PI) / theta_scale) + 1;


        lineRenderer.SetWidth(0.2F, 0.2F);
        lineRenderer.SetVertexCount(size + 1);

        int i = 0;
        
        for (float theta = 0; theta < 2 * Mathf.PI; theta += theta_scale)
        {
            float x = radius * Mathf.Cos(theta);
            float y = radius * Mathf.Sin(theta);

            Vector3 pos = new Vector3(x, y, 0);
            lineRenderer.SetPosition(i, pos);
            if (i == 0)
            {
                lineRenderer.SetPosition(size, pos);
            }
            i += 1;
        }
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
