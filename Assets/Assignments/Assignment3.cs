using UnityEngine;

public class Assignment3 : ProcessingLite.GP21
{
    private Circle circle;

    private void Start()
    {
        circle = new Circle(new Vector2(3, 5), 1);
    }

    private void Update()
    {
        Background(Color.black);

        //Kalla p� Cirkeln.draw();
        circle.draw();

        //Om v�nster musknapp �r nedtryckt
        if (Input.GetMouseButton(0))
        {
            //Tar redan p� musensposition relativt till unity ytan.
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Ritar en linje mellan Cirkeln och Musens position.
            Line(circle.pos.x, circle.pos.y, mousePos.x, mousePos.y);

            //Tar reda p� x, y skillnaderna mellan cirkeln och muspekaren. T.ex f�r x s� g�r man Cirkel.pos.x - MousePos.x
            Vector2 direction = new Vector2(circle.pos.x - mousePos.x, circle.pos.y - mousePos.y);
            float speed = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));

            //Kallar Cirkel.move() och passerar in en hastighet samt riktningen.
            circle.move(speed, direction);
        }
    }
}

public class Circle : ProcessingLite.GP21
{
    //Cirkelns Position x,y. Vector2 beskriver ett objekten som h�ller i ett x och y v�rde.
    public Vector2 pos;

    //Cirkelns diameter
    public float diameter;

    //Cirkelns Velocitet i x,y led. I detta fallet beskriver d� Vector2 hur snabbt cirkeln f�rdas i x,y led.
    public Vector2 velocity = new Vector2(0, 0);

    //Cirkelns Contructor, passerar in en "Startposition" f�r cirkeln samt ett diameter v�rde.
    public Circle(Vector2 pos, float diameter = 1)
    {
        this.pos = pos;
        this.diameter = diameter;
    }

    //Rit funktion som ska kallas varje frame.
    public void draw()
    {
        //Uppdaterar cirkelns position p� x, y led genom att ta t.ex. x += velocity.x.
        pos.x += Time.deltaTime * velocity.x;
        pos.y += Time.deltaTime * velocity.y;

        //Kollar om cirkeln �r utanf�r spelytan, om den �r det s� *-1 f�r att invertera riktningen
        if ((pos.x + diameter / 2) > Width || (pos.x - diameter / 2) < 0)
        {
            velocity.x *= -1;
        }

        //Kollar om cirkeln �r utanf�r spelytan, om den �r det s� *-1 f�r att invertera riktningen
        if ((pos.y + diameter / 2) > Height || (pos.y - diameter / 2) < 0)
        {
            velocity.y *= -1;
        }

        //Rita cirkeln
        Circle(pos.x, pos.y, diameter);
    }

    public void move(float speed, Vector2 direction)
    {
        speed = Mathf.Clamp(speed, 0f, 1f);

        //S�tt velocity.x till hastighet * riktning p� x, y led. *-1 �r till f�r att flippa riktningen s� att bollen r�r sig mot cirkeln.
        velocity.x = (speed * direction.x) * -1;
        velocity.y = (speed * direction.y) * -1;
    }
}