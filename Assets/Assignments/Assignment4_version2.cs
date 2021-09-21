using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4_version2 : ProcessingLite.GP21
{
    AccObject character;
    void Start()
    {
        character = new AccObject(new Vector2(3, 3));
    }

    // Update is called once per frame
    void Update()
    {
        Stroke(255, 255, 255, 255);
        Background(0);

        character.SetDirection(new Vector2(character.pos.x + Input.GetAxisRaw("Horizontal"), character.pos.y + Input.GetAxisRaw("Vertical")));

        character.Update();
        character.Draw();
    }
}

public class AccObject : ProcessingLite.GP21
{
    public Vector2 pos;
    private Vector2 velocity;
    private Vector2 acc = new Vector2(0, 0);
    private Vector2 currentDirection = new Vector2(0, 0);

    public AccObject(Vector2 pos)
    {
        this.pos = pos;
    }

    public void Update()
    {
        velocity += acc * Time.deltaTime;
        velocity = Vector2.ClampMagnitude(velocity, 10f);
        pos += velocity * Time.deltaTime;
    }

    public void Draw()
    {
        Circle(pos.x, pos.y, 0.5f);
    }

    public void SetDirection(Vector2 dir)
    {
        if(dir != pos)
        {
            currentDirection = dir;
        }
        acc = currentDirection - pos;
        acc = acc.normalized;

        Stroke(0, 255, 0, 128);
        Line(pos.x, pos.y, pos.x + acc.x, pos.y + acc.y);

        acc *= 30f;
    }

}