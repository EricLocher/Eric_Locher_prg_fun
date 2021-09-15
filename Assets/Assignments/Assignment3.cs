using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Assignment3 : ProcessingLite.GP21
{

    Circle circle;

    void Start()
    {
        circle = new Circle(new Vector2(3, 5), 1);
    }

    void Update()
    {
        Background(Color.black);

        circle.draw();

        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Line(circle.pos.x, circle.pos.y, mousePos.x, mousePos.y);

            Vector2 distance = new Vector2(circle.pos.x - mousePos.x, circle.pos.y - mousePos.y);
            circle.move(0.5f, distance);
            Debug.Log(distance);
        }
    }
}

public class Circle : ProcessingLite.GP21
{
    public Vector2 pos; 
    public float radius;
    public Vector2 velocity = new Vector2(0, 0);


    public Circle(Vector2 pos, float radius = 1)
    {
        this.pos = pos;
        this.radius = radius;
    }

    public void draw()
    {
        pos.x += Time.deltaTime * velocity.x;
        pos.y += Time.deltaTime * velocity.y;

        if (pos.x > Width || pos.x < 0)
        {
            velocity.x *= -1;
        }

        if (pos.y > Height || pos.y < 0)
        {
            velocity.y *= -1;
        }


        Circle(pos.x, pos.y, 1f);
    }

    public void move(float speed, Vector2 direction)
    {
        velocity.x = (speed * direction.x) * -1;
        velocity.y = (speed * direction.y) * -1;
    }


}
