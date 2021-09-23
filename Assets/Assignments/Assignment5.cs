using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment5 : ProcessingLite.GP21
{
    [SerializeField] private int AmountOfBalls;
    private Player player;
    private List<Ball> balls;
    private GameStates STATE;
    [SerializeField] private GameObject GameOver;


    void Start()
    {
        STATE = GameStates.PLAYING;
        QualitySettings.vSyncCount = 0;
        player = new Player(new Vector2(Width / 2, Height / 2), 0.5f, Color.cyan);
        balls = new List<Ball>();

        for (int i = 0; i < AmountOfBalls; i++)
        {
            balls.Add(new Ball(player));
        }

        InvokeRepeating("SpawnBall", 3.0f, 3.0f);

    }

    // Update is called once per frame
    void Update()
    {

        if (STATE.Equals(GameStates.PAUSED)) { return; }

        if (STATE.Equals(GameStates.PLAYING))
        {
            Background(0);
            player.Update();
            player.Draw();

            foreach (Ball ball in balls)
            {

                float distance = Vector2.Distance(ball.pos, player.pos);

                if (distance <= (ball.diameter / 2 + player.diameter / 2))
                {
                    //Player has been hit
                    player.color = Color.magenta;
                    STATE = GameStates.GAMEOVER;
                }

                ball.Update();
                ball.Draw();
            }
        } else if(STATE.Equals(GameStates.GAMEOVER))
        {
            Background(125, 36, 30);
            GameOver.SetActive(true);
            if (Input.GetKey(KeyCode.R))
            {
                GameOver.SetActive(false);
                CancelInvoke();
                Start();
            }

        }
    }

    private void SpawnBall()
    {
        balls.Add(new Ball(player));
    }


}

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

public class Ball : ProcessingLite.GP21
{
    public Vector2 pos;
    public Vector2 velocity = new Vector2(3, 3);
    public float diameter;
    Color color;
    Color strokeColor;

    public Ball(Player player)
    {
        diameter = Random.Range(0.2f, 0.7f);

        while (true)
        {
            pos.x = Random.Range(0 + diameter, Width - diameter);
            pos.y = Random.Range(0 + diameter, Height - diameter);

            if (Mathf.Pow(pos.x - player.pos.x, 2) + Mathf.Pow(pos.y - player.pos.y, 2) < Mathf.Pow(player.noSpawnRadius, 2)) {}
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
        Stroke((int)color.r * 255, (int)color.g * 255, (int)color.b * 255, 255);
        Fill((int)strokeColor.r * 255, (int)strokeColor.g * 255, (int)strokeColor.b * 255, 255);
        Circle(pos.x, pos.y, diameter);
        Stroke(255, 255, 255, 255);

    }

}

public enum GameStates{
    PLAYING,
    PAUSED,
    GAMEOVER
}

