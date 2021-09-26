using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4_version2 : ProcessingLite.GP21
{
    AccObject character;
    void Start()
    {
        Fill(255, 255, 255);
        character = new AccObject(new Vector2(3, 3));
        QualitySettings.vSyncCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Stroke(255, 255, 255, 255);
        Background(0);

        character.SetDirection(new Vector2(character.pos.x + Input.GetAxisRaw("Horizontal"), character.pos.y + Input.GetAxisRaw("Vertical")));

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (character.gravityState == false) { character.gravityState = true; }
            else { character.gravityState = false; }
        }


        character.Update();
        character.Draw();
    }
}

public class AccObject : ProcessingLite.GP21
{
    public Vector2 pos;
    private Vector2 velocity;
    private Vector2 acc = new Vector2(0, 0);
    private float diameter = 0.5f;
    public bool gravityState = false;


    public AccObject(Vector2 pos)
    {
        this.pos = pos;
    }

    public void Update()
    {
        Gravity();
        velocity += acc * Time.deltaTime;
        //Clamp magnitude, I clamp the "length" of the vector, not the direction. This defines a max velocity.
        velocity = Vector2.ClampMagnitude(velocity, 10f);

        pos += velocity * Time.deltaTime;
    }

    public void Draw()
    {
        Stroke(255, 255, 255);
        Circle(pos.x, pos.y, diameter);

        Stroke(0, 255, 0, 128);
        Line(pos.x, pos.y, pos.x + velocity.x, pos.y + velocity.y);
    }

    private void Gravity()
    {
        if(gravityState == false) { return; }
        if (pos.y - diameter / 2 <= 0)
        {
            pos.y = diameter / 2;
        }
        else
        {
            velocity.y -= 10f * Time.deltaTime;
        }
    }

    public void SetDirection(Vector2 dir)
    {

        //Calculate the vector between direction and pos.
        acc = dir - pos;

        //Here I normalize the acceleration vector's magnitude. The vector "length" becomes 1 but the direction remains the same.
        acc = acc.normalized;

        acc *= 30f;
    }

}