using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    public float xStart = 0.0f;
    public float xEnd = 10.0f;
    public float yStart = 0.0f;
    public float yEnd = 10.0f;

    void Start()
    {
    }

    void Update()
    {
        // calculate the scale of the child object
        float widthPercent = .01f * (xEnd - xStart);
        float heightPercent = .01f * (yEnd - yStart);
        //Debug.Log("w: " + width);
        //Debug.Log("h: " + height);

        this.transform.localScale = new Vector3(widthPercent, heightPercent, transform.localScale.z);

        // Transform position
        float[] position = PercentToPosition(xStart * 0.01f, yStart * 0.01f, widthPercent, heightPercent);
        float x = position[0];
        float y = position[1];
        this.transform.localPosition = new Vector3(x, y, transform.localPosition.z);
    }

    // x and y range is -0.5 to 0.5, so we need to convert the percentage to a value between -0.5 and 0.5
    public float[] PercentToPosition(float xStartPercent, float yStartPercent, float xSize, float ySize)
    {
        float[] positionArray = { 0, 0 };

        // readability
        float xHalfSize = xSize / 2;
        float yHalfSize = ySize / 2;

        // starting point for our x
        float x = -.5f;
        // shift right by when highlighted starts
        x += xStartPercent;
        // shift right by half the size of the highlight
        x += xHalfSize;

        float y = .5f;
        y -= yStartPercent;
        y -= yHalfSize;

        positionArray[0] = x;
        positionArray[1] = y;

        return positionArray;

    }
}

