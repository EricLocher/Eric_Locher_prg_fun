using UnityEngine;

public class Player : ProcessingLite.GP21
{
    public Vector2 pos;
    Vector2 velocity;
    Vector2 acc;
    public float diameter;
    public Color color;
    public float noSpawnRadius = 3f;


    public Player(Vector2 pos, float diameter, Color color)
    {
        this.pos = pos;
        this.diameter = diameter;
        this.color = color;
    }

    public void Update()
    {

        Movement();

        if (acc == Vector2.zero)
        {
            velocity.x = Mathf.Lerp(velocity.x, 0, 0.01f);
            velocity.y = Mathf.Lerp(velocity.y, 0, 0.01f);
        }

        velocity += acc * Time.deltaTime;
        velocity = Vector2.ClampMagnitude(velocity, 10f);
        pos += velocity * Time.deltaTime;
    }

    private void Movement()
    {


        if ((pos.x + diameter / 2 > Width && velocity.x > 0) || (pos.x - diameter / 2 < 0 && velocity.x < 0))
        {
            velocity.x *= -1;
        }
        if ((pos.y + diameter / 2 > Height && velocity.y > 0) || (pos.y - diameter / 2 < 0 && velocity.y < 0))
        {
            velocity.y *= -1;
        }


        Vector2 dir = new Vector2(pos.x + Input.GetAxisRaw("Horizontal"), pos.y + Input.GetAxisRaw("Vertical"));

        acc = dir - pos;

        acc = acc.normalized;

        acc *= 30f;

    }

    public void Draw()
    {
        Stroke((int)color.r * 255, (int)color.g * 255, (int)color.b * 255, 255);
        Fill((int)color.r * 255, (int)color.g * 255, (int)color.b * 255, 255);
        Circle(pos.x, pos.y, diameter);
        Stroke(255, 255, 255, 255);
    }

}

