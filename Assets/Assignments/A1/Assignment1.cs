using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment1 : ProcessingLite.GP21
{

    Vector2 pos = new Vector2(5,6);
    Vector3 mousePos;
    int r = 66;
    int g = 170;
    int b = 245;

    // Start is called before the first frame update
    void Start()
    {
        StrokeWeight(1);
    }

    // Update is called once per frame
    void Update()
    {
        Stroke(r, g, b);
        Background(Color.black);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Circle(mousePos.x, mousePos.y, 7.2f);
        Stroke(255, 255, 255);
        Circle(mousePos.x, mousePos.y, 7f);
        Stroke(r, g, b);
        Circle(mousePos.x, mousePos.y, 6.8f);
        Stroke(255, 255, 255);
        Circle(mousePos.x, mousePos.y, 6.6f);
        DrawMyName(new Vector2(mousePos.x, mousePos.y));
    }
    
    //Eric
    void DrawMyName(Vector2 pos)
    {
        pos.x -= 2.5f;
        pos.y += 1;
        //E
        Line(pos.x, pos.y, pos.x, pos.y - 2);
        Line(pos.x, pos.y, pos.x + 1, pos.y); 
        Line(pos.x, pos.y - 1, pos.x + 0.7f, pos.y -1);
        Line(pos.x, pos.y - 2, pos.x + 1, pos.y - 2);

        //r
        Line(pos.x + 2, pos.y - 1, pos.x + 2, pos.y - 2);
        Line(pos.x + 2, pos.y - 1.2f, pos.x + 2.2f, pos.y - 1.2f);
        Line(pos.x + 2.2f, pos.y - 1.15f, pos.x + 2.5f, pos.y - 1.15f);

        //i
        Line(pos.x + 3.5f, pos.y - 1.3f, pos.x + 3.5f, pos.y - 2);
        Line(pos.x + 3.5f, pos.y - 1, pos.x + 3.5f, pos.y - 0.9f);

        //c
        Line(pos.x + 4.5f, pos.y - 1.3f, pos.x + 4.5f, pos.y - 2);
        Line(pos.x + 4.5f, pos.y - 2, pos.x + 5, pos.y - 2);
        Line(pos.x + 4.5f, pos.y - 1.3f, pos.x + 5, pos.y - 1.3f);    
    }
}


