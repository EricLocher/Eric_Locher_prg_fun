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

        //Kalla på Cirkeln.draw();
        circle.draw();

        //Om vänster musknapp är nedtryckt
        if (Input.GetMouseButton(0))
        {
            //Tar redan på musensposition relativt till unity ytan.
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Ritar en linje mellan Cirkeln och Musens position.
            Line(circle.pos.x, circle.pos.y, mousePos.x, mousePos.y);

            //Tar reda på x, y skillnaderna mellan cirkeln och muspekaren. T.ex för x så gör man Cirkel.pos.x - MousePos.x
            Vector2 direction = new Vector2(circle.pos.x - mousePos.x, circle.pos.y - mousePos.y);

            //Kallar Cirkel.move() och passerar in en hastighet samt riktningen. 
            circle.move(0.5f, direction);
            Debug.Log(direction);
        }
    }
}

public class Circle : ProcessingLite.GP21
{

    //Cirkelns Position x,y. Vector2 beskriver ett objekten som håller i ett x och y värde.
    public Vector2 pos; 
    //Cirkelns radius
    public float radius;
    //Cirkelns Velocitet i x,y led. I detta fallet beskriver då Vector2 hur snabbt cirkeln färdas i x,y led.
    public Vector2 velocity = new Vector2(0, 0);

    //Cirkelns Contructor, passerar in en "Startposition" för cirkeln samt ett radius värde.
    public Circle(Vector2 pos, float radius = 1)
    {
        this.pos = pos;
        this.radius = radius;
    }

    //Rit funktion som ska kallas varje frame.
    public void draw()
    {

        //Uppdaterar cirkelns position på x, y led genom att ta t.ex. x += velocity.x.
        pos.x += Time.deltaTime * velocity.x;
        pos.y += Time.deltaTime * velocity.y;

        //Kollar om cirkeln är utanför spelytan, om den är det så *-1 för att invertera riktningen
        if (pos.x > Width || pos.x < 0)
        {
            velocity.x *= -1;
        }

        //Kollar om cirkeln är utanför spelytan, om den är det så *-1 för att invertera riktningen
        if (pos.y > Height || pos.y < 0)
        {
            velocity.y *= -1;
        }

        //Rita cirkeln
        Circle(pos.x, pos.y, 1f);
    }

    public void move(float speed, Vector2 direction)
    {

        //Sätt velocity.x till hastighet * riktning på x, y led. *-1 är till för att flippa riktningen så att bollen rör sig mot cirkeln.
        velocity.x = (speed * direction.x) * -1;
        velocity.y = (speed * direction.y) * -1;
    }
}
