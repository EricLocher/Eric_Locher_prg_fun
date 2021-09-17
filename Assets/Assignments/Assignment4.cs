using UnityEngine;

public class Assignment4 : ProcessingLite.GP21
{
    float speed = 3f;
    float acc;
    Character gubbe;
    Vector2 keyDown = new Vector2(0, 0);


    // Start is called before the first frame update
    private void Start()
    {
        gubbe = new Character(new Vector2(3,3));
    }

    // Update is called once per frame
    private void Update()
    {
        Background(0);

        gubbe.draw();
       
    }

}

public class Character : ProcessingLite.GP21
{
    public Vector2 pos;
    private Vector2 speed;

    public Character(Vector2 pos)
    {
        this.pos = pos;
    }

    public void draw()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            speed.x += (2f * Input.GetAxisRaw("Horizontal")) * Time.deltaTime;
            pos.x += Time.deltaTime * speed.x;
        }

        else
        {
            if(speed.x > 0)
                speed.x -= 2f * Time.deltaTime;
            else if(speed.x < 0)
                speed.x += 2f * Time.deltaTime;

            pos.x += Time.deltaTime * speed.x;     
        }


        if(Input.GetAxisRaw("Vertical") != 0)
        {
            speed.y += (2f * Input.GetAxisRaw("Vertical")) * Time.deltaTime;
            pos.y += Time.deltaTime * speed.y;
        }

        else
        {
            if (speed.y > 0)
                speed.y -= 2f * Time.deltaTime;
            else if (speed.y < 0)
                speed.y += 2f * Time.deltaTime;

            pos.y += Time.deltaTime * speed.y;
        }


        Circle(pos.x, pos.y, 0.7f);
    }


}
