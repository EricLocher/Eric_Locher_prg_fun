using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment3_Extra : ProcessingLite.GP21
{

    Vector2 randomVector;
    Vector2 start = new Vector2(0, 0);
    Vector2 end = new Vector2(0, 0);

    void Start()
    {
        randomVector.x = Random.Range(0, 10);
        randomVector.y = Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        Background(Color.black);

        if (Input.GetMouseButtonDown(0))
        {
            start = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        } 
        else if (Input.GetMouseButtonUp(0))
        {
            end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        Line(start.x, start.y, end.x, end.y);

        Debug.Log("Vector to match: " + randomVector);
        Debug.Log("Your Vector: " + new Vector2((start.x - end.x) *-1, (start.y - end.y) * -1));
    }
}
