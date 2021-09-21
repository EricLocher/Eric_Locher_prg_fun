using UnityEngine;

public class Assignment3 : ProcessingLite.GP21
{
    private Circle circle;
    Vector2 mousePos;

    private void Start()
    {
        circle = new Circle(new Vector2(3, 5), 1);
    }

    private void Update()
    {
        Background(Color.black);

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        circle.draw();

        if (Input.GetMouseButtonDown(0))
        {
            circle.velocity = Vector2.zero;
            circle.pos = mousePos;
        }

        if (Input.GetMouseButton(0))
        {
            Line(circle.pos.x, circle.pos.y, mousePos.x, mousePos.y);

        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 direction = new Vector2(mousePos.x - circle.pos.x, mousePos.y - circle.pos.y);
            float speed = direction.magnitude;

            circle.move(speed, direction);
        }

    }
}

public class Circle : ProcessingLite.GP21
{

    public Vector2 pos;
    
    public float diameter;

    public Vector2 velocity = new Vector2(0, 0);

    public Circle(Vector2 pos, float diameter = 1)
    {
        this.pos = pos;
        this.diameter = diameter;
    }

    public void draw()
    {
        pos += Time.deltaTime * velocity;

        if ((pos.x + diameter / 2) > Width || (pos.x - diameter / 2) < 0)
        {
            velocity.x *= -1;
        }

        if ((pos.y + diameter / 2) > Height || (pos.y - diameter / 2) < 0)
        {
            velocity.y *= -1;
        }

        Circle(pos.x, pos.y, diameter);
    }

    public void move(float speed, Vector2 direction)
    {
        velocity.x += (speed / direction.magnitude) * direction.x;
        velocity.y += (speed / direction.magnitude) * direction.y;
    }
}