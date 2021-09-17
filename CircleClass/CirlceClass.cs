using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CircleClass
public class CircleClass : ProcessingLite.GP21
{

        //Cirkelns Position x,y. Vector2 beskriver ett objekten som håller i ett x och y värde.
        public Vector2 pos;
        //Cirkelns diameter
        public float diameter;
        //Cirkelns Velocitet i x,y led. I detta fallet beskriver då Vector2 hur snabbt cirkeln färdas i x,y led.
        public Vector2 velocity = new Vector2(0, 0);

        //Cirkelns Contructor, passerar in en "Startposition" för cirkeln samt ett diameter värde.
        public CircleClass(Vector2 pos, float diameter = 1)
        {
            this.pos = pos;
            this.diameter = diameter;

        }

        //Rit funktion som ska kallas varje frame.
        public void draw()
        {

            //Uppdaterar cirkelns position på x, y led genom att ta t.ex. x += velocity.x.
            pos.x += Time.deltaTime * velocity.x;
            pos.y += Time.deltaTime * velocity.y;

            //Kollar om cirkeln är utanför spelytan, om den är det så *-1 för att invertera riktningen
            if ((pos.x + diameter / 2) > Width || (pos.x - diameter / 2) < 0)
            {
                velocity.x *= -1;
            }

            //Kollar om cirkeln är utanför spelytan, om den är det så *-1 för att invertera riktningen
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

            //Sätt velocity.x till hastighet * riktning på x, y led. *-1 är till för att flippa riktningen så att bollen rör sig mot cirkeln.
            velocity.x = (speed * direction.x) * -1;
            velocity.y = (speed * direction.y) * -1;
        }
    }

}
