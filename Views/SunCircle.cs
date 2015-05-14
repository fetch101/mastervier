using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SunCircle {


    float radius;
	Vector3 center;
    int numberOfElements;

	
    public SunCircle(Vector3 center, int numberOfElements)
    {
        this.radius = (numberOfElements * 60) / (2 * Mathf.PI);
		this.center = center;
        this.numberOfElements = numberOfElements;
        //drawCircleLine(radius, center);
    }


    public Vector3 getPosForElement(int elementNumber)
    {

        float angle = 360 / numberOfElements * elementNumber;

        float angleRad = angle * Mathf.PI / 180;

        float currY = 0;
        float currX = Mathf.Cos(angleRad) * radius;
        float currZ = Mathf.Sin(angleRad) * radius;

        return new Vector3(center.x + currX, center.y + currY, center.z + currZ);
    }

    public float getRotationForElement(int elementNumber)
    {
        return 360 / numberOfElements * elementNumber;
    }


    private void drawCircleLine(float radius, Vector3 center)
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
            float z = radius * Mathf.Sin(theta);

            Vector3 pos = new Vector3(center.x + x, center.y, center.z + z);
            lineRenderer.SetPosition(i, pos);
            if (i == 0)
            {
                lineRenderer.SetPosition(size, pos);
            }
            i += 1;
        }
    }

}
