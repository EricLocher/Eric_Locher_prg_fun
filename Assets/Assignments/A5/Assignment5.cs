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

public enum GameStates{
    PLAYING,
    PAUSED,
    GAMEOVER
}

