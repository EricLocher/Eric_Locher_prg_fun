using UnityEngine;

public class Ball : ProcessingLite.GP21
{
    public Vector2 pos;
    public Vector2 velocity = new Vector2(3, 3);
    public float diameter;
    Color color;
    Color strokeColor;

    public Ball(Player player)
    {
        diameter = Random.Range(0.4f, 0.7f);

        while (true)
        {
            pos.x = Random.Range(0 + diameter, Width - diameter);
            pos.y = Random.Range(0 + diameter, Height - diameter);

            if (Mathf.Pow(pos.x - player.pos.x, 2) + Mathf.Pow(pos.y - player.pos.y, 2) < Mathf.Pow(player.noSpawnRadius, 2)) { }
            else { break; }
        }
        velocity.x = Random.Range(-7, 7);
        velocity.y = Random.Range(-7, 7);
        color = Color.red;
        strokeColor = Color.black;
    }

    public void Update()
    {

        if ((pos.x + diameter / 2 > Width && velocity.x > 0) || (pos.x - diameter / 2 < 0 && velocity.x < 0))
        {
            velocity.x *= -1;
        }
        if ((pos.y + diameter / 2 > Height && velocity.y > 0) || (pos.y - diameter / 2 < 0 && velocity.y < 0))
        {
            velocity.y *= -1;
        }

        pos += velocity * Time.deltaTime;
    }

    public void Draw()
    {
        Stroke(0, 0, 0, 0);
        Fill((int)color.r * 255, (int)color.g * 255, (int)color.b * 255, 255);
        Circle(pos.x, pos.y, diameter);
        Stroke(255, 255, 255, 255);

    }

}